import React, { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import TextField from "@mui/material/TextField";
import { Button } from "@mui/material";
import axios from "axios";
import './DeadlineStyles.scss'

const Deadline = () =>
{

    const [deadline, setDeadline] = useState({
        name: "",
        openDate: "",
        closedDate: "",
    });

    // const [firstDate, setFirstDate] = useState('');
    // const [secondDate, setSecondDate] = useState('');
    // const [daysDifference, setDaysDifference] = useState(0);

    const handleChange = (e) =>
    {
        const newData = { ...deadline }
        newData[e.target.id] = e.target.value
        setDeadline(newData)

    }

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
        try
        {
            const response = await axios.post('https://localhost:7137/api/Deadline/add-deadline', deadline);
            console.log(response.data);
            toast.success("Deadline u shtua me sukses!");
        } catch (error)
        {
            console.log(error);
            toast.error(error.response.data);
        }
    };

    return (
        <div className="deadline">
            <form onSubmit={(e) => handleSubmit(e)} className="form-deadline">
                <TextField
                    label="Name"
                    name="name"
                    id="name"
                    value={deadline.name}
                    onChange={handleChange}
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
                    value={deadline.openDate}
                    //value={firstDate}
                    type="date"
                    onChange={handleChange}
                    //onChange={handleOpenDateChange}
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
                    value={deadline.closedDate}
                    //value={secondDate}
                    onChange={handleChange}
                    //onChange={handleClosedDateChange}
                    type="date"
                    required
                    helperText="Please select closed date"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />

                {/* <p className="daysDifference">{daysDifference} days</p> */}

                <Button variant="contained" color="primary" type="submit" className="butoni-deadline">
                    Submit
                </Button>
            </form>
            <ToastContainer />


        </div>
    )
};

export default Deadline;

