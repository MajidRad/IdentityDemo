import { createSlice } from "@reduxjs/toolkit";
import { SerializedError } from "@reduxjs/toolkit";
import { SnackBar } from "../../app/model/SnackBar";
const errorInitialState = {
  errors: { code: "", message: "", name: "" } as SerializedError,
};
export const errorSlice = createSlice({
  name: "erorr",
  initialState: errorInitialState,
  reducers: {
    snackBarMessage(state, action) {
      state.errors = action.payload;
      return state;
    },
  },
});
