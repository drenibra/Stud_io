import axios from 'axios';
import React, { useState } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import './styles.scss';
import { useStore } from '../../stores/store';
import complaining from './complaining.svg';

export default function Complaint() {
  const { userStore } = useStore();
  let token = userStore.user.token;
  const [complaintForm, setComplaintForm] = useState({
    description: '',
    token: token,
  });

  const handleChange = (e) => {
    const newData = { ...complaintForm };
    newData[e.target.id] = e.target.value;
    setComplaintForm(newData);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7007/AddComplaint', complaintForm);
      console.log(response.data);
      toast.success('Ankesa u ruajt me sukses!');
    } catch (error) {
      toast.error('An error occurred while adding the complaint.');
    }
  };

  return (
    <div className='complaint-form'>
        <img src={complaining} width={'450px'}/>
        <div className='complaint-area'>
            <h2 className="h2-ankesat">Paraqitni ankesën tuaj</h2>
            <form className="form-container-ankesat" onSubmit={handleSubmit}>
                <textarea id="description" className="textarea-field-ankesat" value={complaintForm.description} onChange={handleChange} placeholder="Shkruani ankesen tuaj këtu..." required />
                <button type="submit" className="submit-button-ankesat">
                Submit
                </button>
            </form>
        </div>
      <ToastContainer />
    </div>
  );
}
