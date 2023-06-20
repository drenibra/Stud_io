import React, { useState } from 'react';
import agent from '../../api/application_agents';
import ApplyGraphic from '../../assets/application/812.jpg';
import './Apply.scss';
import { FormControlLabel, Checkbox, Button, Box } from '@mui/material';
import TextField from '@mui/material/TextField';
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import Dropzone from '../../components/Dropzone/Dropzone';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useStore } from '../../stores/store';
import { observer } from 'mobx-react-lite';
import Footer from '../../components/Footer/footer';

const Apply = observer(() =>
{
  const { userStore } = useStore();
  let token = userStore.user.token;
  const [formData, setFormData] = useState({
    isSpecialCategory: false,
    specialCategory: '',
    document: null,
    token: token,
  });

  const handleChange = (e) =>
  {
    const { name, value, type, checked } = e.target;

    if (type === 'file')
    {
      const file = e.target.files[0];
      setFormData((prevFormData) => ({
        ...prevFormData,
        [name]: file,
      }));
    } else
    {
      setFormData((prevFormData) => ({
        ...prevFormData,
        [name]: type === 'checkbox' ? checked : value,
      }));
    }
  };

  const handleSubmit = (e) =>
  {
    e.preventDefault();

    const formDataa = new FormData();
    formDataa.append('isSpecialCategory', formData.isSpecialCategory);
    formDataa.append('specialCategoryReason', formData.specialCategory);
    formDataa.append('document', formData.document);
    formDataa.append('token', token);

    const config = {
      headers: {
        'Content-Type': 'multipart/form-data', // Set the Content-Type header
      },
    };

    agent.Apply.apply(formDataa, config)
      .then(() =>
      {
        toast.success('Ju aplikuat me sukses!');
      })
      .catch(function (error)
      {
        toast.error(error.response.data);
      });
  };

  return (
    <div className="apply-container">
      <div className="form-container">
        <Box>
          <h2>Apliko për anëtarësi në konvikt</h2>
          <form onSubmit={handleSubmit}>
            <FormControl fullWidth sx={{ marginBottom: '8px' }}>
              <InputLabel id="specialCategory-label">Kategoria e veçantë</InputLabel>
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
                <MenuItem value="Student(femije) i deshmorit">Student(femije) i deshmorit</MenuItem>
                <MenuItem value="Student me aftesi te kufizuara">Student me aftesi te kufizuara</MenuItem>
                <MenuItem value="Student(femije) i prindit invalid te luftes">Student(femije) i prindit invalid te luftes</MenuItem>
                <MenuItem value="Student invalid civil i luftes">Student invalid civil i luftes</MenuItem>
                <MenuItem value="Student me asistence sociale">Student me asistence sociale</MenuItem>
                <MenuItem value="Student i prindit martir nga lufta">Student i prindit martir nga lufta</MenuItem>
                <MenuItem value="Student i te burgosurit politik">Student i te burgosurit politik</MenuItem>
                <MenuItem value="Dy e me shume student nga nje familje aplikant ne QS">Dy e me shume student nga nje familje aplikant ne QS</MenuItem>
                <MenuItem value="Student, prindi i te cilit eshte veteran i luftes">Student, prindi i te cilit eshte veteran i luftes</MenuItem>
              </Select>
            </FormControl>
            <FormControlLabel control={<Checkbox checked={formData.isSpecialCategory} onChange={handleChange} name="isSpecialCategory" color="primary" />} label="Bëj pjesë në kategori të veçantë" />
            <Dropzone marginBottom={4} onChange={(document) => setFormData((prevFormData) => ({ ...prevFormData, document }))} />
            <Button variant="contained" color="primary" type="submit">
              Apliko
            </Button>
          </form>
        </Box>
      </div>
      <div className="background-image">
        <img src={ApplyGraphic} alt="" />
      </div>
      <ToastContainer />
    </div>
  );
});

export default Apply;
