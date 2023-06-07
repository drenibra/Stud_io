import React, { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import { Button } from "@mui/material";
import axios from "axios";
import './styles.scss';
import Deadline from "./Deadline";
import { TextField, Modal, Backdrop, Fade } from "@mui/material";
import { Link } from "react-router-dom";




export default function Announcement()
{

    const [announcement, setAnnouncement] = useState({
        title: "",
        description: "",
        deadlineId: 0,
    });

    const [open, setOpen] = useState(false);

    const handleOpen = () =>
    {
        setOpen(true);
    }

    const handleClose = () =>
    {
        setOpen(false);
    }



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
                <div className="deadline-konkursi">
                    {/* <span>Caktoni nje deadline</span>
                    <IconButton style={{ color: '#bf1a2f', borderRadius: '5px', padding: '5px' }}
                        onClick={handleOpen}>
                        <CalendarMonthOutlinedIcon style={{ fontSize: '80px' }} />
                    </IconButton>

                    <Modal
                        open={open}
                        onClose={handleClose}
                        closeAfterTransition
                    >
                        <Fade in={open}>
                            <div className="modalContent-deadline">
                                <div className="modalHeader-deadline">
                                    <IconButton
                                        className="closeButton-deadline"
                                        onClick={handleClose}
                                        style={{
                                            backgroundColor: "#f3f3f3",
                                            color: "#999",
                                            marginLeft: "900px",
                                            marginTop: "85px",
                                            padding: "4px",
                                            border: "none",
                                            outline: "none",
                                            cursor: "pointer",
                                            borderRadius: "50%",
                                        }}
                                    >
                                        <CloseIcon style={{ color: "#999" }} />
                                    </IconButton>
                                </div>
                                <Deadline handleClose={handleClose} className="cakto-deadline" />
                            </div>
                        </Fade>
                    </Modal>

                </div> */}


                    {/* < Deadline className="deadline-konkursi" /> */}
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
                        </Button> <br />

                        <Link to="/deadline" className="link-anouncement">Back</Link>


                    </form>
                    <ToastContainer />


                </div>
            </div>
        </div >
    )
};
