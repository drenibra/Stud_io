import { DataGrid } from "@mui/x-data-grid";


const ListsTable = (props) =>
{

    const { profileMatches } = props;
    const columns = [
        { field: "studentId", headerName: "Student Id" },
        //   { field: "city", headerName: "Qyteti" },
        { field: "pointsForGPA", headerName: "Piket nga nota mesatare" },
        { field: "extraPoints", headerName: "Piket ekstra" },
        { field: "totalPoints", headerName: "Piket ne total" }
    ];

    return (
        <div className="lists-table">
            <DataGrid
                rows={profileMatches}
                columns={columns}
                initialState={{
                    pagination: {
                        paginationModel: { page: 0, pageSize: 10 },
                    },
                }}
                pageSizeOptions={[10, 15]}
            />
        </div>
    )
}

export default ListsTable;