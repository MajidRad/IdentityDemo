import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
  SerializedError,
} from "@reduxjs/toolkit";
import agent from "../../app/api/agent";

import { Car } from "../../app/model/Car";
import { RootState } from "../../app/store/configureStore";

interface CarState {
  car: Car | null;
}

const initialState: CarState = {
  car: null,
};

//
// ─── Adapter  ───────────────────────────────────────────────────────────────────────────
//
const carAdapter = createEntityAdapter<Car>({
  selectId: (car) => car.id,
});
export const carSelector = carAdapter.getSelectors(
  (state: RootState) => state.car
);

export const getCars = createAsyncThunk<Car[], void>(
  "car/getCars",
  async (_, thunkApi) => {
    try {
      const response = await agent.Cars.getCars();
      return response;
    } catch (err: SerializedError | any) {
      return thunkApi.rejectWithValue({ error: err.data });
    }
  }
);
export const getFilteredCars = createAsyncThunk<Car[], void>(
  "car/getFilteredCars",
  async (_, thunkApi) => {
    try {
      const cars = await agent.Cars.getFilteredCars();
      return cars;
    } catch (error: any) {
      return thunkApi.rejectWithValue({ error: error.data });
    }
  }
);

export const getCar = createAsyncThunk<Car, number>(
  "car/getCar",
  async (Id, thunkApi) => {
    try {
      const response = await agent.Cars.getCar(Id);
      return response;
    } catch (err: any) {
      return thunkApi.rejectWithValue({ error: err.data });
    }
  }
);

//
// ───CAR SLICE  ───────────────────────────────────────────────────────────────────────────
//

export const carSlice = createSlice({
  name: "car",
  initialState: carAdapter.getInitialState(initialState),
  reducers: {},
  extraReducers: (builder) => {

    builder.addCase(getCars.fulfilled, (state, action) => {
      carAdapter.setAll(state, action.payload);
    });
    
    builder.addCase(getFilteredCars.fulfilled, (state, action) => {
      carAdapter.setAll(state, action.payload);
    });
    
    builder.addCase(getCar.fulfilled, (state, action) => {
      carAdapter.setOne(state, action.payload);
    });

    builder.addCase(getCar.rejected, (state, action) => {});


  },
});
