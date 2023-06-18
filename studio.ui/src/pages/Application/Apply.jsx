import React, { useState } from 'react';
import agent from '../../api/application_agents';
import './Apply.scss';
import { FormControlLabel, Checkbox, Button } from '@mui/material';
import TextField from '@mui/material/TextField';
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import Dropzone from '../../components/Dropzone/Dropzone';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useStore } from '../../stores/store';
import { observer } from 'mobx-react-lite';

const Apply = observer(() => {
  const { userStore } = useStore();
  let studentidd = userStore.user.id;
  const [formData, setFormData] = useState({
    isSpecialCategory: false,
    specialCategory: '',
    personalNo: '',
    studentId: studentidd,
    document: null,
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;

    if (type === 'file') {
      const file = e.target.files[0];
      setFormData((prevFormData) => ({
        ...prevFormData,
        [name]: file,
      }));
    } else {
      setFormData((prevFormData) => ({
        ...prevFormData,
        [name]: type === 'checkbox' ? checked : value,
      }));
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const formDataa = new FormData();
    formDataa.append('isSpecialCategory', formData.isSpecialCategory);
    formDataa.append('specialCategory', formData.specialCategory);
    formDataa.append('personalNo', formData.personalNo);
    formDataa.append('studentId', formData.studentId);
    formDataa.append('document', formData.document);

    const config = {
      headers: {
        'Content-Type': 'multipart/form-data', // Set the Content-Type header
      },
    };

    agent.Apply.apply(formDataa, config)
      .then(() => {
        toast.success('Pagesa u krye me sukses');
      })
      .catch(function (error) {
        toast.error(error.response.data);
      });
  };

  return (
    <div className="form-container">
      <h2>Form Example</h2>
      <form onSubmit={handleSubmit}>
        <TextField label="Personal No" name="personalNo" value={formData.personalNo} onChange={handleChange} variant="outlined" fullWidth margin="normal" sx={{ marginBottom: '8px' }} />
        <FormControl fullWidth sx={{ marginBottom: '8px' }}>
          <InputLabel id="specialCategory-label">Special Category Reason</InputLabel>
          <Select
            labelId="specialCategory-label"
            id="specialCategory"
            name="specialCategory"
            value={formData.specialCategory}
            onChange={handleChange}
            label="Special Category Reason"
            disabled={!formData.isSpecialCategory}
          >
            <MenuItem value="">Select Special Category Reason</MenuItem>
            <MenuItem value="Femije i deshmorit">Femije i deshmorit</MenuItem>
            <MenuItem value="Femije jetim">Femije jetim</MenuItem>
            <MenuItem value="Me shume se nje student nga nje familje">Me shume se nje student nga nje familje</MenuItem>
            <MenuItem value="Femije i invalidit">Femije i invalidit</MenuItem>
            <MenuItem value="Femije i te pagjeturi">Femije i te pagjeturi</MenuItem>
          </Select>
        </FormControl>
        <FormControlLabel control={<Checkbox checked={formData.isSpecialCategory} onChange={handleChange} name="isSpecialCategory" color="primary" />} label="Is Special Category" />
        <Dropzone marginBottom={4} onChange={(document) => setFormData((prevFormData) => ({ ...prevFormData, document }))} />
        <Button variant="contained" color="primary" type="submit">
          Submit
        </Button>
      </form>
      <ToastContainer />
    </div>
  );
});

export default Apply;
