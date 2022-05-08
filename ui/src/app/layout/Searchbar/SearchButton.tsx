import { Box, Button, Modal } from "@mui/material";
import React, { useEffect, useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import SearchBar from "./SearchBar";
import { blue } from "@mui/material/colors";
import { Brand } from "../../model/Brand";

interface Prop {
  label: string;
}

export default function ({ label }: Prop) {
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <>
      <Button startIcon={<SearchIcon />} fullWidth onClick={handleOpen}>
        {label}
      </Button>
      <Modal
        open={open}
        onClose={handleClose}
        sx={{
          backdropFilter: "blur(10px)",
          bgcolor: `rgba(10, 161, 221,0.3)`,
        }}
      >
        <Box>
          <SearchBar onClose={handleClose} />
        </Box>
      </Modal>
    </>
  );
}
