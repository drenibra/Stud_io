import React, { useState, useEffect } from "react";
import "./Resources.scss";
import agent from "../../../api/study-group-agents";
import ResourceModal from "./ResourceModal";
import ResourcePhotos from "./ResourcePhotos";
import Button from "@mui/material/Button";
import ResourceTable from "./ResourceTable";
import { Box } from "@mui/system";
import PhotoIcon from "@mui/icons-material/Photo";
import DescriptionIcon from "@mui/icons-material/Description";
import CreateResourceModal from "./CreateResourceModal";

const Resources = () => {
  const [resources, setResources] = useState([]);
  const [selectedResource, setSelectedResource] = useState(null);
  const [openModal, setOpenModal] = useState(false);
  const [isTable, setIsTable] = useState(false);
  const [fileType, setFileType] = useState("&FileType=image/jpeg");
  const [refreshKey, setRefreshKey] = useState(1);

  useEffect(() => {
    console.log(fileType);
    agent.Resources.getAll(`?StudyGroupId=3${fileType}`).then((response) => {
      setResources(response);
    });
  }, [fileType, isTable, refreshKey]);

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
      !isTable
        ? (prev = "&FileType=application/pdf")
        : (prev = "&FileType=image/jpeg")
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
      <Box marginY={"16px"}>
        <CreateResourceModal
          studentId={"eca02143-0335-4fc0-951b-4c8904aace9a"} //currentuserId
          studyGroupId={3} //passed as prop
          setRefreshKey={setRefreshKey}
        />
      </Box>
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
