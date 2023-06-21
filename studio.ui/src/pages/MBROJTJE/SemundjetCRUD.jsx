import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, TableBody, TableCell, TableContainer, TableHead, MenuItem, Select, TableRow, TextField, Button } from '@mui/material';

const SemundjaPage = () => {
  const [semundjet, setSemundjet] = useState([]);
  const [newSemundje, setNewSemundje] = useState('');
  const [specializimiId, setSpecializimiId] = useState('');
  const [specializimet, setSpecializimet] = useState([]);

  useEffect(() => {
    fetchSemundjet();
    fetchSpecializimet();
  }, []);

  const fetchSemundjet = async () => {
    try {
      const response = await axios.get('https://localhost:7119/api/Semundja/get-semundjet');
      setSemundjet(response.data);
    } catch (error) {
      console.error('Error fetching semundjet:', error);
    }
  };

  const fetchSpecializimet = async () => {
    try {
      const response = await axios.get('https://localhost:7119/api/Specializimi/get-specializimet');
      setSpecializimet(response.data);
    } catch (error) {
      console.error('Error fetching specializimet:', error);
    }
  };

  const addSemundje = async () => {
    try {
      const response = await axios.post('https://localhost:7119/api/Semundja/add-semundjen', {
        Name: newSemundje,
        SpecializimiId: parseInt(specializimiId),
      });
      console.log(response.data);
      setNewSemundje('');
      setSpecializimiId('');
      fetchSemundjet();
    } catch (error) {
      console.error('Error adding Semundje:', error);
    }
  };

  const deleteSemundje = async (id) => {
    try {
      const response = await axios.delete(`https://localhost:7119/api/Semundja/delete-semundjen?id=${id}`);
      console.log(response.data);
      fetchSemundjet();
    } catch (error) {
      console.error('Error deleting semundje:', error);
    }
  };

  const updateSemundje = async (id, updatedName, updatedSpecializimiId) => {
    try {
      const response = await axios.put(`https://localhost:7119/api/Semundja/update-semundjen?id=${id}`, {
        Name: updatedName,
        SpecializimiId: parseInt(updatedSpecializimiId),
      });
      console.log(response.data);
      fetchSemundjet();
    } catch (error) {
      console.error('Error updating semundjen:', error);
    }
  };

  return (
    <div>
      <h1>Semundja Page</h1>
      <div>
        <TextField label="Name" value={newSemundje} onChange={(e) => setNewSemundje(e.target.value)} />
        <Select label="Specializimi ID" value={specializimiId} onChange={(e) => setSpecializimiId(e.target.value)}>
          {specializimet.map((specializimi) => (
            <MenuItem key={specializimi.id} value={specializimi.id}>
              {specializimi.name}
            </MenuItem>
          ))}
        </Select>
        <Button variant="contained" onClick={addSemundje}>
          Add Semundje
        </Button>
      </div>
      <TableContainer>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell>Name</TableCell>
              <TableCell>Specializimi ID</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {semundjet.map((semundje) => (
              <TableRow key={semundje.id}>
                <TableCell>{semundje.id}</TableCell>
                <TableCell>{semundje.name}</TableCell>
                <TableCell>{semundje.specializimiId}</TableCell>
                <TableCell>
                  <TextField
                    label="Updated Name"
                    value={semundje.updatedName || ''}
                    onChange={(e) => {
                      const updatedSemundjet = [...semundjet];
                      updatedSemundjet.find((k) => k.id === semundje.id).updatedName = e.target.value;
                      setSemundjet(updatedSemundjet);
                    }}
                  />
                  <TextField
                    label="Updated Specializimi ID"
                    type="number"
                    value={semundje.updatedSpecializimiId || ''}
                    onChange={(e) => {
                      const updatedSemundjet = [...semundjet];
                      updatedSemundjet.find((k) => k.id === semundje.id).updatedSpecializimiId = e.target.value;
                      setSemundjet(updatedSemundjet);
                    }}
                  />
                  <Button variant="contained" onClick={() => updateSemundje(semundje.id, semundje.updatedName, semundje.updatedSpecializimiId)}>
                    Update
                  </Button>
                  <Button variant="contained" color="error" onClick={() => deleteSemundje(semundje.id)}>
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default SemundjaPage;
