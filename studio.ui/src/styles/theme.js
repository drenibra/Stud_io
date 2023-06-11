import { createTheme } from "@mui/material";
import { red } from "@mui/material/colors";

export default createTheme({
  palette: {
    primary: {
      main: '#BF1A2F',
    },
    secondary: {
      main: '#19857b',
    },
    error: {
      main: red.A400,
    },
    danger: {
      500: '#19857b',
    },
    background: {
      default: '#fff',
    },
  },
});