import { yupResolver } from "@hookform/resolvers/yup";
import { Copyright } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import {
  Grid,
  Paper,
  Box,
  Avatar,
  Typography,
  TextField,
  FormControlLabel,
  Checkbox,
} from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";

import { useForm, FieldValues } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { useAppDispatch } from "../../app/store/configureStore";
import { signInUser } from "./accountSlice";
import * as yup from "yup";
import agent from "../../app/api/agent";
import { useState } from "react";
import Errors from "../errors/Errors";

const Register = () => {
  const schema = yup.object({
    email: yup.string().required(),
    username: yup.string().required(),
    password: yup.string().required(),
    confirmPassword: yup
      .string()
      .oneOf([yup.ref("password"), null], "Password must match"),
  });
  const [validationError, setValidationError] = useState([]);

  const {
    handleSubmit,
    register,
    setError,
    formState: { isValid, isSubmitting, errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "all",
    criteriaMode: "all",
  });

  function handleApiErrors(errors: any) {
    if (errors) {
      errors.forEach((error: string) => {
        if (error.includes("Password")) {
          setError("password", { message: error }, { shouldFocus: true });
        } else if (error.includes("Email")) {
          setError("email", { message: error }, { shouldFocus: true });
        } else if (error.includes("Username")) {
          setError("username", { message: error }, { shouldFocus: true });
        }
      });
    }
  }
  return (
    <Grid
      container
      component="main"
      sx={{ height: "93vh", mt: "7vh", overflow: "hidden" }}
    >
      <Grid
        item
        xs={false}
        sm={4}
        md={7}
        sx={{
          backgroundImage: `url(${
            process.env.PUBLIC_URL + "/images/car7.jpg"
          })`,
          backgroundRepeat: "no-repeat",
          backgroundColor: (t) =>
            t.palette.mode === "light"
              ? t.palette.grey[50]
              : t.palette.grey[900],
          backgroundSize: "cover",
          backgroundPosition: "center",
        }}
      />
      <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
        <Box
          sx={{
            my: 8,
            mx: 4,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign Up
          </Typography>
          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit((data) =>
              agent.Account.register(data).catch((err) => handleApiErrors(err))
            )}
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              fullWidth
              autoComplete="email"
              autoFocus
              helperText={errors.email?.message}
              {...register("email")}
              label="Email"
            />
            <TextField
              margin="normal"
              fullWidth
              helperText={errors.username?.message}
              {...register("username")}
              label="Username"
            />
            <TextField
              margin="normal"
              fullWidth
              type="password"
              helperText={errors.password?.message}
              autoComplete="current-password"
              {...register("password")}
              label="Password"
            />
            <TextField
              margin="normal"
              fullWidth
              type="password"
              helperText={errors.confirmPassword?.message}
              autoComplete="current-password"
              {...register("confirmPassword")}
              label="Confirm Password"
            />

            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="Remember me"
            />
            <LoadingButton
              loading={isSubmitting}
              type="submit"
              fullWidth
              variant="contained"
              disabled={!isValid}
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </LoadingButton>
            <Grid container>
              <Grid item>
                <Typography variant="body1" component={RouterLink} to="/login">
                  {"Already have an account? Sign In"}
                </Typography>
              </Grid>
            </Grid>
            <Copyright sx={{ mt: 5 }} />
          </Box>
        </Box>
      </Grid>
    </Grid>
  );
};

export default Register;
