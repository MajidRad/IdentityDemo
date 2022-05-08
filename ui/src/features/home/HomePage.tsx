import { Box, Grid } from "@mui/material";
import React from "react";
import CarList from "../car/CarList";

const HomePage = () => {
  return (
    <Grid container spacing={2} sx={{ mt: 5 }}>
      <Grid item sm={9} xs={12}>
        <CarList />
      </Grid>
      <Grid item sm={3} xs={12}>
        <Box sx={{ display: "flex", background: "red", height: "100vh" }}></Box>
      </Grid>
    </Grid>
  );
};

export default HomePage;
