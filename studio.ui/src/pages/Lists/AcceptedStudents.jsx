import axios from 'axios';
import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import ListsTable from './ListsTable';
import { Button } from '@mui/material';
import { Box } from '@mui/material';
import '../StudyGroups/Resources/Resources.scss';

const AcceptedStudents = () => {
  const [profileMatches, setProfileMatches] = useState([]);
  const [refreshKey, setRefreshKey] = useState(0);
  const [isAccepted, setIsAccepted] = useState(true);

  // Function to toggle the value of isAccepted and recall the API
  const toggleIsAccepted = () => {
    setIsAccepted(!isAccepted);
    setRefreshKey(refreshKey + 1);
  };

  // get Top matches
  useEffect(() => {
    axios
      .get('http://localhost:5274/api/v1/User/get-isAccepted?isAccepted=' + isAccepted)
      .then((response) => {
        setProfileMatches(response.data);
        console.log(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  }, [refreshKey, isAccepted]);

  const rows = profileMatches.map((profileMatches, index) => {
    return {
      id: profileMatches.id || index + 1,
      studentId: profileMatches.application.studentId,
      pointsForGPA: profileMatches.pointsForGPA,
      extraPoints: profileMatches.extraPoints,
      totalPoints: profileMatches.totalPoints,
    };
  });

  return (
    <div className="main-container">
      <Box marginTop={'32px'} display={'flex'} flexDirection={'column'} alignItems={'center'} justifyContent={'center'} width={'80vw'}>
        <h3>Lista e te pranuarve</h3>
        <Button variant="contained" onClick={toggleIsAccepted}>
          {isAccepted ? 'Shiko te papranuarit' : 'Shiko te pranuarit'}
        </Button>
        <ListsTable profileMatches={rows} setProfileMatches={setProfileMatches} />
      </Box>
    </div>
  );
};

export default AcceptedStudents;
