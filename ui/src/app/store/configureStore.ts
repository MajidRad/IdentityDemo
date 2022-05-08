import { configureStore } from "@reduxjs/toolkit";
import { useDispatch, TypedUseSelectorHook, useSelector } from "react-redux";
import { accountSlice } from "../../features/account/accountSlice";
import { brandSlice } from "../../features/brand/brandSlice";
import { carSlice } from "../../features/car/carSlice";
import { errorSlice } from "../../features/errors/errorSlice";
export const store = configureStore({
  reducer: {
    account: accountSlice.reducer,
    car: carSlice.reducer,
    error: errorSlice.reducer,
    brand: brandSlice.reducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
