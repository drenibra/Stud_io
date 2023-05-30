import React, { useState } from "react";
import "./Apply.scss";
import { FormControlLabel, Checkbox, Button } from "@mui/material";
import TextField from "@mui/material/TextField";
import { Upload } from "@mui/icons-material";
import Dropzone from "../../components/Dropzone/Dropzone";

const Apply = () => {
  const [formData, setFormData] = useState({
    isSpecialCategory: false,
    specialCategoryReason: "",
    applyDate: null,
    personalNo: "",
    studentId: "",
    files: [],
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
    // Handle form submission
    console.log(formData);
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
        />
        {formData.isSpecialCategory && (
          <TextField
            label="Special Category Reason"
            name="specialCategoryReason"
            value={formData.specialCategoryReason}
            onChange={handleChange}
            variant="outlined"
            fullWidth
            margin="normal"
          />
        )}
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
          onChange={(files) =>
            setFormData((prevFormData) => ({ ...prevFormData, files }))
          }
        />
        <Button variant="contained" color="primary" type="submit">
          Submit
        </Button>
      </form>
    </div>
  );
};

export default Apply;
