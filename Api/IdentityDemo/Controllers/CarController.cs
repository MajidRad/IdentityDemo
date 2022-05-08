using AutoMapper;
using IdentityDemo.Data;
using IdentityDemo.DTOs;
using IdentityDemo.Extensions;
using IdentityDemo.Model;
using IdentityDemo.RequestHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace IdentityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public CarController(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        [HttpGet("GetCars")]
        public async Task<ActionResult<PagedList<CarDtoWithDetails>>> GetCars([FromQuery] CarParams carParams)
        {
            var query = _storeContext.Cars
                .Sort(carParams.orderBy)
                .Search(carParams.SearchTerm)
                .Include(q => q.Brand);

            var cars = await PagedList<Car>.ToPagedList(query, carParams.PageNumber, carParams.PageSize);
            Response.AddPaginationHeader(cars.MetaData);
            var mappedCars = _mapper.Map<List<CarDtoWithDetails>>(cars);

            return Ok(mappedCars);
        }


        [HttpGet("GetFilteredCar")]
        public async Task<ActionResult<PagedList<CarFilteredDto>>> GetFilteredCar([FromQuery] CarParams carParams)
        {
            var query = _storeContext.Cars
                .Search(carParams.SearchTerm)
                .Sort(carParams.orderBy);
            var filteredCars = await PagedList<Car>.ToPagedList(query, carParams.PageNumber, carParams.PageSize);
            var mappedCars = _mapper.Map<List<CarFilteredDto>>(filteredCars);
            return Ok(mappedCars);
        }


        [HttpGet("GetCar/{Id}")]
        public async Task<ActionResult<CarDtoWithDetails>> GetCar(int Id)
        {
            var car = await _storeContext.Cars
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Id == Id);
            if (car == null) return NotFound();
            var mappedCar = _mapper.Map<CarDtoWithDetails>(car);
            return Ok(mappedCar);
        }

        [HttpPost("RegisterCar")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RegisterCar([FromBody] RegisterCarDto registerCar)
        {
            var brand = await _storeContext.Brands.FindAsync(registerCar.BrandId);
            if (brand == null) return BadRequest(new ProblemDetails { Title = "ForignKey is not Exist" });

            var mapedCar = _mapper.Map<Car>(registerCar);
            _storeContext.Cars.Add(mapedCar);
            var result = await _storeContext.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem to save new car" });
        }


        [HttpDelete("DeleteCar/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCar(int Id)
        {
            var car = await _storeContext.Cars.FindAsync(Id);
            if (car == null) return NotFound();
            _storeContext.Cars.Remove(car);
            var result = await _storeContext.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem del car" });
        }
    }
}
