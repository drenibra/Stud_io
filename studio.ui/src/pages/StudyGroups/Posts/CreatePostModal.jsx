import React, { useState } from "react";
import { Button, Modal, TextField, Box, Typography } from "@mui/material";
import agent from "../../../api/study-group-agents";

const CreatePostModal = ({ setRefreshKey, studyGroupId, studentId }) => {
  const [open, setOpen] = useState(false);
  const [title, setTitle] = useState("");
  const [text, setText] = useState("");

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleCreatePost = async (e) => {
    e.preventDefault(); // Prevent the default form submission

    try {
      const newPost = {
        Title: title,
        Text: text,
        StudyGroupId: studyGroupId,
        StudentId: studentId,
      };

      // Make an API call to create the post
      agent.Posts.create(newPost).then((response) => {
        setRefreshKey((prev) => prev + 1);
      });

      // Close the modal
      handleClose();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <Button variant="contained" onClick={handleOpen}>
        Create Post
      </Button>
      <Modal open={open} onClose={handleClose}>
        <Box
          sx={{
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
            width: 400,
            bgcolor: "background.paper",
            boxShadow: 24,
            p: 4,
          }}
        >
          <Typography variant="h4" sx={{ marginBottom: 2 }}>
            Create Post
          </Typography>
          <form onSubmit={handleCreatePost}>
            <TextField
              label="Title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              fullWidth
              sx={{ marginBottom: 2 }}
            />
            <TextField
              label="Text"
              value={text}
              onChange={(e) => setText(e.target.value)}
              multiline
              rows={4}
              fullWidth
              sx={{ marginBottom: 2 }}
            />
            <Button variant="contained" type="submit">
              Submit
            </Button>
          </form>
        </Box>
      </Modal>
    </div>
  );
};

export default CreatePostModal;
