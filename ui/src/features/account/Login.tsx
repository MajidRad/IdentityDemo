import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import {
  Typography,
  Grid,
  Paper,
  Box,
  Avatar,
  TextField,
  FormControlLabel,
  Checkbox,
  Link,
} from "@mui/material";
import { Link as RouterLink, useNavigate } from "react-router-dom";
import agent from "../../app/api/agent";
import { FieldValue, FieldValues, useForm } from "react-hook-form";
import { LoadingButton } from "@mui/lab";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useAppDispatch } from "../../app/store/configureStore";
import { signInUser } from "./accountSlice";

function Copyright(props: any) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
      {"Copyright © "}
      <Link color="inherit" href="#">
        CarShop
      </Link>{" "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}

export default function Login() {
  const dispatch = useAppDispatch();
  let navigate = useNavigate();
  const schema = yup.object({
    username: yup.string().required(),
    password: yup.string().required(),
  });
  const {
    handleSubmit,
    register,
    formState: { isSubmitting, errors, isValid },
  } = useForm({ resolver: yupResolver(schema), mode: "all" });

  async function submitForm(data: FieldValues) {
    await dispatch(signInUser(data));
    navigate("/");
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
            Sign in
          </Typography>
          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit(submitForm)}
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              fullWidth
              autoComplete="email"
              autoFocus
              helperText={errors.username?.message}
              {...register("username")}
            />
            <TextField
              margin="normal"
              fullWidth
              type="password"
              helperText={errors.password?.message}
              autoComplete="current-password"
              {...register("password")}
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
              Sign In
            </LoadingButton>
            <Grid container>
              <Grid item>
                <Typography
                  variant="body1"
                  component={RouterLink}
                  to="/register"
                >
                  {"Don't have an account? Sign Up"}
                </Typography>
              </Grid>
            </Grid>
            <Copyright sx={{ mt: 5 }} />
          </Box>
        </Box>
      </Grid>
    </Grid>
  );
}
