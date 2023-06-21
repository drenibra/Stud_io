import { Box } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';

const ListsTable = (props) => {
  const { profileMatches } = props;
  const columns = [
    { field: 'id', headerName: 'Id', flex: 0.2 },
    { field: 'firstName', headerName: 'First Name', flex: 1 },
    { field: 'lastName', headerName: 'Last Name', flex: 1 },
    { field: 'email', headerName: 'Email', flex: 1 },
    { field: 'city', headerName: 'City', flex: 1 },
    { field: 'pointsForGPA', headerName: 'Average Grade Points', flex: 1 },
    { field: 'major', headerName: 'Major', flex: 1 },
  ];

  return (
    <Box marginTop={'32px'} width={'70vw'}>
      <div className="resource-table-container" style={{ width: '100%' }}>
        <DataGrid
          rows={profileMatches}
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
    </Box>
  );
};

export default ListsTable;
