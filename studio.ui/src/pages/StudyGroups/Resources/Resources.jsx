import React, { useState, useEffect } from "react";
import "./Resources.scss";
import agent from "../../../api/study-group-agents";
import Box from "@mui/material/Box";
import ImageList from "@mui/material/ImageList";
import ImageListItem from "@mui/material/ImageListItem";
import ImageListItemBar from "@mui/material/ImageListItemBar";
import ResourceModal from "./ResourceModal";
import Button from "@mui/material/Button";
import ResourceTable from "./ResourceTable";

import { Link } from "react-router-dom";

const Resources = () => {
  const [resources, setResources] = useState([]);
  const [selectedResource, setSelectedResource] = useState(null);
  const [openModal, setOpenModal] = useState(false);
  const [isTable, setIsTable] = useState(true);

  useEffect(() => {
    agent.Resources.getAll("?StudyGroupId=3").then((response) => {
      setResources(response);
    });
  }, []);

  const handleImageClick = (resource) => {
    setSelectedResource(resource);
    setOpenModal(true);
  };

  const handleCloseModal = () => {
    setSelectedResource(null);
    setOpenModal(false);
  };

  return isTable ? (
    <ResourceTable />
  ) : (
    <div className="resources">
      <ImageList variant="masonry" cols={3} gap={16}>
        {resources.map((resource) => (
          <ImageListItem key={resource.id}>
            <img
              src={`${resource.fileUrl}?w=248&fit=crop&auto=format`}
              srcSet={`${resource.fileUrl}?w=248&fit=crop&auto=format&dpr=2 2x`}
              alt={resource.fileName}
              loading="lazy"
              onClick={() => handleImageClick(resource)}
              className="resources__image"
            />
            <div className="resources__imgText">
              <ImageListItemBar
                className="resources__imgText__title"
                position="below"
                title={resource.fileName}
              />
            </div>
          </ImageListItem>
        ))}
      </ImageList>

      {/* Modal */}
      <ResourceModal
        resource={selectedResource}
        open={openModal}
        onClose={handleCloseModal}
      />
    </div>
  );
};

export default Resources;
