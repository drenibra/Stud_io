import React, { useState, useEffect } from 'react';
import './Posts.scss';
import agent from '../../../api/study-group-agents';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import CardActions from '@mui/material/CardActions';
import Avatar from '@mui/material/Avatar';
import { Box } from '@mui/system';
import Icon from '../../../assets/logo/icon-color-stud-io.svg';
import { Link } from 'react-router-dom';
import Modal from './PostModal';
import CreatePostModal from './CreatePostModal';
import LoadingComponent from '../../LoadingComponent/LoadingComponent';
import UserStore from '../../../stores/userStore';
import { observe } from 'mobx';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../../stores/store';
import { Pagination } from '@mui/material';

const Posts = observer(() => {
  const [posts, setPosts] = useState([]);
  const [refreshKey, setRefreshKey] = useState(1);
  const [selectedPost, setSelectedPost] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [page, setPage] = useState(1);
  const { userStore } = useStore();
  const pageSize = 9;

  useEffect(() => {
    console.log(userStore.user);
    setIsLoading(true);
    agent.Posts.getAll('?StudyGroupId=3').then((response) => {
      setPosts(response);
      setIsLoading(false);
    });
  }, [refreshKey]);

  const handleExpandClick = (post) => {
    setSelectedPost(post);
  };

  const handleCloseModal = () => {
    setSelectedPost(null);
  };

  const handlePageChange = (event, value) => {
    setPage(value);
  };

  const paginatedPosts = posts.slice((page - 1) * pageSize, page * pageSize);

  if (isLoading) {
    return (
      <Box height={'100vw'}>
        <LoadingComponent />;
      </Box>
    );
  } else {
    return (
      <>
        <Box>
          <CreatePostModal
            setRefreshKey={setRefreshKey}
            studentId={userStore.user.id} //currentuserId
            studyGroupId={3} //passed as prop
          />
        </Box>
        <Box display={'flex'} flexDirection={'column'} alignItems={'center'} justifyContent={'center'} marginBottom={'50px'}>
          <div className="posts__list" style={{ marginBottom: '50px' }}>
            {paginatedPosts.map((post) => (
              <Card key={post.id} className="postCard" sx={{ minWidth: 350 }}>
                <CardContent>
                  <Typography sx={{ fontSize: 14 }} color="text.secondary" className="postCard__author" gutterBottom>
                    <Avatar alt="Remy Sharp" src={post.authorProfileImage} />
                    {post.author}
                  </Typography>
                  <Typography variant="h5" component="div">
                    {post.title}
                  </Typography>
                  <Typography sx={{ mb: 1.5 }} color="text.secondary">
                    {post.text}
                  </Typography>
                </CardContent>
                <CardActions className="postCard__action">
                  <Box>
                    <Button variant="contained" size="small" onClick={() => handleExpandClick(post)}>
                      Expand
                    </Button>
                    <Button size="small">{post.likesCount == 1 ? post.likesCount + ' hats' : post.likesCount + ' hats'}</Button>
                  </Box>
                  <Button className="postCard__likeBtn" size="small">
                    <Box>
                      <img src={Icon} alt="Icon" />
                      <Typography fontWeight={600} variant="subtitle2" component="div">
                        Hat off
                      </Typography>
                    </Box>
                  </Button>
                </CardActions>
              </Card>
            ))}
            {selectedPost && <Modal open={Boolean(selectedPost)} handleClose={handleCloseModal} post={selectedPost} />}
          </div>
          <Pagination count={Math.ceil(posts.length / pageSize)} page={page} onChange={handlePageChange} color="primary" size="small" style={{ marginTop: '20px' }} />
        </Box>
      </>
    );
  }
});

export default Posts;
