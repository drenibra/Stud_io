import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
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

    


    return (

        <div className='get-ankesat'>
            {complaints.map((complaint) =>
            {
                const studentsId = complaint.studentsId;
                const description = complaint.description;


                return (
                    <Card sx={{ maxWidth: 345 }} className='card-container-ankesat'>
                        <CardContent>
                            <Typography gutterBottom variant="p" component="div">
                                Name:
                            </Typography>
                            <Typography variant="body2" color="text.secondary">
                                {description}
                            </Typography>
                        </CardContent>
                        <CardActions>
                            <Button size="small" className='btn-card'>Delete</Button>
                            {/* <Button size="small">Learn More</Button> */}
                        </CardActions>
                    </Card>

                );
            })}
        </div>
    );

}