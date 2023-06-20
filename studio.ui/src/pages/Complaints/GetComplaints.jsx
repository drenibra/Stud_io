import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import { Button } from '@material-ui/core';
import Typography from '@mui/material/Typography';
import { CardActionArea, CardActions } from '@mui/material';
import { useStore } from '../../stores/store';


import './styles.scss'

export default function GetComplaints()
{

    const [complaints, setComplaints] = useState([]);
    const [refreshKey, setRefreshKey] = useState('0');

    const { userStore } = useStore();
    let studentId = userStore.user.id;


    // get data from db
    useEffect(() =>
    {
        axios.get('https://localhost:7007/GetComplaints')
            .then(response =>
            {
                setComplaints(response.data);
            })
    }, [refreshKey])


    //delete data from db
    function RefuzoAnkesen(id)
    {
        const confirmBox = window.confirm(
            "A jeni te sigurte qe deshironi te refuzoni ankesen me id " + id + "?  "
        );
        if (confirmBox === true)
        {
            axios.delete('https://localhost:7007/DeleteComplaint/' + id)
                .then(() =>
                {
                    setRefreshKey(refreshKey => refreshKey + 1)
                });
        }
        else
        {
            console.log("Process of deleting this complaint canceled!")
        }
    }





    return (
        <div className='get-ankesat'>
            {complaints.map((complaint) =>
            {
                const studentsId = complaint.studentsId;
                const description = complaint.description;
                const id = complaint.id;
                return (
                    <Card key={id} sx={{ maxWidth: 345 }} className='card-container-ankesat'>
                        <CardActionArea>
                            <CardContent>
                                <Typography variant="body2" color="text.secondary">
                                    {description}
                                </Typography>
                            </CardContent>
                        </CardActionArea>
                        <br /> <br /> <br />
                        <CardActions>
                            <Button size="small" onClick={() => RefuzoAnkesen(id)} className='btn-card' variant="contained" >Delete</Button>

                        </CardActions>
                    </Card>

                );
            })}
        </div>
    );

}