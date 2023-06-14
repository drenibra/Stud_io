import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import { Button, CardActionArea, CardActions } from '@mui/material';
import Typography from '@mui/material/Typography';
import Img from './img/announcement.png';
import './styles.scss'


export default function Announcement()
{
    const [announcements, setAnnouncements] = useState([]);
    const [deadlines, setDeadlines] = useState([]);
    const [refreshKey, setRefreshKey] = useState('0');

    // announcements
    useEffect(() =>
    {
        axios.get('https://localhost:7137/api/Announcement/get-all-announcements')
            .then(response =>
            {
                setAnnouncements(response.data);
            }).catch(function (error)
            {
                console.log(error);
            });
    }, [refreshKey])

    // deadlines
    useEffect(() =>
    {
        axios.get('https://localhost:7137/api/Deadline/get-all-deadlines')
            .then(response =>
            {
                setDeadlines(response.data);
            }).catch(function (error)
            {
                console.log(error);
            });
    }, [refreshKey])


    return (
        <div className='container-konkurset-page'>
            {announcements.map((announcement) =>
            {
                const id = announcement.id;
                const title = announcement.title;
                const desc = announcement.description;
                const deadline = deadlines.find(d => d._id === announcement.DeadlineId);
                const openDate = deadline ? deadline.openDate : "";
                const closedDate = deadline ? deadline.closedDate : "";


                return (
                    <Card sx={{ maxWidth: 345 }} className='card-container'>
                        <CardActionArea>
                            <CardMedia
                                component="img"
                                image={Img}
                                className='img-card'
                                height="140"
                            />
                            <CardContent>
                                <Typography gutterBottom variant="h5" component="div" key={id}>
                                    {title}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {desc}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Data e hapjes:  {openDate} <br />
                                    Data e mbylljes: {closedDate}
                                </Typography>
                            </CardContent>
                        </CardActionArea>
                        <CardActions>
                            <Button size="small" className='btn-card' >Shiko</Button>
                        </CardActions>
                    </Card>
                    //             <Link key={id} to={`/AnnouncementDetail/${id}`} className="link-card">Shiko me shume</Link>

                )
            })}
        </div>
    )
}