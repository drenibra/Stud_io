import React, { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import TextField from "@mui/material/TextField";
import { Button } from "@mui/material";
import axios from "axios";
import './styles.scss';
import Deadline from "./Deadline";



const Announcement = () =>
{
    const [announcement, setAnnouncement] = useState({
        title: "",
        description: "",
        deadlineId: 0,
    });

    const handleChange = (e) =>
    {
        const newData = { ...announcement }
        newData[e.target.id] = e.target.value
        setAnnouncement(newData)

    }


    const handleSubmit = async (e) =>
    {
        e.preventDefault();
        try
        {
            const response = await axios.post('https://localhost:7137/api/Announcement/add-announcement', announcement);
            console.log(response.data);
            toast.success("Shpallja u shtua me sukses!");
        } catch (error)
        {
            console.log(error);
            toast.error(error.response.data);
        }

    };

    return (
        <div>
            <h2 className="title-hapja-konkursit">Hapja e Konkursit</h2>
            <div className="hapja-konkursit">

                <Deadline className="deadline-konkursi" />
                <form onSubmit={(e) => handleSubmit(e)} className="form-konkursi">
                    <TextField
                        label="Title"
                        name="title"
                        id="title"
                        value={announcement.title}
                        onChange={handleChange}
                        variant="outlined"
                        fullWidth
                        required
                        margin="normal"
                        sx={{ marginBottom: "8px" }}
                    />
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
                        sx={{ marginBottom: "8px" }}
                    />
                    <TextField
                        label="DeadlineId"
                        name="deadlineId"
                        id="deadlineId"
                        value={announcement.deadlineId}
                        onChange={handleChange}
                        type="number"
                        required
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
        </div >
    )
};

export default Announcement;
