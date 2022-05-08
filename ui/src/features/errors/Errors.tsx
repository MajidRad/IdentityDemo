import { List, ListItem } from "@mui/material";
import React from "react";
import { red } from "@mui/material/colors";
interface Props {
  errors: string[];
}
const Errors = ({ errors }: Props) => {
  return (
    <List sx={{ backgroundColor: `${red[50]}` }}>
      {errors.map((error, index) => (
        <ListItem key={index} sx={{ color: `${red[300]}` }}>
          {error}
        </ListItem>
      ))}
    </List>
  );
};

export default Errors;
