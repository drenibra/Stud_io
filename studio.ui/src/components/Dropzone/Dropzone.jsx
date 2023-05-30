import React, { useState } from "react";
import { Box, Typography } from "@mui/material";
import { useDropzone } from "react-dropzone";

const Dropzone = ({ onChange }) => {
  const [files, setFiles] = useState([]);

  const onDrop = (acceptedFiles) => {
    setFiles(acceptedFiles);
    onChange(acceptedFiles);
  };

  const { getRootProps, getInputProps, isDragActive, isDragReject } =
    useDropzone({
      onDrop,
      accept: ".pdf,.doc,.docx",
      maxSize: 25 * 1024 * 1024, // Limit file size to 25MB
    });

  return (
    <div className="dropzone">
      <Box
        {...getRootProps()}
        sx={{
          p: 2,
          border: "1px dashed gray",
          borderRadius: "4px",
          textAlign: "center",
          backgroundColor: isDragActive ? "#e0e0e0" : "transparent",
          cursor: "pointer",
        }}
      >
        <input {...getInputProps()} />
        <Typography variant="body1" component="div">
          Drag and drop files here or click to select files.
        </Typography>
      </Box>
      {files.length > 0 && (
        <Box sx={{ mt: 2 }}>
          <Typography variant="body2">Selected files:</Typography>
          <ul>
            {files.map((file, index) => (
              <li key={index}>{file.name}</li>
            ))}
          </ul>
        </Box>
      )}
      {isDragReject && (
        <Box sx={{ mt: 2 }}>
          <Typography variant="body2" color="error">
            Invalid file format or size exceeds 25MB.
          </Typography>
        </Box>
      )}
    </div>
  );
};

export default Dropzone;
