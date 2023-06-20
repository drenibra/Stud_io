import React, { useState } from 'react';
import { Box, Typography } from '@mui/material';
import { useDropzone } from 'react-dropzone';

const Dropzone = ({ onChange }) => {
  const [selectedFile, setSelectedFile] = useState(null);

  const onDrop = (acceptedFiles) => {
    const file = acceptedFiles[0];
    setSelectedFile(file);
    const formFile = new File([file], file.name, { type: file.type });
    onChange(formFile);
  };

  const { getRootProps, getInputProps, isDragActive, isDragReject } = useDropzone({
    onDrop,
    maxSize: 25 * 1024 * 1024, // Limit file size to 25MB
  });

  return (
    <div className="dropzone">
      <Box
        {...getRootProps()}
        sx={{
          p: 2,
          border: '1px dashed gray',
          borderRadius: '4px',
          textAlign: 'center',
          backgroundColor: isDragActive ? '#e0e0e0' : 'transparent',
          cursor: 'pointer',
        }}
      >
        <input {...getInputProps()} />
        <Typography variant="body1" component="div">
          Vendos dokumentin këtu ose kliko për të zgjedhur.
        </Typography>
      </Box>
      {selectedFile && (
        <Box sx={{ mt: 2 }}>
          <Typography variant="body2">Selected file:</Typography>
          <ul>
            <li>{selectedFile.name}</li>
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
