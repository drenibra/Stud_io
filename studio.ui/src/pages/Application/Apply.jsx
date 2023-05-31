import React, { useState } from "react";
import agent from "../../api/application_agents";
import "./Apply.scss";
import { FormControlLabel, Checkbox, Button } from "@mui/material";
import TextField from "@mui/material/TextField";
import { FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import Dropzone from "../../components/Dropzone/Dropzone";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const Apply = () => {
  const [formData, setFormData] = useState({
    isSpecialCategory: false,
    specialCategory: "",
    applyDate: "2023-03-03 ",
    personalNo: "",
    studentId: "11",
    fileId: "",
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;

    if (type === "file") {
      setFormData((prevFormData) => ({
        ...prevFormData,
        [name]: Array.from(e.target.files),
      }));
    } else {
      setFormData((prevFormData) => ({
        ...prevFormData,
        [name]: type === "checkbox" ? checked : value,
      }));
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.Apply.apply(formData)
      .then(() => {
        toast.success("Pagesa u krye me sukses");
      })
      .catch(function (error) {
        toast.error(error.response.data);
      });
  };

  return (
    <div className="form-container">
      <h2>Form Example</h2>
      <form onSubmit={handleSubmit}>
        <TextField
          label="Personal No"
          name="personalNo"
          value={formData.personalNo}
          onChange={handleChange}
          variant="outlined"
          fullWidth
          margin="normal"
          sx={{ marginBottom: "8px" }}
        />
        <TextField
          label="Student ID"
          name="studentId"
          type="number"
          value={formData.studentId}
          onChange={handleChange}
          variant="outlined"
          fullWidth
          margin="normal"
          sx={{ marginBottom: "8px" }}
        />
        <FormControl fullWidth sx={{ marginBottom: "8px" }}>
          <InputLabel id="specialCategory-label">
            Special Category Reason
          </InputLabel>
          <Select
            labelId="specialCategory-label"
            id="specialCategory"
            name="specialCategory"
            value={formData.specialCategory}
            onChange={handleChange}
            label="Special Category Reason"
            disabled={!formData.isSpecialCategory} // Disable the Select when checkbox is not checked
          >
            <MenuItem value="">Select Special Category Reason</MenuItem>
            <MenuItem value="Femije i deshmorit">Femije i deshmorit</MenuItem>
            <MenuItem value="Femije jetim">Femije jetim</MenuItem>
            <MenuItem value="Me shume se nje student nga nje familje">
              Me shume se nje student nga nje familje
            </MenuItem>
            <MenuItem value="Femije i invalidit">Femije i invalidit</MenuItem>
            <MenuItem value="Femije i te pagjeturi">
              Femije i te pagjeturi
            </MenuItem>
          </Select>
        </FormControl>
        <FormControlLabel
          control={
            <Checkbox
              checked={formData.isSpecialCategory}
              onChange={handleChange}
              name="isSpecialCategory"
              color="primary"
            />
          }
          label="Is Special Category"
        />
        <Dropzone
          marginBottom={4}
          onChange={(files) =>
            setFormData((prevFormData) => ({ ...prevFormData, files }))
          }
        />
        <Button variant="contained" color="primary" type="submit">
          Submit
        </Button>
      </form>
      <ToastContainer />
    </div>
  );
};

export default Apply;
