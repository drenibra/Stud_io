import React, { useState, useEffect } from "react";
import agent from "../../../api/study-group-agents";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import Typography from "@mui/material/Typography";
import Avatar from "@mui/material/Avatar";
import GroupIcon from "@mui/icons-material/Group";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import EventIcon from "@mui/icons-material/Event";
import AccessTimeIcon from "@mui/icons-material/AccessTime";
import PersonIcon from "@mui/icons-material/Person";
import Button from "@mui/material/Button";
import { Box, Divider } from "@mui/material";

import GroupStudentsSlider from "./GroupStudentsSlider";

const GroupEventModal = ({ open, handleClose, event }) => {
  const [groupEvent, setGroupEvent] = useState();
  const [isGoing, setIsGoing] = useState(false);

  useEffect(() => {
    if (event) {
      agent.GroupEvents.getById(event.id).then((response) => {
        setGroupEvent(response);
        console.log(response);
      });
    }
  }, [event]);

  const handleGoingClick = () => {
    agent.GroupEvents.addAttendee(event.id).then((response) => {
      // Update the local state with the modified group event
      setGroupEvent((prevGroupEvent) => ({
        ...prevGroupEvent,
        attendees: response.attendees,
      }));
      setIsGoing(true);
    });
  };

  if (!event) {
    return null;
  }

  return (
    groupEvent && (
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>{groupEvent.title}</DialogTitle>
        <DialogContent>
          <Box divider>
            <Typography variant="subtitle1">
              <GroupIcon sx={{ marginRight: 1 }} />
              {groupEvent.description}
            </Typography>
          </Box>
          <Divider sx={{ marginY: "16px" }} />
          <Typography variant="subtitle2">
            <LocationOnIcon sx={{ marginRight: 1 }} />
            {groupEvent.location}
          </Typography>
          <Typography variant="subtitle2">
            <EventIcon sx={{ marginRight: 1 }} />
            {groupEvent.dateStart}
          </Typography>
          <Typography variant="subtitle2">
            <AccessTimeIcon sx={{ marginRight: 1 }} />
            {groupEvent.timeStart} - {groupEvent.timeEnd}
          </Typography>
          <Divider sx={{ marginY: "16px" }} />
          <Typography marginTop="16px" variant="subtitle2">
            <PersonIcon sx={{ marginRight: 1 }} />
            Attendees:
          </Typography>
          <GroupStudentsSlider
            attendees={groupEvent.attendees}
            atendeesLength={groupEvent.attendees.length}
          />
        </DialogContent>
      </Dialog>
    )
  );
};

export default GroupEventModal;
