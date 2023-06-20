import axios from "axios";
import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import ListsTable from './ListsTable'

const AcceptanceStudents = () =>
{
    // const [applications, setApplications] = useState([]);
    const [profileMatches, setProfileMatches] = useState([]);
    const [refreshKey, setRefreshKey] = useState(0);


    // get Top matches
    useEffect(() =>
    {
        axios.get('https://localhost:7007/api/ProfileMatch/topMatches')
            .then(response =>
            {
                setProfileMatches(response.data);
                console.log(response.data)
            }).catch(function (error)
            {
                console.log(error);
            });
    }, [refreshKey])



    const rows = profileMatches.map((profileMatches) =>
    {
        return {
           totalPoints studentId: profileMatches.application.studentId,
            pointsForGPA: profileMatches.pointsForGPA,
            extraPoints: profileMatches.extraPoints,
            : profileMatches.totalPoints,
        };
    });

    return (
        <div>
            <h3>Lista e te pranuarve</h3>
            <ListsTable profileMatches={rows} setProfileMatches={setProfileMatches} />
        </div>
    )
}

export default AcceptanceStudents;
