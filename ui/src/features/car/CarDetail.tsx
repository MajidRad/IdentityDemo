import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useParams } from "react-router-dom";
import { carSelector, getCar } from "./carSlice";

import {
  RootState,
  store,
  useAppDispatch,
  useAppSelector,
} from "../../app/store/configureStore";
import { Card, CardContent, CardMedia, Typography } from "@mui/material";
const CarDetail = () => {
  const { Id = "0" } = useParams();
  const parsedId = parseInt(Id);
  const dispatch = useAppDispatch();
  let car = useAppSelector((state: RootState) =>
    carSelector.selectById(state, Id)
  );

  return (
    <Card>
      <CardMedia image="/images/car6.jpg" height="150" component="img" />
      <CardContent>
        <Typography variant="h5">{car?.name}</Typography>
        <Typography variant="h6" component="div">
          {car?.brand.name}
        </Typography>
        <Typography variant="body1">{car?.createdDate.toString()}</Typography>
      </CardContent>
    </Card>
  );
};

export default CarDetail;
