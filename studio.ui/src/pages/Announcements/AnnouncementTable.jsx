import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { DataGrid } from '@mui/x-data-grid';
import './styles.scss';
import { Button, Box } from '@mui/material';
import Menu from '../../components/Menu/Menu';

export default function AnnouncementTable() {
  const [announcements, setAnnouncements] = useState([]);
  const [deadlines, setDeadlines] = useState([]);
  const [refreshKey, setRefreshKey] = useState('0');

  // announcements
  useEffect(() => {
    axios
      .get('https://localhost:7137/api/Announcement/get-all-announcements')
      .then((response) => {
        setAnnouncements(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  }, []);

  function DeleteAnnouncement(id) {
    const confirmBox = window.confirm('A jeni te sigurte qe deshironi te fshini konkursin me id ' + id + '?  ');
    if (confirmBox === true) {
      axios.delete('https://localhost:7137/api/Announcement/delete-announcement/' + id).then(() => {
        setRefreshKey((refreshKey) => refreshKey + 1);
      });
    } else {
      console.log('Process of deleting an announcement canceled !!');
    }
  }

  function UpdateAnnouncement(id) {
    const confirmBox = window.confirm('A jeni te sigurte qe deshironi te fshini konkursin me id ' + id + '?  ');
    if (confirmBox === true) {
      axios.delete('https://localhost:7137/api/Announcement/update-announcement-by-id/' + id).then(() => {
        setRefreshKey((refreshKey) => refreshKey + 1);
      });
    } else {
      console.log('Process of deleting an announcement canceled !!');
    }
  }

  // deadlines
  useEffect(() => {
    axios
      .get('https://localhost:7137/api/Deadline/get-all-deadlines')
      .then((response) => {
        setDeadlines(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  }, []);

  const columns = [
    { field: 'id', headerName: 'Id', width: 180 },
    { field: 'title', headerName: 'Title', width: 180 },
    { field: 'description', headerName: 'Description', width: 220 },
    { field: 'openDate', headerName: 'Open Date', width: 110 },
    { field: 'closedDate', headerName: 'Closed Date', width: 120 },
  ];

  const rows = announcements.map((announcement, index) => {
    return {
      id: announcement.id || index + 1,
      title: announcement.title,
      description: announcement.description,
      openDate: announcement.deadline.openDate,
      closedDate: announcement.deadline.closedDate,
    };
  });

  return (
    <div style={{ display: 'grid', gridTemplateColumns: 'auto 1fr' }}>
      <Box maxWidth="250px" position="sticky" top={0}>
        <Menu />
      </Box>
      <div className="announcement-data-table">
        <DataGrid
          rows={rows}
          columns={columns}
          getRowId={(row) => row.id}
          initialState={{
            pagination: {
              paginationModel: { page: 0, pageSize: 10 },
            },
          }}
          pageSizeOptions={[10, 15]}
        />
      </div>
    </div>
  );
}
