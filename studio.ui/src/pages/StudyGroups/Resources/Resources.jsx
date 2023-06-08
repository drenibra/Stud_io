import React, { useState, useEffect } from "react";
import "./Resources.scss";
import agent from "../../../api/study-group-agents";
import ResourceModal from "./ResourceModal";
import ResourcePhotos from "./ResourcePhotos";
import Button from "@mui/material/Button";
import ResourceTable from "./ResourceTable";
import PhotoIcon from "@mui/icons-material/Photo";
import DescriptionIcon from "@mui/icons-material/Description";

const Resources = () => {
  const [resources, setResources] = useState([]);
  const [selectedResource, setSelectedResource] = useState(null);
  const [openModal, setOpenModal] = useState(false);
  const [isTable, setIsTable] = useState(false);
  const [fileType, setFileType] = useState("&FileType=.jpg");

  useEffect(() => {
    console.log(fileType);
    agent.Resources.getAll(`?StudyGroupId=3${fileType}`).then((response) => {
      setResources(response);
    });
  }, [fileType, isTable]);

  const handleImageClick = (resource) => {
    setSelectedResource(resource);
    setOpenModal(true);
  };

  const handleCloseModal = () => {
    setSelectedResource(null);
    setOpenModal(false);
  };

  const handleToggleView = () => {
    setFileType((prev) =>
      !isTable ? (prev = "&FileType=.pdf") : (prev = "&FileType=.jpg")
    );
    setIsTable(!isTable);
  };

  return (
    <>
      <div className="toggle-buttons">
        <Button
          variant="contained"
          startIcon={<PhotoIcon />}
          onClick={handleToggleView}
          disabled={!isTable}
        >
          Photos
        </Button>
        <Button
          variant="contained"
          startIcon={<DescriptionIcon />}
          onClick={handleToggleView}
          disabled={isTable}
        >
          List
        </Button>
      </div>
      {isTable ? (
        <ResourceTable resources={resources} setResources={setResources} />
      ) : (
        <div className="resources">
          <ResourcePhotos
            resources={resources}
            handleImageClick={handleImageClick}
          />
          <ResourceModal
            resource={selectedResource}
            open={openModal}
            onClose={handleCloseModal}
          />
        </div>
      )}
    </>
  );
};

export default Resources;
