import React, { useEffect, useState } from "react";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import Avatar from "@mui/material/Avatar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import { Box } from "@mui/material";
import agent from "../../../api/study-group-agents";
import "./PostModal.scss";

const PostModal = ({ open, handleClose, post }) => {
  const [currentPost, setCurrentPost] = useState();
  const [refreshKey, setRefreshKey] = useState(1);
  const studentId = "eca02143-0335-4fc0-951b-4c8904aace9a"; //to be currentStudent

  useEffect(() => {
    console.log(refreshKey);
    agent.Posts.getById(post.id).then((response) => {
      setCurrentPost(response);
    });
  }, [refreshKey]);

  const handleLike = () => {
    agent.Posts.likeOrUnlike(studentId, post.id);
    setRefreshKey((prev) => prev + 1);
  };

  const handleComment = () => {
    // Perform axios call for posting a comment
  };

  return (
    currentPost && (
      <Dialog
        className="postModal"
        open={open}
        onClose={handleClose}
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle className="postModal__header">
          <Avatar />
          <Box lineHeight={"0px"} flexDirection={"row"}>
            <Typography fontWeight={"600"} variant="subtitle1">
              {currentPost.author} Endrit Jashari
            </Typography>
            <Typography variant="caption">{currentPost.datePosted}</Typography>
          </Box>
        </DialogTitle>
        <DialogContent dividers>
          <Typography variant="h5">{currentPost.title}</Typography>
          <Typography variant="h7">{currentPost.text}</Typography>
          <div>
            <Button variant="outlined" onClick={handleLike}>
              Likes ({currentPost.likeCount})
            </Button>
            <Button variant="outlined" onClick={handleComment}>
              Comments ({currentPost.commentCount})
            </Button>
          </div>
          <TextField
            multiline
            rows={3}
            placeholder="Write a comment..."
            fullWidth
          />
          {/* Render comments here */}
        </DialogContent>
      </Dialog>
    )
  );
};

export default PostModal;
