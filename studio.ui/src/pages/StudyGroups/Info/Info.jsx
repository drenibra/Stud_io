import { Box, Typography, Avatar, Divider } from '@mui/material';
import React, { useState, useEffect } from 'react';
import agent from '../../../api/study-group-agents';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../../stores/store';
import { Button } from '@mui/material';

const Info = observer(({ setRefreshKey, studyGroup }) => {
  const { userStore } = useStore();
  const [isMember, setIsMember] = useState(false);

  useEffect(() => {
    if (studyGroup) {
      console.log(studyGroup);
      const isUserAttending = studyGroup.students.some((student) => student.id === userStore.user.id);
      if (isUserAttending) setIsMember(true);
    }
  }, []);

  const joinStudyGroup = async () => {
    try {
      const response = await agent.StudyGroups.joinGroup(studyGroup.id, [userStore.user.id]);
      setRefreshKey((prev) => prev + 1);
    } catch (error) {
      console.error(error);
    }
  };
  return (
    studyGroup && (
      <div>
        <Box>
          <Typography variant="h5">{studyGroup.description}</Typography>
        </Box>
        <Divider sx={{ marginY: '16px' }} />
        <Typography variant="h6">Anetaret e ketij grupi</Typography>

        <Box marginY={'32px'} height={'50px'} display={'flex'} justifyContent={'center'}>
          {studyGroup.students.map((student) => (
            <Box display={'flex'} alignItems={'center'} justifyContent={'center'} flexDirection={'column'} marginX={'16px'}>
              <Avatar alt="Remy Sharp" src={student.profileImage} title={student.firstName} />
              <Typography variant="subtitle2">
                {' '}
                {student.firstName} {student.lastName}
              </Typography>
            </Box>
          ))}
        </Box>
        <Button disabled={isMember} variant="contained" onClick={() => joinStudyGroup()}>
          Join Study Group
        </Button>
      </div>
    )
  );
});

export default Info;
