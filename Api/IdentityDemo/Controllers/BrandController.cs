using AutoMapper;
using IdentityDemo.Data;
using IdentityDemo.DTOs;
using IdentityDemo.Extensions;
using IdentityDemo.Model;
using IdentityDemo.RequestHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public BrandController(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("RegisterBrand")]
        public async Task<ActionResult> RegisterBrand([FromBody] RegisterBrandDto brand)
        {
            var mappedBrand = _mapper.Map<Brand>(brand);
            _storeContext.Brands.Add(mappedBrand);
            var result = await _storeContext.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Detail = "Error during save brand" });
        }


        [HttpGet("GetBrandsWithDetails")]
        public async Task<ActionResult<BrandDtoWithDetails>> GetBrandsWithDetails([FromQuery] BrandParams brandParams)
        {
            var query = _storeContext.Brands
                .Search(brandParams.SearchTerm)
                .IncludedSort(brandParams.OrderBy);
            var brands = await PagedList<Brand>.ToPagedList(query, brandParams.PageNumber, brandParams.PageSize);
            var mappedBrands = _mapper.Map<List<BrandDtoWithDetails>>(brands);
            return Ok(mappedBrands);
        }


        [HttpGet("GetBrands")]
        public async Task<ActionResult<BrandDto>> GetBrands([FromQuery] BrandParams brandParams)
        {
            var query = _storeContext.Brands
                .Search(brandParams.SearchTerm);
            var brands = await PagedList<Brand>.ToPagedList(query, brandParams.PageNumber, brandParams.PageSize);
            var mappedBrands = _mapper.Map<List<BrandDto>>(brands);
            return Ok(mappedBrands);
        }


        [HttpGet("GetBrand/{Id}")]
        public async Task<ActionResult> GetBrand(int Id)
        {
            var brand = await _storeContext.Brands.FindAsync(Id);
            if (brand == null) return NotFound();
            var mappedBrand = _mapper.Map<BrandDto>(brand);
            return Ok(mappedBrand);
        }

    }
}
