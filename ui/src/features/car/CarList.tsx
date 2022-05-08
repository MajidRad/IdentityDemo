import {
  Box,
  Card,
  CardContent,
  CardMedia,
  Grid,
  Typography,
} from "@mui/material";
import React, { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { carSelector, getCars } from "./carSlice";
import { Link as RouterLink } from "react-router-dom";
import CarItem from "./CarItem";
const CarList = () => {
  const dispatch = useAppDispatch();
  const cars = useAppSelector(carSelector.selectAll);
  useEffect(() => {
    dispatch(getCars());
  }, [dispatch]);
  return (
    <Grid container item spacing={2}>
      {cars.map((item) => (
        <CarItem car={item} key={item.id} />
      ))}
    </Grid>
  );
};

export default CarList;
