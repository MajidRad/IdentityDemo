import {
  Box,
  Divider,
  InputAdornment,
  List,
  ListItem,
  ListItemButton,
  SxProps,
  TextField,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import { blue } from "@mui/material/colors";
import { Brand } from "../../model/Brand";
import {
  brandSelector,
  getBrands,
  selectBrand,
  setBrandParams,
} from "../../../features/brand/brandSlice";
import { useAppSelector, useAppDispatch } from "../../store/configureStore";

import useDebounce from "../../hooks/useDebounce";
interface Props {
  onClose: () => void;
}
const SearchBar = ({ onClose }: Props) => {
  let brands = useAppSelector(brandSelector.selectAll);
  const dispatch = useAppDispatch();
  const [searchTerm, setSearchTerm] = useState("");
  const debouncedSearch = useDebounce(searchTerm, 1000);

  useEffect(() => {
    dispatch(setBrandParams({ searchTerm: debouncedSearch }));
    dispatch(getBrands());
  }, [debouncedSearch, dispatch]);

  const handleChange = (
    e: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>
  ) => {
    setSearchTerm(e.target.value);
  };

  const handleClick = (brand: Brand) => {
    dispatch(selectBrand(brand));
    onClose()
  };
  const style: SxProps = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%,-50%)",
    width: "40vw",
    bgcolor: `${blue[50]}`,
    borderRadius: "5px",
    p: 4,
  };
  return (
    <Box sx={style}>
      <TextField
        id="input-with-icon-textfield"
        label="Brand"
        fullWidth
        value={searchTerm}
        onChange={handleChange}
        InputProps={{
          startAdornment: (
            <InputAdornment position="start">
              <SearchIcon />
            </InputAdornment>
          ),
        }}
        variant="standard"
      />
      <List>
        {brands.map((brand) => (
          <Box key={brand.id} sx={{ display: "flex", alignItems: "center" }}>
            <ListItem>
              <ListItemButton onClick={() => handleClick(brand)}>
                {brand.name}
              </ListItemButton>
            </ListItem>
          </Box>
        ))}
      </List>
    </Box>
  );
};

export default SearchBar;
