import { Box } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';

const ListsTable = (props) => {
  const { profileMatches } = props;
  const columns = [
    { field: 'studentId', headerName: 'Student Id' },
    { field: 'pointsForGPA', headerName: 'Piket nga nota mesatare' },
    { field: 'extraPoints', headerName: 'Piket ekstra' },
    { field: 'totalPoints', headerName: 'Piket ne total' },
  ];

  return (
    <Box marginTop={'32px'} width={'100%'}>
      <div className="resource-table-container">
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
