import React from "react";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";

const GroupEventModal = ({ open, handleClose, event }) => {
  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Lorem Ipsum</DialogTitle>
      <DialogContent>
        <p>Dolor sit amet</p>
      </DialogContent>
    </Dialog>
  );
};

export default GroupEventModal;
