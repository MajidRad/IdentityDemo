import { Box, Button } from "@mui/material";

import { Link as RouterLink } from "react-router-dom";

const AnonymousMenu = () => {
  return (
    <Box>
      <Button
        color="inherit"
        sx={{ mx: 2 }}
        component={RouterLink}
        to="/Register"
      >
        Register
      </Button>
      <Button color="inherit" component={RouterLink} to="/Login">
        Login
      </Button>
    </Box>
  );
};

export default AnonymousMenu;
