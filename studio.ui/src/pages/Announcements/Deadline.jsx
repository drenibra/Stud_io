import React, { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import TextField from "@mui/material/TextField";
import { Button } from "@mui/material";

const Deadline = () =>
{

    const [deadline, setDeadline] = useState({
        name: "",
        openDate: "",
        closedDate: "",
    });


    return (
        <div className="deadline">
            <form className="form-deadline">
                <TextField
                    label="Name"
                    name="name"
                    id="name"
                    variant="outlined"
                    fullWidth
                    helperText="Please select name of deadline"
                    required
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />
                <TextField
                    name="opendate"
                    id="openDate"
                    type="date"
                    variant="outlined"
                    required
                    fullWidth
                    helperText="Please select open date"
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />
                <TextField
                    name="closeddate"
                    id="closedDate"
                    type="date"
                    required
                    helperText="Please select closed date"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />

                <Button variant="contained" color="primary" type="submit" className="butoni-konkursi">
                    Submit
                </Button>
            </form>
            <ToastContainer />


        </div>
    )
};

export default Deadline;

