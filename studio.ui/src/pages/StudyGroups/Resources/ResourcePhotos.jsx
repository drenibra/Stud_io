import React from "react";
import ImageList from "@mui/material/ImageList";
import ImageListItem from "@mui/material/ImageListItem";
import ImageListItemBar from "@mui/material/ImageListItemBar";

const ResourcePhotos = ({ resources, handleImageClick }) => {
  return (
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
  );
};

export default ResourcePhotos;
