import { createTheme } from "@mui/material";
import { red } from "@mui/material/colors";

export default createTheme({
  palette: {
    primary: {
      main: '#BF1A2F',
    },
    secondary: {
      main: '#BF1A2F',
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
  overrides: {
    MuiButton: {
      containedPrimary: {
        color: '#fff',
        backgroundColor: '#BF1A2F',
      },
    },
  },
});
