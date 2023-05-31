import React, { useEffect, useState } from "react";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Logo from "../../assets/logo/icon-color-stud-io.svg";
import agent from "../../api/payment_agents";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const theme = createTheme({
  palette: {
    primary: {
      main: "#c62828",
    },
  },
});

const PaymentForm = () => {
  const [client, setClient] = useState({
    email: "",
    name: "",
    creditCard: {
      cardNumber: "",
      expirationYear: "",
      expirationMonth: "",
      cvc: "",
    },
  });

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setClient((prev) => {
      return {
        ...prev,
        [name]: value,
        creditCard: {
          ...prev.creditCard,
          [name]: value,
        },
      };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const newClient = {
      email: client.email,
      name: client.name,
      creditCard: {
        name: client.name,
        cardNumber: client.creditCard.cardNumber,
        expirationYear: client.creditCard.expirationYear,
        expirationMonth: client.creditCard.expirationMonth,
        cvc: client.creditCard.cvc,
      },
    };

    agent.Customers.create(newClient)
      .then(() => {
        toast.success("Të dhënat tua u ruajtën!");
      })
      .catch(function (error) {
        console.log(newClient);
        toast.error("Të dhënat tua nuk u ruajtën!");
      });
  };

  return (
    <ThemeProvider theme={theme}>
      <Box
        border={`2px solid #c62828`}
        borderRadius={2}
        p={2}
        maxWidth={500}
        marginTop={5}
        marginBottom={5}
      >
        <img
          src={Logo}
          alt="Our logo."
          style={{ width: "50px", padding: "1vw" }}
        />
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <TextField
              label="Name"
              variant="outlined"
              size="small"
              fullWidth
              name="name"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              label="Email"
              variant="outlined"
              size="small"
              fullWidth
              name="email"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              label="Card Number"
              variant="outlined"
              size="small"
              fullWidth
              name="cardNumber"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              label="Expiration Month"
              variant="outlined"
              size="small"
              fullWidth
              name="expirationMonth"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              label="Expiration Year"
              variant="outlined"
              size="small"
              fullWidth
              name="expirationYear"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              label="CVC"
              variant="outlined"
              size="small"
              fullWidth
              name="cvc"
              onChange={handleChange}
            />
          </Grid>
          <Grid item xs={12}>
            <Button
              variant="contained"
              color="primary"
              fullWidth
              onClick={handleSubmit}
            >
              Pay Now
            </Button>
            <ToastContainer />
          </Grid>
        </Grid>
      </Box>
    </ThemeProvider>
  );
};

export default PaymentForm;
