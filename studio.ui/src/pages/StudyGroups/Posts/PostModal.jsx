import React, { useEffect, useState } from 'react';
import Dialog from '@mui/material/Dialog';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import { Avatar, Typography } from '@mui/material';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { Box } from '@mui/material';
import agent from '../../../api/study-group-agents';
import './PostModal.scss';
import Comments from './Comments';
import { useStore } from '../../../stores/store';
import { observer } from 'mobx-react-lite';

const PostModal = observer(({ open, handleClose, post }) => {
  const [currentPost, setCurrentPost] = useState();
  const [refreshKey, setRefreshKey] = useState(1);
  const { userStore } = useStore();

  const studentId = userStore.user.id;
  const studentName = userStore.user.firstName + ' ' + userStore.user.lastName;

  useEffect(() => {
    agent.Posts.getById(post.id).then((response) => {
      setCurrentPost(response);
    });
  }, [refreshKey]);

  const handleLike = () => {
    agent.Posts.likeOrUnlike(studentId, post.id).then((likeStatus) => {
      console.log(likeStatus);
      if (likeStatus === 'Liked') {
        setCurrentPost((prev) => ({
          ...prev,
          likeCount: prev.likeCount + 1,
        }));
      } else if (likeStatus === 'Unliked') {
        setCurrentPost((prev) => ({
          ...prev,
          likeCount: prev.likeCount - 1,
        }));
      }
    });
  };

  console.log(currentPost);

  return (
    currentPost && (
      <Dialog className="postModal" open={open} onClose={handleClose} maxWidth="md" fullWidth>
        <DialogTitle className="postModal__header">
          <Avatar src={currentPost.author.image} />
          <Box lineHeight={'0px'} flexDirection={'row'}>
            <Typography fontWeight={'600'} variant="subtitle1">
              {currentPost.author.firstName + ' ' + currentPost.author.lastName}
            </Typography>
            <Typography variant="caption">{currentPost.datePosted}</Typography>
          </Box>
        </DialogTitle>
        <DialogContent dividers>
          <Typography marginBottom={'8px'} variant="h5">
            {currentPost.title}
          </Typography>
          <Typography marginBottom={'16px'} variant="h7">
            {currentPost.text}
          </Typography>
          <Box marginTop={'16px'}>
            <Button variant="contained" onClick={handleLike}>
              Likes ({currentPost.likeCount})
            </Button>
            <Button variant="text">Comments ({currentPost.commentCount})</Button>
          </Box>
          <Box dividers marginTop={'20px'}>
            <Comments setRefreshKey={setRefreshKey} studentName={studentName} studentId={studentId} postId={currentPost.id} comments={currentPost.comments} profileImage={currentPost.author.image} />
          </Box>
        </DialogContent>
      </Dialog>
    )
  );
});

export default PostModal;
