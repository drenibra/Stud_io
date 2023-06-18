import React, { useEffect, useState } from 'react';
import agent from '../../api/payment_agents';
import './payments.scss';
import Button from '../../components/Button/Button';
import Menu from '../../components/Menu/Menu';
import { Table, TableHead, TableBody, TableRow, TableCell, Box, TextField, Grid, Typography } from '@mui/material';

export default function PaymentsTable() {
  const [payments, setPayments] = useState([]);
  const [customerNames, setCustomerNames] = useState({});
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(10);
  const [nameFilter, setNameFilter] = useState('');
  const [descriptionFilter, setDescriptionFilter] = useState('');
  const [monthFilter, setMonthFilter] = useState('');

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
    const customerName = customerNames[row.customerId] || '';
    const description = row.description || '';
    const month = row.month || '';

    return (
      customerName.toLowerCase().includes(nameFilter.toLowerCase()) && description.toLowerCase().includes(descriptionFilter.toLowerCase()) && month.toLowerCase().includes(monthFilter.toLowerCase())
    );
  });

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = filteredPayments.slice(indexOfFirstItem, indexOfLastItem);

  const totalPages = Math.ceil(filteredPayments.length / itemsPerPage);

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      <div className="payments-show">
        <Grid container spacing={2} justifyContent="center" marginBottom={2}>
          <Grid item xs={12}>
            <Typography
              variant="h4"
              gutterBottom
              sx={{
                fontFamily: 'Poppins',
                marginTop: '1em',
                textAlign: 'center',
              }}
            >
              Historia e pagesave
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={5} justifyContent="center" marginBottom={4}>
          <Grid item>
            <TextField label="Emri" value={nameFilter} onChange={handleNameFilterChange} variant="outlined" size="small" fullWidth />
          </Grid>
          <Grid item>
            <TextField label="Përshkrimi" value={descriptionFilter} onChange={handleDescriptionFilterChange} variant="outlined" size="small" fullWidth />
          </Grid>
          <Grid item>
            <TextField label="Muaji" value={monthFilter} onChange={handleMonthFilterChange} variant="outlined" size="small" fullWidth />
          </Grid>
        </Grid>
        <Table sx={{ marginTop: '2rem', maxWidth: '60%', marginLeft: '20%' }}>
          <TableHead>
            <TableRow sx={{ background: '#c62828' }}>
              <TableCell sx={{ color: 'white', fontWeight: 'bold', width: '20%' }}>Studenti</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold', width: '30%' }}>Përshkrimi</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold', width: '15%' }}>Shuma</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold', width: '15%' }}>Muaji</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold', width: '20%' }}>Data e pagesës</TableCell>
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
                  {new Date(row.dateOfPayment).toLocaleString('en-GB', {
                    year: 'numeric',
                    month: '2-digit',
                    day: '2-digit',
                    hour: '2-digit',
                    minute: '2-digit',
                    second: '2-digit',
                  })}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>

        {/* Pagination controls */}
        <Grid container spacing={2} justifyContent="center" alignItems="center" marginTop={1} marginBottom={3}>
          <Grid item>
            <Button onClick={() => handlePageChange(currentPage - 1)} disabled={currentPage === 1} text="Previous" />
          </Grid>
          <Grid item>
            <span>
              {currentPage} / {totalPages === 0 ? 1 : totalPages}
            </span>
          </Grid>
          <Grid item>
            <Button onClick={() => handlePageChange(currentPage + 1)} disabled={currentPage === totalPages} text="Next" />
          </Grid>
        </Grid>
      </div>
    </div>
  );
}
