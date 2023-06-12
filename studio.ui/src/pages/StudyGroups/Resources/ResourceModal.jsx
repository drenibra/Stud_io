import React from "react";
import { Modal, Box, Button } from "@mui/material";
import PropTypes from "prop-types";
import "./ResourceModal.scss";

const ResourceModal = ({ resource, open, onClose }) => {
  return (
    <Modal
      open={open}
      onClose={onClose}
      className="resource-modal"
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Box className="resource-modal__content">
        {resource && (
          <>
            <img
              src={resource.fileUrl}
              alt={resource.fileName}
              className="resource-modal__image"
            />
            <div className="resource-modal__actions">
              <Button
                variant="contained"
                component="a"
                href={resource.fileUrl}
                download={resource.fileName}
              >
                Download
              </Button>
              <Button variant="outlined" onClick={onClose}>
                Close
              </Button>
            </div>
          </>
        )}
      </Box>
    </Modal>
  );
};

export default ResourceModal;
