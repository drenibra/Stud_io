import React, { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import TextField from '@mui/material/TextField';
import { Button, Link, Box } from '@mui/material';
import axios from 'axios';
import './DeadlineStyles.scss';
import Menu from '../../components/Menu/Menu';

export default function Deadline({ handleClose })
{
  const [error, setError] = useState(false);
  const [error2, setError2] = useState(false);

  // const [firstDate, setFirstDate] = useState('');
  // const [secondDate, setSecondDate] = useState('');
  // const [daysDifference, setDaysDifference] = useState(0);

  const [name, setName] = useState('');
  const [selectedOpenDate, setSelectedOpenDate] = useState(new Date().toISOString().slice(0, 10));
  const [selectedClosedDate, setSelectedClosedDate] = useState('');

  const formatDate = (date) =>
  {
    const offset = date.getTimezoneOffset() * 60000; // Convert offset to milliseconds
    const adjustedDate = new Date(date.getTime() - offset); // Adjust date based on offset
    return adjustedDate.toISOString().slice(0, 10); // Format the adjusted date to YYYY-MM-DD
  };

  const handleOpenDateChange = (e) =>
  {
    const selected = e.target.value;
    const today = new Date().toISOString().slice(0, 10);

    if (selected >= today)
    {
      setSelectedOpenDate(formatDate(new Date(selected)));
    } else
    {
      setError(true);
    }
  };

  const handleClosedDate = (e) =>
  {
    const selected = e.target.value;
    if (selected > selectedOpenDate)
    {
      setSelectedClosedDate(formatDate(new Date(selected)));
    } else
    {
      setError2(true);
    }
  };

  // const handleClosedDate = (e) =>
  // {
  //     const selected = e.target.value;

  //     if (selected >= selectedOpenDate)
  //     {
  //         setSelectedClosedDate(selected);
  //     }
  //     else
  //     {
  //         setError(true);
  //     }
  // }

  // const handleOpenDateChange = (e) =>
  // {
  //     const selectedOpenDate = new Date(e.target.value);
  //     const selectedClosedDate = new Date(secondDate);

  //     const timeDifference = Math.abs(selectedClosedDate - selectedOpenDate);
  //     const differenceInDays = Math.ceil(timeDifference / (1000 * 60 * 60 * 24));

  //     setDaysDifference(differenceInDays);
  //     setFirstDate(e.target.value);
  // }

  // const handleClosedDateChange = (e) =>
  // {
  //     const selectedOpenDate = new Date(firstDate);
  //     const selectedClosedDate = new Date(e.target.value);

  //     const timeDifference = Math.abs(selectedClosedDate - selectedOpenDate);
  //     const differenceInDays = Math.ceil(timeDifference / (1000 * 60 * 60 * 24));

  //     setDaysDifference(differenceInDays);
  //     setSecondDate(e.target.value);
  // }

  const handleSubmit = async (e) =>
  {
    e.preventDefault();
    const deadline = { name, selectedOpenDate, selectedClosedDate };
    try
    {
      const response = await axios.post('https://localhost:7137/api/Deadline/add-deadline', deadline);
      console.log(response.data);
      toast.success('Deadline u shtua me sukses!');
    } catch (error)
    {
      console.log(error);
      toast.error(error.response.data);
    }
  };

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      <div className="deadline">
        <h3 className="h4-deadline">Cakto nje deadline</h3>
        <form onSubmit={(e) => handleSubmit(e)} className="form-deadline">
          <TextField
            label="Name"
            name="name"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            variant="outlined"
            fullWidth
            helperText="Please select name of deadline"
            required
            margin="normal"
            sx={{ marginBottom: '8px' }}
          />

          <TextField
            name="opendate"
            id="openDate"
            value={selectedOpenDate}
            type="date"
            onChange={handleOpenDateChange}
            variant="outlined"
            required
            fullWidth
            helperText="Please select open date"
            margin="normal"
            sx={{ marginBottom: '8px' }}
            min={new Date().toISOString().slice(0, 10)}
          />
          {error ? <label className="label1">Select a valid date!</label> : ''}
          <TextField
            name="closeddate"
            id="closedDate"
            value={selectedClosedDate}
            onChange={handleClosedDate}
            type="date"
            required
            helperText="Please select closed date"
            variant="outlined"
            fullWidth
            margin="normal"
            sx={{ marginBottom: '8px' }}
          />
          {error2 ? <label className="label1">Select a valid date!</label> : ''}

          {/* <p className="daysDifference">{daysDifference} days</p> */}

          <Button variant="contained" color="primary" type="submit" className="butoni-deadline">
            Submit
          </Button>

          <br />

          <Button href="/announcement" variant="contained" color="primary" type="submit" className="butoni-deadline">
            Next
          </Button>
        </form>
        <ToastContainer />
      </div>
    </div>
  );
}
