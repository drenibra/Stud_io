import React, { useEffect, useState } from "react";
import Headline from "../../../assets/study-groups/headline.jpg";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import "./StudyGroup.scss";
import { Posts, GroupEvents, Info, Resources } from "..";
import { useParams } from "react-router";
import agent from "../../../api/study-group-agents";
import LoadingComponent from "../../LoadingComponent/LoadingComponent";

const StudyGroup = () => {
  const [activeButton, setActiveButton] = useState(1);
  const [studyGroup, setStudyGroup] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const [refreshKey, setRefreshKey] = useState(1);

  const params = useParams();

  useEffect(() => {
    setIsLoading(true);
    agent.StudyGroups.getById(params.id).then((response) => {
      setStudyGroup(response);
    });
    setIsLoading(false);
  }, [refreshKey]);

  const handleNavButtonClick = (buttonIndex) => {
    setActiveButton(buttonIndex);
  };

  const ActivePage = () => {
    switch (activeButton) {
      case 1:
        return <Posts />;
      case 2:
        return <Resources />;
      case 3:
        return <GroupEvents />;
      case 4:
        return <Info setRefreshKey={setRefreshKey} studyGroup={studyGroup} />;
      default:
        return <Posts />;
    }
  };

  if (isLoading) {
    return <LoadingComponent />;
  } else {
    return (
      <div className="main-container">
        {studyGroup && (
          <section className="sg_headline">
            <img
              src={studyGroup.groupImageUrl}
              alt="Headline Image"
              style={{ width: "100vw", height: "100%", objectFit: "cover" }}
            />
            <h1 className="sg_headline__headlineImageOverlay">
              {studyGroup.name}
            </h1>
          </section>
        )}

        <section className="sg_navbar">
          <Stack spacing={2} direction="row">
            <Button
              variant={activeButton === 1 ? "contained" : "outlined"}
              style={{ flex: 1 }}
              onClick={() => handleNavButtonClick(1)}
            >
              Posts
            </Button>
            <Button
              variant={activeButton === 2 ? "contained" : "outlined"}
              style={{ flex: 1 }}
              onClick={() => handleNavButtonClick(2)}
            >
              Resources
            </Button>
            <Button
              variant={activeButton === 3 ? "contained" : "outlined"}
              style={{ flex: 1 }}
              onClick={() => handleNavButtonClick(3)}
            >
              Group Events
            </Button>
            <Button
              variant={activeButton === 4 ? "contained" : "outlined"}
              style={{ flex: 1 }}
              onClick={() => handleNavButtonClick(4)}
            >
              Info
            </Button>
          </Stack>
        </section>

        <section className="sg__activePage">
          <ActivePage />
        </section>
      </div>
    );
  }
};

export default StudyGroup;
