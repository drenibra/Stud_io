import React from "react";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";

const PostModal = ({ open, handleClose, post }) => {
  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>{post.title}</DialogTitle>
      <DialogContent>
        <p>{post.text}</p>
      </DialogContent>
    </Dialog>
  );
};

export default PostModal;
