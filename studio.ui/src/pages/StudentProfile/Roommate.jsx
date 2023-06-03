import Menu from "../../components/Menu/Menu";
import "./roommate.scss";
import { TextField } from "@mui/material";
import { IconButton } from '@mui/material';
import Button from "@mui/material/Button";
import accept from "../StudentProfile/img/accept3.svg"
import reject from "../StudentProfile/img/reject.svg"
import profilep from "../StudentProfile/img/profilep.svg"
import AssignmentTurnedInIcon from '@mui/icons-material/AssignmentTurnedIn';

export default function Roommate() {
return(
    <div className="styledContainerR">
        <div className="menu">
            <Menu />
        </div>
        <div className="firstPart">
            
            <div className="roommateContainer">
                <div className="title2">
                  <h3>Roommate</h3>
                </div>
                    <div className="roommateContaineeer">
                        <p>Shoku i dhomës:</p>
                        <TextField  value="Not Selected Yet!"  size= "small" sx={{ mb: 2, mt: 3.5}} variant="outlined" />
                    </div>
            </div>
            <div className="roommateRequest">
                <div className="title">
                    <h3>Pending Roommate Requests</h3>
                </div>
                <div className="roommateRequestContainer">
                    <div className="img">
                        <img src={profilep}></img>
                    </div>
                    <p>Filan Fisteku</p>
                    <div className="iconContainer">
                        <div className="greenBackground">
                        <IconButton>
                            <img src={accept} alt="Accept" />
                        </IconButton>
                        </div>
                        <div className="redBackground">
                        <IconButton>
                            <img src={reject} alt="Reject" />
                        </IconButton>
                        </div>       
                    </div>
                    </div>
                </div>
        </div>
        <div className="secondPart"> 
            <div className="chooseRoommate">
                <div className="tit4">
                    <h4>Zgjedh shokun e dhomës</h4> 
                </div>
                <p>Shëno të dhënat e shokut:</p>
                    <div className="Textfields"> 
                        <TextField label="Emri" value=""  size= "small"  sx={{ mb: 2, mt: 3.5}} />
                        <TextField label="Mbiemri" value=""  size= "small"  sx={{ mb: 2 }} />   
                    </div>
                    <Button
                        variant="contained"
                        color="primary"
                        small
                        style={{ borderRadius: '30px', textTransform: 'none' }}
                    >
                        Kërko
                    </Button>
            </div>
            <div className="roommateSuggestion">
                <h4>Merr sugjerim nga sistemi</h4> 

                <div className="questionnaire">
                <span>Plotësoni pyetësorin</span>
                <IconButton style={{ color: '#bf1a2f', borderRadius: '5px', padding: '5px' }}>
                    <AssignmentTurnedInIcon style={{ fontSize: '80px' }} />
                </IconButton>
                </div>
                
                <div className="pAndContainer">
                    <p>Shoku i sugjeruar:</p> 
                    <div className="roommateRequestContainer">
                        <div className="img">
                            <img src={profilep}></img>
                        </div>
                        <p>Filan Fisteku</p>
                        <div className="iconContainer">
                            <div className="greenBackground">
                                <IconButton>
                                    <img src={accept} alt="Accept" />
                                </IconButton>
                            </div>
                            <div className="redBackground">
                                <IconButton>
                                    <img src={reject} alt="Reject" />
                                </IconButton>
                            </div>       
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
);
}