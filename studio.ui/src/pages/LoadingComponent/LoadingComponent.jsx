import { Backdrop, CircularProgress } from '@mui/material';

export default function LoadingComponent({ open = true }) {
    return (
        <Backdrop sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }} open={open}>
            <CircularProgress color="inherit" />
        </Backdrop>
    );
}
