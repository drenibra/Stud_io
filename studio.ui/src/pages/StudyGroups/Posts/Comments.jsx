import React, { useState } from "react";
import {
  TextField,
  Box,
  Button,
  Card,
  CardContent,
  CardActions,
  Typography,
  IconButton,
  Avatar,
} from "@mui/material";

const Comments = ({ comments }) => {
  const [newComment, setNewComment] = useState("");

  const handleAddComment = () => {
    // Perform API call to add the comment
    // Use the newComment value
    console.log("Adding comment:", newComment);
    setNewComment("");
  };

  const handleDeleteComment = (commentId) => {
    // Perform API call to delete the comment
    console.log("Deleting comment:", commentId);
  };

  return (
    <div>
      <Box mb={2}>
        <TextField
          label="Add a comment"
          value={newComment}
          onChange={(e) => setNewComment(e.target.value)}
          variant="outlined"
          fullWidth
        />
        <Button
          variant="contained"
          onClick={handleAddComment}
          disabled={!newComment}
        >
          Add Comment
        </Button>
      </Box>
      {comments.map((comment) => (
        <Card key={comment.id} variant="outlined" sx={{ mb: 2 }}>
          <CardContent>
            <Box display="flex" alignItems="center" mb={1}>
              <Avatar src={comment.authorImage} alt={comment.authorName} />
              <Box ml={1}>
                <Typography variant="subtitle1">
                  {comment.authorName}
                </Typography>
                <Typography variant="caption">{comment.datePosted}</Typography>
              </Box>
            </Box>
            <Typography variant="body1">{comment.text}</Typography>
          </CardContent>
          <CardActions>
            <IconButton
              color="error"
              onClick={() => handleDeleteComment(comment.id)}
            >
              Delete
            </IconButton>
          </CardActions>
        </Card>
      ))}
    </div>
  );
};

export default Comments;
