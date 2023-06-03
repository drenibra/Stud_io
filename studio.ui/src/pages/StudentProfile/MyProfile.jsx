import "./myProfile.scss";
import Menu from "../../components/Menu/Menu";
import { Container, Typography, Grid, TextField } from "@mui/material";
import { styled } from "@mui/system";
import foto from "../StudentProfile/img/blona.jpg"

const StyledContent = styled(Grid)({
  flex: "1",
  display: "flex",
  flexDirection: "row",
  alignItems: "center",
  justifyContent: "center",
  gap: "20px",
});

const StyledTitle = styled(Typography)({
  fontSize: "24px",
  fontWeight: "bold",
});

export default function MyProfile() {
  return (
    <div className="styledContainer">
        <div className="menu">
            <Menu />
        </div>
        <div className="studentData">
            <div className="titulli">
                <Grid item xs={12} mb={1}>
                    <StyledTitle variant="h2">Profili im</StyledTitle>
                </Grid>
            </div>
            <div className="stdPhotoData">
                <div className="studentPhoto">
                    <img src={foto}></img>
                    <p>Fotoja e profilit</p>
                </div>
                <div className="studentDataRows">
                    <p>Të dhënat personale</p>
                    <Grid item xs={12} md={6}>
                        <TextField label="First Name" value="John" fullWidth sx={{ mb: 2, mt: 3.5}} />
                        <TextField label="Last Name" value="Doe" fullWidth sx={{ mb: 2 }} />
                        <TextField
                            label="Personal Number"
                            value="1234567890"
                            fullWidth
                            sx={{ mb: 2 }} 
                        />
                        <TextField
                            label="Email"
                            value="johndoe@example.com"
                            fullWidth
                            sx={{ mb: 2 }} 
                        />
                        <TextField
                            label="Phone Number"
                            value="123-456-7890"
                            fullWidth
                            sx={{ mb: 2 }} 
                        />
                        <TextField label="City" value="New York" fullWidth sx={{ mb: 2 }} />
                        <TextField
                            label="Faculty"
                            value="Computer Science"
                            fullWidth
                            sx={{ mb: 2 }} 
                        />
                        <TextField
                            label="Department"
                            value="Software Engineering"
                            fullWidth
                            sx={{mb: 2}}
                        />
                    </Grid>
                </div>
            </div>
        </div>
    </div>
  );
}
