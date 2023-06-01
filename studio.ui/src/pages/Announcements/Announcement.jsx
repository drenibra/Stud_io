import React, { useState } from "react";
import agent from "../../api/announcement_agent";
import { ToastContainer, toast } from "react-toastify";
import TextField from "@mui/material/TextField";
import { Button } from "@mui/material";


const Announcement = () =>
{
    const [announcement, setAnnouncement] = useState({
        title: "",
        description: "",
        deadlineId: 0,
    });

    const handleChange = (e) =>
    {
        setAnnouncement({ ...announcement, [e.target.name]: e.target.value });
    }


    const handleSubmit = (e) =>
    {
        e.preventDeafult();
        
        agent.AddAnnouncement.create(announcement)
            .then(() =>
            {
                toast.success("Shpallja u shtua me sukses!");
            })
            .catch(function (error)
            {
                toast.error(error.response.data);
            });
    };

    return (
        <div>
            <h2>Hapja e Konkursit</h2>
            <form onSubmit={handleSubmit}>
                <TextField
                    label="Title"
                    name="title"
                    value={announcement.title}
                    onChange={handleChange}
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />
                <TextField
                    label="Description"
                    name="description"
                    value={announcement.description}
                    onChange={handleChange}
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />
                <TextField
                    label="DeadlineId"
                    name="deadlineId"
                    value={announcement.deadlineId}
                    onChange={handleChange}
                    type="number"
                    variant="outlined"
                    fullWidth
                    margin="normal"
                    sx={{ marginBottom: "8px" }}
                />

                <Button variant="contained" color="primary" type="submit">
                    Submit
                </Button>
            </form>
            <ToastContainer />
        </div>
    )
};

export default Announcement;
