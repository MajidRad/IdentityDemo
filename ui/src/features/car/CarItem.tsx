import { Card, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import React from "react";
import { Car } from "../../app/model/Car";
interface Props {
  car: Car;
}
const CarItem = ({ car }: Props) => {
  return (
    <Grid item xs={12} sm={6} md={3}>
      <Card>
        <CardMedia image="/images/car6.jpg" height="150" component="img" />
        <CardContent>
          <Typography variant="h5" component={RouterLink} to={`/${car.id}`}>
            {car.name}
          </Typography>
          <Typography variant="h6" component="div">
            {car.brand.name}
          </Typography>
          <Typography variant="body1">{car.createdDate.toString()}</Typography>
        </CardContent>
      </Card>
    </Grid>
  );
};

export default CarItem;
