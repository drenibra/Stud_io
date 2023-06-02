import Menu from "../../components/Menu/Menu";
import "./roommate.scss";
import { TextField } from "@mui/material";
import { Avatar, IconButton } from '@mui/material';
import CheckIcon from '@mui/icons-material/Check';
import CloseIcon from '@mui/icons-material/Close';
import accept from "../StudentProfile/img/accept3.svg"
import reject from "../StudentProfile/img/reject.svg"
import profilep from "../StudentProfile/img/profilep.svg"

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
            <h2></h2>
            <div className="ChooseRoommate">
                
            </div>
            <div className="RoommateSuggestion">
                    
            </div>
        </div>
    </div>
);
}