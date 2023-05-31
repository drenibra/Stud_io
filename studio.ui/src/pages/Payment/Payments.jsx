import React, { useEffect, useState } from "react";
import agent from "../../api/payment_agents";
import "./payments.scss";
import Button from "../../components/Button/Button";
import {
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  TextField,
  Grid,
} from "@mui/material";

export default function PaymentsTable() {
  const [payments, setPayments] = useState([]);
  const [customerNames, setCustomerNames] = useState({});
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(10);
  const [nameFilter, setNameFilter] = useState("");
  const [descriptionFilter, setDescriptionFilter] = useState("");
  const [monthFilter, setMonthFilter] = useState("");

  useEffect(() => {
    agent.Payments.get().then((response) => {
      setPayments(response);
    });

    agent.Customers.get().then((response) => {
      const customerNamesMap = response.reduce((map, customer) => {
        map[customer.customerId] = customer.name;
        return map;
      }, {});

      setCustomerNames(customerNamesMap);
    });
  }, []);

  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const handleNameFilterChange = (event) => {
    setNameFilter(event.target.value);
    setCurrentPage(1); // Reset to the first page when changing the filter
  };

  const handleDescriptionFilterChange = (event) => {
    setDescriptionFilter(event.target.value);
    setCurrentPage(1); // Reset to the first page when changing the filter
  };

  const handleMonthFilterChange = (event) => {
    setMonthFilter(event.target.value);
    setCurrentPage(1); // Reset to the first page when changing the filter
  };

  const filteredPayments = payments.filter((row) => {
    const customerName = customerNames[row.customerId] || "";
    const description = row.description || "";
    const month = row.month || "";

    return (
      customerName.toLowerCase().includes(nameFilter.toLowerCase()) &&
      description.toLowerCase().includes(descriptionFilter.toLowerCase()) &&
      month.toLowerCase().includes(monthFilter.toLowerCase())
    );
  });

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = filteredPayments.slice(
    indexOfFirstItem,
    indexOfLastItem
  );

  const totalPages = Math.ceil(filteredPayments.length / itemsPerPage);

  return (
    <div className="payments-show">
      <h1>Historia e pagesave</h1>
        <Grid container spacing={5} justifyContent="center" marginBottom={4} marginTop={0.5}>
          <Grid item>
            <TextField
              label="Emri"
              value={nameFilter}
              onChange={handleNameFilterChange}
              variant="outlined"
              size="small"
              fullWidth
            />
          </Grid>
          <Grid item>
            <TextField
              label="Përshkrimi"
              value={descriptionFilter}
              onChange={handleDescriptionFilterChange}
              variant="outlined"
              size="small"
              fullWidth
            />
          </Grid>
          <Grid item>
            <TextField
              label="Muaji"
              value={monthFilter}
              onChange={handleMonthFilterChange}
              variant="outlined"
              size="small"
              fullWidth
            />
          </Grid>
        </Grid>
      <Table>
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
          {currentItems.map((row) => (
            <TableRow key={row.id}>
              <TableCell>{customerNames[row.customerId]}</TableCell>
              <TableCell>{row.description}</TableCell>
              <TableCell>{(row.amount * 0.01).toFixed(2)} €</TableCell>
              <TableCell>{row.month}</TableCell>
              <TableCell>
                {new Date(row.dateOfPayment).toLocaleString("en-GB", {
                  year: "numeric",
                  month: "2-digit",
                  day: "2-digit",
                  hour: "2-digit",
                  minute: "2-digit",
                  second: "2-digit",
                })}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>

      {/* Pagination controls */}
      <div className="pagination">
        <Button
          onClick={() => handlePageChange(currentPage - 1)}
          disabled={currentPage === 1}
          text="Previous"
        />
        <span>
          {currentPage} / {totalPages === 0 ? 1 : totalPages}
        </span>
        <Button
          onClick={() => handlePageChange(currentPage + 1)}
          disabled={currentPage === totalPages}
          text="Next"
        />
      </div>
    </div>
  );
}
