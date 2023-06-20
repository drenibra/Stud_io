import axios from 'axios';
import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import ListsTable from './ListsTable';
import { Button } from '@mui/material';


const AcceptedStudents = () =>
{
    const [profileMatches, setProfileMatches] = useState([]);
    const [refreshKey, setRefreshKey] = useState(0);
    const [isAccepted, setIsAccepted] = useState(true);

    // Function to toggle the value of isAccepted and recall the API
    const toggleIsAccepted = () =>
    {
        setIsAccepted(!isAccepted);
        setRefreshKey(refreshKey + 1);
    };

    // get Top matches
    useEffect(() =>
    {
        axios
            .get('http://localhost:5274/api/v1/User/get-isAccepted?isAccepted=' + isAccepted)
            .then((response) =>
            {
                setProfileMatches(response.data);
                console.log(response.data);
            })
            .catch(function (error)
            {
                console.log(error);
            });
    }, [refreshKey, isAccepted]);

    const rows = profileMatches.map((profileMatch, index) =>
    {
        return {
            id: profileMatch.id || index + 1,
            firstName: profileMatch.firstName,
            lastName: profileMatch.lastName,
            city: profileMatch.city,
            email: profileMatch.email,
            pointsForGPA: profileMatch.gpa,
            major: profileMatch.major,
        };
    });

    return (
        <div className='main-container'>
            <h3>Lista e te pranuarve</h3>
            <Button variant='contained' onClick={toggleIsAccepted} marginTop={'60px'} >Toggle Accepted</Button>
            <ListsTable profileMatches={rows} setProfileMatches={setProfileMatches} />
        </div>
    );
};

export default AcceptedStudents;
