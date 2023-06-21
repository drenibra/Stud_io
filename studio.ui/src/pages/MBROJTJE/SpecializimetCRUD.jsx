import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, TextField, Typography, Container, Grid } from '@mui/material';

const SpecializimiPage = () => {
  const [specializimet, setSpecializimet] = useState([]);
  const [newSpecializimi, setNewSpecializimi] = useState('');

  useEffect(() => {
    fetchSpecializimet();
  }, []);

  const fetchSpecializimet = async () => {
    try {
      const response = await axios.get('https://localhost:7119/api/Specializimi/get-specializimet');
      setSpecializimet(response.data);
    } catch (error) {
      console.error('Error fetching specializimet:', error);
    }
  };

  const addSpecializimi = async () => {
    try {
      const response = await axios.post('https://localhost:7119/api/Specializimi/add-specializim', {
        name: newSpecializimi,
      });
      console.log(response.data);
      setNewSpecializimi('');
      fetchSpecializimet();
    } catch (error) {
      console.error('Error adding specializimin:', error);
    }
  };

  const deleteSpecializimi = async (id) => {
    try {
      const response = await axios.delete(`https://localhost:7119/api/Specializimi/delete-specializim?id=${id}`);
      console.log(response.data);
      fetchSpecializimet();
    } catch (error) {
      console.error('Error deleting specializimin:', error);
    }
  };

  const updateSpecializimin = async (id, updatedName) => {
    try {
      const response = await axios.put(`https://localhost:7119/api/Specializimi/update-specializimin`, {
        id: id,
        name: updatedName,
      });
      console.log(response.data);
      fetchSpecializimet();
    } catch (error) {
      console.error('Error updating specializimin:', error);
    }
  };

  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        Specializimet
      </Typography>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField label="New Specializim" value={newSpecializimi} onChange={(e) => setNewSpecializimi(e.target.value)} fullWidth />
          <Button variant="contained" onClick={addSpecializimi}>
            Add Specializim
          </Button>
        </Grid>
        <Grid item xs={12}>
          {specializimet.map((specializimi) => (
            <div key={specializimi.id}>
              <Typography>{specializimi.name}</Typography>
              <Button variant="contained" onClick={() => deleteSpecializimi(specializimi.id)}>
                Delete
              </Button>
              <TextField
                label="New Name"
                value={specializimi.updatedName || ''}
                onChange={(e) => {
                  const updatedSpecializimet = [...specializimet];
                  const updatedSpecializim = { ...specializimi, updatedName: e.target.value };
                  updatedSpecializimet.splice(updatedSpecializimet.indexOf(specializimi), 1, updatedSpecializim);
                  setSpecializimet(updatedSpecializimet);
                }}
              />
              <Button variant="contained" onClick={() => updateSpecializimin(specializimi.id, specializimi.updatedName)}>
                Update
              </Button>
            </div>
          ))}
        </Grid>
      </Grid>
    </Container>
  );
};

export default SpecializimiPage;
