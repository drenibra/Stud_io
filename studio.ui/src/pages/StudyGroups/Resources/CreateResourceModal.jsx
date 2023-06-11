import React, { useState } from "react";
import { Button, Modal, TextField, Box, Typography } from "@mui/material";
import Dropzone from "../../../components/Dropzone/Dropzone";
import agent from "../../../api/study-group-agents";

const CreateResourceModal = ({ studentId, studyGroupId }) => {
  const [open, setOpen] = useState(false);
  const [fileName, setFileName] = useState("");
  const [document, setDocument] = useState(null);

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleFileChange = (selectedFile) => {
    setFileName(selectedFile.name);
    setDocument(selectedFile);
  };

  const handleCreateResource = async (e) => {
    e.preventDefault();

    try {
      const formData = new FormData();
      formData.append("document", document);
      formData.append("fileName", fileName);
      formData.append("studentId", studentId);
      formData.append("studyGroupId", studyGroupId);

      const config = {
        headers: {
          "Content-Type": "multipart/form-data", // Set the Content-Type header
        },
      };

      await agent.Resources.create(formData, config).then((response) => {
        console.log(response);
      });

      handleClose();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <Button variant="contained" onClick={handleOpen}>
        Create Resource
      </Button>
      <Modal open={open} onClose={handleClose}>
        <Box
          sx={{
            position: "absolute",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
            width: 400,
            bgcolor: "background.paper",
            boxShadow: 24,
            p: 4,
          }}
        >
          <Typography variant="h4" sx={{ marginBottom: 2 }}>
            Create Resource
          </Typography>
          <form onSubmit={handleCreateResource}>
            <TextField
              label="File Name"
              value={fileName}
              onChange={(e) => setFileName(e.target.value)}
              fullWidth
              sx={{ marginBottom: 2 }}
            />
            <Dropzone onChange={handleFileChange} />
            <Button variant="contained" type="submit">
              Submit
            </Button>
          </form>
        </Box>
      </Modal>
    </div>
  );
};

export default CreateResourceModal;
