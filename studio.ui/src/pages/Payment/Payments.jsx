import React, { useEffect, useState } from "react";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { red } from "@mui/material/colors";
import agent from "../../api/payment_agents";
import Button from "@mui/material/Button";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: red[800],
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

export default function CustomizedTables() {
  const [payments, setPayments] = useState([]);
  const [customerNames, setCustomerNames] = useState({});

  useEffect(() => {
    agent.Payments.get().then((response) => {
      setPayments(response);
    });

    agent.Customers.get().then((response) => {
      // Create a dictionary of customer IDs to customer names
      const customerNamesMap = response.reduce((map, customer) => {
        map[customer.customerId] = customer.name;
        return map;
      }, {});

      setCustomerNames(customerNamesMap);
    });
  }, []);

  return (
    <>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell>Studenti</StyledTableCell>
              <StyledTableCell>Përshkrimi</StyledTableCell>
              <StyledTableCell>Shuma</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {React.Children.toArray(
              payments.map((row) => (
                <StyledTableRow key={row.id}>
                  <StyledTableCell>
                    {customerNames[row.customerId]}
                  </StyledTableCell>
                  <StyledTableCell>{row.description}</StyledTableCell>
                  <StyledTableCell>
                    {(row.amount * 0.01).toFixed(2)} €
                  </StyledTableCell>
                </StyledTableRow>
              ))
            )}
          </TableBody>
        </Table>
      </TableContainer>
      <Button variant="contained">Kryej pagesë</Button>
    </>
  );
}
