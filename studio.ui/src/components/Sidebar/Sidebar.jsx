import React from 'react';
import { Link } from 'react-router-dom';
import { List, ListItem, ListItemIcon, ListItemText, ThemeProvider } from '@mui/material';
import { styled } from '@mui/system';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import HotelIcon from '@mui/icons-material/Hotel';
import PaymentIcon from '@mui/icons-material/Payment';
import FormatListBulletedIcon from '@mui/icons-material/FormatListBulleted';
import AddAlertTwoToneIcon from '@mui/icons-material/AddAlertTwoTone';
import { createTheme } from '@mui/material/styles';

const theme = createTheme({
  palette: {
    primary: {
      main: '#464545',
    },
  },
});

const StyledListItem = styled(ListItem)({
  backgroundColor: '#f3f3f3',
  border: '2px solid #ffff',
  borderRadius: '10px',
  width: '250px',
});

const StyledLink = styled(Link)`
  text-decoration: none;
`;

const StyledListItemText = styled(ListItemText)(({ theme }) => ({
  color: theme.palette.primary.main,
  fontWeight: 'bold',
}));

const Sidebar = () => {
  return (
    <ThemeProvider theme={theme}>
      <List className="sidebar">
        <StyledListItem className="sidebar-item">
          <ListItemIcon>
            <AccountCircleIcon />
          </ListItemIcon>
          <StyledLink to="/MyProfile">
            <StyledListItemText primary="Profili im" />
          </StyledLink>
        </StyledListItem>
        <StyledListItem className="sidebar-item">
          <ListItemIcon>
            <HotelIcon />
          </ListItemIcon>
          <StyledLink to="/AllRooms">
            <StyledListItemText primary="Të gjitha dhomat" />
          </StyledLink>
        </StyledListItem>
        <StyledListItem className="sidebar-item">
          <ListItemIcon>
            <PaymentIcon />
          </ListItemIcon>
          <StyledLink to="/pagesat">
            <StyledListItemText primary="Të gjitha pagesat" />
          </StyledLink>
        </StyledListItem>
        <StyledListItem className="sidebar-item">
          <ListItemIcon>
            <AddAlertTwoToneIcon />
          </ListItemIcon>
          <StyledLink to="/Deadline">
            <StyledListItemText primary="Konkursi" />
          </StyledLink>
        </StyledListItem>
        <StyledListItem className="sidebar-item">
          <ListItemIcon>
            <FormatListBulletedIcon />
          </ListItemIcon>
          <StyledLink to="/Statistics">
            <StyledListItemText primary="Statistikat" />
          </StyledLink>
        </StyledListItem>
      </List>
    </ThemeProvider>
  );
};

export default Sidebar;
