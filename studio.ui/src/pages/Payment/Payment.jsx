import React, { useEffect, useState } from "react";
import agent from "../../api/payment_agents";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import {
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  TextField,
  FormControl,
  Select,
  MenuItem,
  Box,
  Grid,
  Button,
  Typography,
} from "@mui/material";
import Menu from "../../components/Menu/Menu";

const Payment = () => {
  const [pagesa, setPagesa] = useState({
    customerId: "",
    receiptEmail: "fs51701@ubt-uni.net",
    description: "",
    currency: "eur",
    amount: "",
    month: "",
  });

  const [latestPayment, setLatestPayment] = useState(null);

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setPagesa((prev) => {
      if (name === "month") {
        return {
          ...prev,
          [name]: value,
        };
      } else {
        return {
          ...prev,
          [name]: value,
          amount:
            typeOfPayments.find((payment) => payment.type === value)?.price ||
            "",
        };
      }
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.Payment.create(pagesa)
      .then((newPayment) => {
        setLatestPayment(newPayment);
        toast.success("Pagesa u krye me sukses");
      })
      .catch(function (error) {
        toast.error("Pagesa nuk u realizua!");
      });
  };

  const [typeOfPayments, setTypeOfPayments] = useState([]);

  useEffect(() => {
    agent.TypeOfPayments.get().then((response) => {
      setTypeOfPayments(response);
    });
  }, []);

  const currentDate = new Date();

  const isMonthDisabled = (monthIndex) => {
    const currentMonthIndex = currentDate.getMonth();
    const currentDay = currentDate.getDate();

    const previousMonthIndex = (currentMonthIndex + 11) % 12; // Calculate the previous month index

    const isWithinPreviousRange =
      (currentMonthIndex === monthIndex &&
        currentDay >= 27 &&
        currentDay <= 31) ||
      (previousMonthIndex + 1 === monthIndex &&
        currentDay >= 1 &&
        currentDay <= 7);

    return !isWithinPreviousRange;
  };

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      <Grid container justifyContent="center" marginTop={4}>
        <Grid item xs={12} sm={6}>
          <Box textAlign="center">
            <Typography
              variant="h4"
              gutterBottom
              style={{ fontFamily: "Poppins", marginBottom: " 1em" }}
            >
              Kryej pagesën
            </Typography>
          </Box>
          <Box width="400px" margin="auto">
            <form onSubmit={handleSubmit}>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <TextField
                    type="text"
                    name="customerId"
                    label="Numri personal"
                    variant="outlined"
                    onChange={handleChange}
                    fullWidth
                    size="small"
                    required
                  />
                </Grid>
                <Grid item xs={12}>
                  <FormControl variant="outlined" fullWidth required>
                    <Select
                      name="description"
                      value={pagesa.description}
                      onChange={handleChange}
                      displayEmpty
                      size="small"
                      sx={{ fontStyle: "normal" }}
                    >
                      <MenuItem disabled value="">
                        <Typography sx={{ fontStyle: "normal" }}>
                          Tipi i pagesës
                        </Typography>
                      </MenuItem>
                      {typeOfPayments.map((typeOfPayment) => (
                        <MenuItem
                          key={typeOfPayment.type}
                          value={typeOfPayment.type}
                        >
                          {typeOfPayment.type}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    type="text"
                    name="amount"
                    label="Shuma për pagesë"
                    variant="outlined"
                    size="small"
                    value={
                      pagesa.amount !== ""
                        ? `${(pagesa.amount / 100).toFixed(2)} €`
                        : ""
                    }
                    disabled
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12}>
                  <FormControl variant="outlined" fullWidth required>
                    <Select
                      name="month"
                      value={pagesa.month}
                      onChange={handleChange}
                      size="small"
                      displayEmpty
                    >
                      <MenuItem disabled value="">
                        <Typography sx={{ fontStyle: "normal" }}>
                          Zgjedh muajin
                        </Typography>
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(0)} value="Janar">
                        Janar
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(1)} value="Shkurt">
                        Shkurt
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(2)} value="Mars">
                        Mars
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(3)} value="Prill">
                        Prill
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(4)} value="Maj">
                        Maj
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(5)} value="Qershor">
                        Qershor
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(6)} value="Korrik">
                        Korrik
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(7)} value="Gusht">
                        Gusht
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(8)} value="Shtator">
                        Shtator
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(9)} value="Tetor">
                        Tetor
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(10)} value="Nëntor">
                        Nëntor
                      </MenuItem>
                      <MenuItem disabled={isMonthDisabled(11)} value="Dhjetor">
                        Dhjetor
                      </MenuItem>
                    </Select>
                  </FormControl>
                </Grid>
                <Grid item xs={12}>
                  <Button
                    type="submit"
                    variant="contained"
                    color="primary"
                    fullWidth
                  >
                    Paguaj
                  </Button>
                </Grid>
              </Grid>
            </form>
          </Box>
          <ToastContainer />
        </Grid>
      </Grid>
      {latestPayment && (
        <Table sx={{ marginTop: "2rem", maxWidth: "60%", marginLeft: "20%" }}>
          <TableHead>
            <TableRow sx={{ background: "#c62828" }}>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Studenti
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Përshkrimi
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Shuma
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Muaji
              </TableCell>
              <TableCell sx={{ color: "white", fontWeight: "bold" }}>
                Data e pagesës
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow key={latestPayment.id}>
              <TableCell>{latestPayment.customerId}</TableCell>
              <TableCell>{latestPayment.description}</TableCell>
              <TableCell>
                {(latestPayment.amount * 0.01).toFixed(2)} €
              </TableCell>
              <TableCell>{latestPayment.month}</TableCell>
              <TableCell>
                {new Date(latestPayment.dateOfPayment).toLocaleString("en-GB", {
                  year: "numeric",
                  month: "2-digit",
                  day: "2-digit",
                  hour: "2-digit",
                  minute: "2-digit",
                  second: "2-digit",
                })}
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      )}
    </div>
  );
};

export default Payment;