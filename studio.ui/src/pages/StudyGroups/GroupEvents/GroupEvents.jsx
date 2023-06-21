import React, { useState, useEffect } from 'react';
import './GroupEvents.scss';
import agent from '../../../api/study-group-agents';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import CardActions from '@mui/material/CardActions';
import Avatar from '@mui/material/Avatar';
import GroupEventModal from './GroupEventModal';
import { Box } from '@mui/material';
import { useStore } from '../../../stores/store';
import Icon from '../../../assets/logo/icon-color-stud-io.svg';

import { Link } from 'react-router-dom';

const GroupEvents = () => {
  const [groupEvents, setGroupEvents] = useState([]);
  const [selectedEvent, setSelectedEvent] = useState(null);

  const { userStore } = useStore();

  useEffect(() => {
    agent.GroupEvents.getAll('?StudyGroupId=3').then((response) => {
      setGroupEvents(response);
      console.log(response);
    });
  }, []);

  const handleExpandClick = (event) => {
    setSelectedEvent(event);
  };

  const handleCloseModal = () => {
    setSelectedEvent(null);
  };

  return (
    <div className="groupEvents__list">
      {groupEvents.map((event) => (
        <Card key={event.id} className="groupEvent" sx={{ minWidth: 350 }}>
          <CardContent>
            <Box gap={'8px'} display={'flex'} flexDirection={'row'}>
              <Typography sx={{ fontSize: 14 }} color="text.secondary" className="groupEvent__author" gutterBottom>
                <Avatar alt="Remy Sharp" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSM38-KJLC_EYZQKyhG0ckuElEsUmT2stRZUw&usqp=CAU" />
              </Typography>
              <Box>
                <Typography variant="subtitle2" fontWeight={'600'}>
                  {event.dateStart}
                </Typography>
                <Typography variant="subtitle2">
                  {event.timeStart} - {event.timeEnd}
                </Typography>
              </Box>
            </Box>
            <Typography variant="h5" component="div">
              {event.title}
            </Typography>
            <Typography sx={{ mb: 1.5 }} color="text.secondary">
              {event.description}
            </Typography>
          </CardContent>
          <CardActions className="groupEvent__action">
            <Button variant="contained" size="small" onClick={() => handleExpandClick(event)}>
              Expand
            </Button>
          </CardActions>
        </Card>
      ))}
      {selectedEvent && <GroupEventModal open={Boolean(selectedEvent)} handleClose={handleCloseModal} event={selectedEvent} />}
    </div>
  );
};

export default GroupEvents;
