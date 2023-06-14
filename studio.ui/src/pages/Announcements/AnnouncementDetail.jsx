import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router';

const AnnouncementDetail = (props) => 
{
    const { id } = useParams();
    const [announcement, setAnnouncement] = useState(null);

    useEffect(() =>
    {
        axios.get(`https://localhost:7137/api/Announcement/get-announcement-by-id /${id}`)
            .then(response =>
            {
                setAnnouncement(response.data);
            }).catch(function (error)
            {
                console.log(error);
            });
    }, [id]);

    if (!announcement)
    {
        return <div>Loading ...</div>
    }


    return (
        <div>
            <p>Id: {id}</p>
            <h3>{announcement.title}</h3>
            <p>{announcement.description}</p>
        </div>
    )
}
export default AnnouncementDetail;