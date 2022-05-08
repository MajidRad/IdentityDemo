import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { FieldValues } from "react-hook-form";
import { User } from "../../app/model/User";
import agent from "../../app/api/agent";
import { toast } from "react-toastify";
import { history } from "../../app/history";

interface AccountState {
  User: User | null;
}
const initialState: AccountState = {
  User: null,
};

export const signInUser = createAsyncThunk<User, FieldValues>(
  "account/signInUser",
  async (data, thunkAPI) => {
    try {
      const user = await agent.Account.login(data);
      localStorage.setItem("user", JSON.stringify(user));
      return user;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  }
);

export const registerUser = createAsyncThunk<void, FieldValues>(
  "accout/registerUser",
  async (data, thunkAPI) => {
    try {
      await agent.Account.register(data);
    } catch (err: any) {
      return thunkAPI.rejectWithValue({ error: err.data });
    }
  }
);

export const fetchCurrentUser = createAsyncThunk<User>(
  "account/currentUser",
  async (_, thunkAPI) => {
    thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem("user")!)));
    try {
      const user = await agent.Account.currentUser();
      localStorage.setItem("user", JSON.stringify(user));
      return user;
    } catch (error: any) {
      return thunkAPI.rejectWithValue({ error: error.data });
    }
  },
  {
    condition: () => {
      if (!localStorage.getItem("user")) return false;
    },
  }
);

export const accountSlice = createSlice({
  name: "account",
  initialState: initialState,
  reducers: {
    signOut: (state) => {
      state.User = null;
      localStorage.removeItem("user");
      history.push("/");
    },
    setUser: (state, action) => {
      state.User = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchCurrentUser.rejected, (state) => {
      state.User = null;
      localStorage.removeItem("user");
      toast.error("session expired please login again");
      history.push("/");
    });
    builder.addCase(signInUser.rejected, (state, action) => {
      console.log(action.error);
    });
    builder.addMatcher(
      isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled),
      (state, action) => {
        state.User = action.payload;
      }
    );

   
  },
});
export const { signOut, setUser } = accountSlice.actions;
