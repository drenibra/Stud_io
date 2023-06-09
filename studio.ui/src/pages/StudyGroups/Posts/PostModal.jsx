import React, { useEffect, useState } from "react";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { Avatar, Typography } from "@mui/material";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import { Box } from "@mui/material";
import agent from "../../../api/study-group-agents";
import "./PostModal.scss";
import Comments from "./Comments";

const PostModal = ({ open, handleClose, post }) => {
  const [currentPost, setCurrentPost] = useState();
  const studentId = "eca02143-0335-4fc0-951b-4c8904aace9a"; // to be replaced with currentStudent

  useEffect(() => {
    agent.Posts.getById(post.id).then((response) => {
      setCurrentPost(response);
    });
  }, []);

  const handleLike = () => {
    agent.Posts.likeOrUnlike(studentId, post.id).then((likeStatus) => {
      console.log(likeStatus);
      if (likeStatus === "Liked") {
        setCurrentPost((prev) => ({
          ...prev,
          likeCount: prev.likeCount + 1,
        }));
      } else if (likeStatus === "Unliked") {
        setCurrentPost((prev) => ({
          ...prev,
          likeCount: prev.likeCount - 1,
        }));
      }
    });
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
            <Button variant="contained" onClick={handleLike}>
              Likes ({currentPost.likeCount})
            </Button>
            <Button variant="outlined">
              Comments ({currentPost.commentCount})
            </Button>
          </div>

          <Comments comments={currentPost.comments} />
        </DialogContent>
      </Dialog>
    )
  );
};

export default PostModal;
