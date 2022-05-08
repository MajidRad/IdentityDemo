import { AppBar, Button, Toolbar, Typography } from "@mui/material";
import { Link as RouterLink } from "react-router-dom";
import React from "react";
import { Box } from "@mui/system";
import AnonymousMenu from "./userMenu/AnonymousMenu";
import UserMenu from "./userMenu/UserMenu";
import { useAppSelector } from "../store/configureStore";

const Header = () => {
  const userState = useAppSelector((state) => state.account.User);

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6">CarShop</Typography>
        <Box sx={{ display: "flex", flexGrow: 1, mx: 2 }}>
          <Button color="inherit" component={RouterLink} to="/">
            List Of Cars
          </Button>
          <Button color="inherit" component={RouterLink} to="/RegisterCar">
            Register Car
          </Button>
        </Box>
        {userState !== null ? <UserMenu /> : <AnonymousMenu />}
      </Toolbar>
    </AppBar>
  );
};

export default Header;
