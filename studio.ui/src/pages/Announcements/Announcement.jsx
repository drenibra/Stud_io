import React, { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import { Button } from '@mui/material';
import axios from 'axios';
import './styles.scss';
import { TextField, Box } from '@mui/material';
import { Link } from 'react-router-dom';
import Menu from '../../components/Menu/Menu';

export default function Announcement() {
  const [announcement, setAnnouncement] = useState({
    title: '',
    description: '',
    deadlineId: '',
  });

  const handleChange = (e) => {
    const newData = { ...announcement };
    newData[e.target.id] = e.target.value;
    setAnnouncement(newData);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7137/api/Announcement/add-announcement', announcement);
      console.log(response.data);
      toast.success('Shpallja u shtua me sukses!');
    } catch (error) {
      if (error.response) {
        // The request was made and the server responded with a status code
        console.error('Server Error:', error.response.status);
        console.error('Response Data:', error.response.data);
      } else if (error.request) {
        // The request was made but no response was received
        console.error('No response received:', error.request);
      } else {
        // Something happened in setting up the request that triggered an error
        console.error('Request Error:', error.message);
      }
      toast.error('An error occurred while adding the announcement.');
    }
  };

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      <div>
        <h2 className="title-hapja-konkursit">Hapja e Konkursit</h2>
        <div className="hapja-konkursit">
          <div className="deadline-konkursi">
            <form onSubmit={(e) => handleSubmit(e)} className="form-konkursi">
              <TextField label="Title" name="title" id="title" value={announcement.title} onChange={handleChange} variant="outlined" fullWidth required margin="normal" sx={{ marginBottom: '8px' }} />
              <TextField
                label="Description"
                name="description"
                id="description"
                value={announcement.description}
                onChange={handleChange}
                variant="outlined"
                fullWidth
                required
                margin="normal"
                sx={{ marginBottom: '8px' }}
              />
              <TextField
                label="DeadlineId"
                name="deadlineId"
                id="deadlineId"
                value={announcement.deadlineId}
                onChange={handleChange}
                required
                variant="outlined"
                fullWidth
                margin="normal"
                sx={{ marginBottom: '8px' }}
              />
              <Button variant="contained" color="primary" type="submit" className="butoni-konkursi">
                Submit
              </Button>{' '}
              <br />
              <div>
                <Link to="/deadline" className="link-anouncement">
                  Back
                </Link>
                <Link to="/AnnouncementTable" className="link-aplikimet">
                  Gjenero konkurset
                </Link>
              </div>
            </form>
            <ToastContainer />
          </div>
        </div>
      </div>
    </div>
  );
}
