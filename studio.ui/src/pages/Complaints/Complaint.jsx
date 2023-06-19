import axios from 'axios';
import React, { useState } from 'react';
import { useStore } from '../../stores/store';
import { ToastContainer, toast } from 'react-toastify';
import './styles.scss';
import TextField from '@mui/material/TextField';

export default function Complaint()
{
    const { userStore } = useStore();
    let studentId = userStore.user.id;
    const [complaintForm, setComplaintForm] = useState({
        description: '',
        studentsId: studentId
    });

    const handleChange = (e) =>
    {
        const newData = { ...complaintForm };
        newData[e.target.id] = e.target.value;
        setComplaintForm(newData);
    };

    const handleSubmit = async (e) =>
    {
        e.preventDefault();
        try
        {
            const response = await axios.post('https://localhost:7007/AddComplaint', complaintForm);
            console.log(response.data);
            toast.success("Ankesa u ruajt me sukses!");
        } catch (error)
        {
            toast.error('An error occurred while adding the complaint.');
        }
    }

    return (
        <div>
            <h2 className='h2-ankesat'>Paraqisni një ankesë</h2>
            <form className="form-container-ankesat" onSubmit={handleSubmit}>
                <textarea
                    id="description"
                    className="textarea-field-ankesat"
                    value={complaintForm.description}
                    onChange={handleChange}
                    placeholder="Shkruani ankesen tuaj këtu..."
                    required
                />
                <button type="submit" className="submit-button-ankesat">
                    Submit
                </button>
            </form>
            <ToastContainer />
        </div>
    )
}