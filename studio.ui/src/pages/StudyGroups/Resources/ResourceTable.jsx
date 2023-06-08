import React, { useEffect, useState } from "react";
import agent from "../../../api/study-group-agents";
import { DataGrid } from "@mui/x-data-grid";
import { Button } from "@mui/material";
import "./Resources.scss"; // Import the custom CSS file

const ResourceTable = () => {
  const [resources, setResources] = useState([]);

  useEffect(() => {
    agent.Resources.getAll("?StudyGroupId=3").then((response) => {
      setResources(response);
    });
  }, []);

  const columns = [
    { field: "id", headerName: "ID" },
    { field: "fileName", headerName: "File Name", width: 200 },
    { field: "fileType", headerName: "File Type", width: 150 },
    { field: "fileUrl", headerName: "File URL", width: 300 },
    { field: "author", headerName: "Author", width: 150 },
    {
      field: "download",
      headerName: "Download",
      width: 150,
      renderCell: (params) => (
        <Button
          onClick={() => window.open(params.row.fileUrl, "_blank")}
          variant="contained"
          className="download-button"
        >
          Download
        </Button>
      ),
    },
  ];

  return (
    <div className="resource-table-container">
      <DataGrid
        rows={resources}
        columns={columns}
        initialState={{
          pagination: {
            paginationModel: { page: 0, pageSize: 10 },
          },
        }}
        pageSizeOptions={[10, 15]}
      />
    </div>
  );
};

export default ResourceTable;
