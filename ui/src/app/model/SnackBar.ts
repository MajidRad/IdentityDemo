import { SerializedError } from "@reduxjs/toolkit";

export interface SnackBar extends SerializedError {
  open: boolean;
  type: string;
}
