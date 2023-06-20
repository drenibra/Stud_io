import { Box } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';

const ListsTable = (props) =>
{
    const { profileMatches } = props;
    const columns = [
        { field: 'id', headerName: 'Id' },
        { field: 'firstName', headerName: 'First Name' },
        { field: 'lastName', headerName: 'Last Name' },
        { field: 'email', headerName: 'Email' },
        { field: 'city', headerName: 'City' },
        { field: 'pointsForGPA', headerName: 'Average Grade Points' },
        { field: 'major', headerName: 'Major' },
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
