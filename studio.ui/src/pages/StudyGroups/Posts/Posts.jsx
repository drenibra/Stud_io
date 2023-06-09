import React, { useState, useEffect } from "react";
import "./Posts.scss";
import agent from "../../../api/study-group-agents";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import CardActions from "@mui/material/CardActions";
import Avatar from "@mui/material/Avatar";
import { Box } from "@mui/system";
import Icon from "../../../assets/logo/icon-color-stud-io.svg";

import { Link } from "react-router-dom";
import Modal from "./PostModal";
import CreatePostModal from "./CreatePostModal";

const Posts = () => {
  const [posts, setPosts] = useState([]);
  const [refreshKey, setRefreshKey] = useState(1);
  const [selectedPost, setSelectedPost] = useState(null);

  useEffect(() => {
    agent.Posts.getAll("?StudyGroupId=3").then((response) => {
      setPosts(response);
    });
  }, [refreshKey]);

  const handleExpandClick = (post) => {
    setSelectedPost(post);
  };

  const handleCloseModal = () => {
    setSelectedPost(null);
  };

  return (
    <>
      <Box>
        <CreatePostModal
          setRefreshKey={setRefreshKey}
          studentId={"eca02143-0335-4fc0-951b-4c8904aace9a"} //currentuserId
          studyGroupId={3} //passed as prop
        />
      </Box>
      <div className="posts__list">
        {posts.map((post) => (
          <Card key={post.id} className="postCard" sx={{ minWidth: 350 }}>
            <CardContent>
              <Typography
                sx={{ fontSize: 14 }}
                color="text.secondary"
                className="postCard__author"
                gutterBottom
              >
                <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
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
              <div>
                <Button
                  variant="contained"
                  size="small"
                  onClick={() => handleExpandClick(post)}
                >
                  Expand
                </Button>
                <Button size="small">35 Likes</Button>
              </div>
              <Button className="postCard__likeBtn" size="small">
                <img src={Icon} alt="" />
              </Button>
            </CardActions>
          </Card>
        ))}
        {selectedPost && (
          <Modal
            open={Boolean(selectedPost)}
            handleClose={handleCloseModal}
            post={selectedPost}
          />
        )}
      </div>
    </>
  );
};

export default Posts;
