import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from "@reduxjs/toolkit";
import { TypeOf } from "yup";
import agent from "../../app/api/agent";
import { Brand, BrandParams, OrderBy } from "../../app/model/Brand";
import { RootState } from "../../app/store/configureStore";
import { accountSlice } from "../account/accountSlice";
import { carSlice } from "../car/carSlice";

interface brandState {
  brand: Brand | null;
  selectedBrand: null | Brand;
  brandParams: BrandParams;
}

const initialState: brandState = {
  brand: null,
  selectedBrand: null,
  brandParams: {
    pageNumber: 1,
    pageSize: 5,
    orderBy: OrderBy.name,
    searchTerm: "",
  },
};

const brandAdapter = createEntityAdapter<Brand>({
  selectId: (brand) => brand.id,
});

export const brandSelector = brandAdapter.getSelectors<RootState>(
  (state: RootState) => state.brand
);
function getAxiosParams(brandParams: BrandParams) {
  const params = new URLSearchParams();
  params.append("pageNumber", brandParams.pageNumber.toString());
  params.append("pageSize", brandParams.pageSize.toString());
  if (brandParams.orderBy) params.append("orderBy", brandParams.orderBy);
  if (brandParams.searchTerm)
    params.append("searchTerm", brandParams.searchTerm);
  return params;
}
export const getBrands = createAsyncThunk<Brand[], void, { state: any }>(
  "brand/getBrands",
  async (_, thunkApi) => {
    const params = getAxiosParams(thunkApi.getState().brand.brandParams);
    try {
      var brands = await agent.Brands.getBrands(params);
      return brands;
    } catch (error: any) {
      return thunkApi.rejectWithValue({ error: error.data });
    }
  }
);

export const brandSlice = createSlice({
  name: "brand",
  initialState: brandAdapter.getInitialState(initialState),
  reducers: {
    setBrandParams: (state, action) => {
      state.brandParams = {
        ...state.brandParams,
        ...action.payload,
        pageNumber: 1,
      };
    },
    resetBrandParams: (state, action) => {
      state.brandParams = initialState.brandParams;
    },
    selectBrand: (state, action) => {
      state.selectedBrand = action.payload;
    },
    deselectBrand: (state) => {
      state.selectedBrand = null;
    },
  },
  extraReducers: (builder) =>
    builder.addCase(getBrands.fulfilled, (state, action) => {
      brandAdapter.setAll(state, action.payload);
    }),
});
export const { setBrandParams, resetBrandParams, selectBrand, deselectBrand } =
  brandSlice.actions;
