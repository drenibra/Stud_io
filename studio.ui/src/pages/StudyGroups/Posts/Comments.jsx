import React, { useState } from 'react';
import agent from '../../../api/study-group-agents';
import { TextField, Box, Button, Card, CardContent, CardActions, Typography, IconButton, Avatar } from '@mui/material';
import { Delete } from '@mui/icons-material';

const Comments = ({ comments, postId, studentId, setRefreshKey, studentName, profileImage }) => {
  const [addComment, setAddComment] = useState({
    postId: postId,
    studentId: studentId,
    text: '',
    studentName: studentName,
    profileImage,
  });

  const handleAddComment = () => {
    agent.Posts.comment(addComment).then((response) => {
      setRefreshKey((prev) => prev + 1);
      setAddComment((prev) => ({ ...prev, text: '' }));
    });
  };

  const handleDeleteComment = (commentId) => {
    agent.Posts.deleteComment(commentId).then((response) => {
      setRefreshKey((prev) => prev + 1);
    });
  };

  console.log(comments);

  return (
    <div>
      <Box mb={2} display={'flex'} gap={'8px'} justifyContent={'space-between'}>
        <TextField label="Add a comment" value={addComment.text} onChange={(e) => setAddComment((prev) => ({ ...prev, text: e.target.value }))} variant="outlined" fullWidth />
        <Button style={{ width: '20%' }} marginTop variant="contained" onClick={handleAddComment} disabled={!addComment.text}>
          Add Comment
        </Button>
      </Box>
      {comments.map((comment) => (
        <Card
          sx={{
            display: 'flex',
            flexDirection: 'row',
            mb: 2,
            justifyContent: 'space-between',
          }}
          key={comment.id}
          variant="outlined"
        >
          <CardContent>
            <Box display="flex" alignItems="center" mb={1}>
              <Avatar src={profileImage} alt={comment.author} />
              <Box ml={1}>
                <Typography variant="subtitle1">{comment.author}</Typography>
                <Typography variant="caption">{comment.datePosted}</Typography>
              </Box>
            </Box>
            <Typography variant="body1">{comment.text}</Typography>
          </CardContent>
          <CardActions>
            <IconButton color="error" onClick={() => handleDeleteComment(comment.id)}>
              <Delete />
            </IconButton>
          </CardActions>
        </Card>
      ))}
    </div>
  );
};

export default Comments;
