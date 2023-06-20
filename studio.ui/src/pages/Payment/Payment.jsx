import React, { useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import agent from '../../api/payment_agents';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Table, TableHead, TableBody, TableRow, TableCell, TextField, FormControl, Paper, Select, MenuItem, Box, Grid, Button, Typography } from '@mui/material';
import Menu from '../../components/Menu/Menu';
import { useStore } from '../../stores/store';
import LoadingComponent from '../LoadingComponent/LoadingComponent';
import { Link } from 'react-router-dom';

const Payment = observer(function Payment() {
  const [loading, setLoading] = useState(true);
  const [typeOfPayments, setTypeOfPayments] = useState([]);
  const [paymentsHistory, setPaymentsHistory] = useState([]);
  const { userStore } = useStore();

  const [payment, setPayment] = useState({
    customerId: '',
    receiptEmail: 'fs51701@ubt-uni.net',
    description: '',
    currency: 'eur',
    amount: '',
    month: '',
  });

  const [latestPayment, setLatestPayment] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      const student = await userStore.getStudent();
      if (student) {
        setPayment({ ...payment, customerId: student.customerId });
      }
      const payments = await userStore.getPayments(student.customerId);
      setPaymentsHistory(payments);
      console.log(payments);
      setLoading(false);
    };
    fetchUser();
  }, [latestPayment]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    const selectedPayment = typeOfPayments.find((payment) => payment.type === value);
    const updatedPayment = {
      ...payment,
      [name]: value,
    };

    if (name === 'description') {
      updatedPayment.amount = selectedPayment?.price || '';
    }

    setPayment(updatedPayment);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(payment);

    agent.Payment.create(payment)
      .then((newPayment) => {
        setLatestPayment(newPayment);
        toast.success('Pagesa u krye me sukses');
      })
      .catch(function (error) {
        toast.error('Pagesa nuk u realizua!');
      });
  };

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

    const isWithinPreviousRange = (currentMonthIndex === monthIndex && currentDay >= 27 && currentDay <= 31) || (previousMonthIndex + 1 === monthIndex && currentDay >= 1 && currentDay <= 7);

    return !isWithinPreviousRange;
  };

  if (loading) return <LoadingComponent />;

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      {payment.customerId ? (
        <Grid container justifyContent="center" marginTop={4}>
          <Grid item xs={12} sm={6}>
            <Box textAlign="center">
              <Typography variant="h4" gutterBottom style={{ fontFamily: 'Poppins', marginBottom: ' 1em' }}>
                Kryej pagesën
              </Typography>
            </Box>
            <Box width="400px" margin="auto">
              <form onSubmit={handleSubmit}>
                <Grid container spacing={2}>
                  {/*                 <Grid item xs={12}>
                  <TextField
                    type="text"
                    name="customerId"
                    variant="outlined"
                    label="Customer Id"
                    value={customerIdOfUser} // Set the default value
                    onChange={handleChange}
                    disabled
                    fullWidth
                    size="small"
                  />
                </Grid> */}
                  <Grid item xs={12}>
                    <FormControl variant="outlined" fullWidth required>
                      <Select name="description" value={payment.description} onChange={handleChange} displayEmpty size="small" sx={{ fontStyle: 'normal' }}>
                        <MenuItem disabled value="">
                          <Typography sx={{ fontStyle: 'normal' }}>Tipi i pagesës</Typography>
                        </MenuItem>
                        {typeOfPayments.map((typeOfPayment) => (
                          <MenuItem key={typeOfPayment.type} value={typeOfPayment.type}>
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
                      value={payment.amount !== '' ? `${(payment.amount / 100).toFixed(2)} €` : ''}
                      disabled
                      fullWidth
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <FormControl variant="outlined" fullWidth required>
                      <Select name="month" value={payment.month} onChange={handleChange} size="small" displayEmpty>
                        <MenuItem disabled value="">
                          <Typography sx={{ fontStyle: 'normal' }}>Zgjedh muajin</Typography>
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
                    <Button type="submit" variant="contained" color="primary" fullWidth>
                      Paguaj
                    </Button>
                  </Grid>
                </Grid>
              </form>
            </Box>
            <ToastContainer />
          </Grid>
        </Grid>
      ) : (
        <Box width="400px" margin="auto">
          <Grid
            container
            style={{
              marginTop: '2em',
              backgroundColor: '#f5f5f5',
              padding: '16px',
              justifyContent: 'center',
              fontSize: '20px',
              fontWeight: 'bold',
            }}
          >
            {'Ju nuk keni kartelë!'}
            <Button
              variant="contained"
              color="primary"
              sx={{
                marginTop: '15px',
              }}
            >
              <Link to="/RegisterCustomer" style={{ color: '#FFFFFF' }}>
                Regjistro Kartelën
              </Link>
            </Button>
          </Grid>
        </Box>
      )}
      {paymentsHistory.length > 0 && (
        <Table sx={{ marginTop: '2rem', maxWidth: '60%', marginLeft: '20%' }}>
          <TableHead>
            <TableRow sx={{ background: '#c62828' }}>
              <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Studenti</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Përshkrimi</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Shuma</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Muaji</TableCell>
              <TableCell sx={{ color: 'white', fontWeight: 'bold' }}>Data e pagesës</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {paymentsHistory.map((paymentItem) => {
              return (
                <TableRow key={paymentItem.id}>
                  <TableCell>
                    {userStore.student.firstName} {userStore.student.lastName}
                  </TableCell>
                  <TableCell>{paymentItem.description}</TableCell>
                  <TableCell>{(paymentItem.amount * 0.01).toFixed(2)} €</TableCell>
                  <TableCell>{paymentItem.month}</TableCell>
                  <TableCell>
                    {new Date(paymentItem.dateOfPayment).toLocaleString('en-GB', {
                      year: 'numeric',
                      month: '2-digit',
                      day: '2-digit',
                      hour: '2-digit',
                      minute: '2-digit',
                      second: '2-digit',
                    })}
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      )}
    </div>
  );
});

export default Payment;
