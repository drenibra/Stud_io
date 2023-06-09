import React, { useEffect, useState } from "react";
import "./StudyGroups.scss";
import Headline from "../../../assets/study-groups/headline.jpg";
import agent from "../../../api/study-group-agents";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { CardActionArea } from "@mui/material";

import StudyGroup from "../StudyGroup/StudyGroup";

import "./StudyGroups.scss";
import { TextField } from "@material-ui/core";
import { Link } from "react-router-dom";

const StudyGroups = () => {
  const [studyGroups, setStudyGroups] = useState([]);

  useEffect(() => {
    agent.StudyGroups.getAll("?FacultyId=1").then((response) => {
      setStudyGroups(response);
    });
  }, []);

  return (
    <div className="main-container">
      <section className="headline">
        <img
          src={Headline}
          alt="Headline Image"
          style={{ width: "100vw", height: "100%", objectFit: "cover" }}
        />
        <h1 className="headlineImageOverlay">Welcome to Study Groups</h1>
      </section>
      <section className="study_groups">
        <div className="study_groups__header">
          <TextField variant="outlined" label="Browse Study Groups" />
        </div>

        <div className="study_groups__list">
          {React.Children.toArray(
            studyGroups.map((group) => (
              <Card sx={{ maxWidth: 345 }}>
                <Link
                  name={`study-group${group.id}`}
                  to={`../study-group/${group.id}`}
                >
                  <CardActionArea>
                    <CardMedia
                      component="img"
                      height="140"
                      image={group.groupImageUrl}
                      alt="green iguana"
                    />
                    <CardContent>
                      <Typography gutterBottom variant="h5" component="div">
                        {group.name}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        {group.description}
                      </Typography>
                    </CardContent>
                  </CardActionArea>
                </Link>
              </Card>
            ))
          )}
        </div>
      </section>
    </div>
  );
};

export default StudyGroups;
