import {
  Box,
  Button,
  ButtonGroup,
  Grid,
  IconButton,
  TextField,
  Typography,
} from "@mui/material";
import SearchButton from "../../app/layout/Searchbar/SearchButton";
import CloseIcon from "@mui/icons-material/Close";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { deselectBrand } from "../brand/brandSlice";
const RegisterCar = () => {
  const { selectedBrand } = useAppSelector((state) => state.brand);
  const dispatch = useAppDispatch();
  return (
    <Grid
      container
      spacing={2}
      direction="row"
      width="75%"
      sx={{
        display: "flex",
        position: "absolute",
        top: "50%",
        left: "50%",
        transform: "translate(-50%,-50%)",
        p: 5,
        div: { mb: 1 },
        boxShadow: "rgba(99, 99, 99, 0.2) 0px 2px 8px 0px",
        borderRadius: "5px",
        // p: 10,
      }}
    >
      <Grid item xs={12} md={6}>
        <Box component="div">
          <TextField placeholder="Car Name" fullWidth />
          <TextField placeholder="Created Date" type="date" fullWidth />
          {selectedBrand === null && <SearchButton label="Select Car Brand" />}
          {selectedBrand && (
            <Box display="flex" alignItems="center">
              <IconButton
                color="warning"
                size="large"
                onClick={() => dispatch(deselectBrand())}
              >
                <CloseIcon />
              </IconButton>
              <Typography>Brand: {selectedBrand?.name}</Typography>
            </Box>
          )}
        </Box>
      </Grid>

      <Grid item xs={12} md={6}>
        <Box>
          <TextField type="file" fullWidth />
        </Box>
      </Grid>

      <Grid item xs={12}>
        <ButtonGroup fullWidth>
          <Button>RegisterCar</Button>
          <Button>Cancel</Button>
        </ButtonGroup>
      </Grid>
    </Grid>
  );
};

export default RegisterCar;
