import { Link } from 'react-router-dom';
import { List, ListItem, ListItemIcon, ListItemText, ThemeProvider } from '@mui/material';
import { styled } from '@mui/system';
import HomeIcon from '@mui/icons-material/Home';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import HotelIcon from '@mui/icons-material/Hotel';
import PeopleIcon from '@mui/icons-material/People';
import PaymentIcon from '@mui/icons-material/Payment';
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
  maxWidth: '250px',
  marginLeft: '2em'
  
});

const StyledLink = styled(Link)`
  text-decoration: none;
`;

const StyledListItemText = styled(ListItemText)(({ theme }) => ({
  color: theme.palette.primary.main,
  fontWeight: 'bold',
}));

const Menu =() => {
  return (
      <ThemeProvider theme={theme}>
        <List className="menu">
          <StyledListItem className="menu-item">
            <ListItemIcon>
              <HomeIcon />
            </ListItemIcon>
            <StyledLink to="/">
              <StyledListItemText primary="Home" />
            </StyledLink>
          </StyledListItem>
          <StyledListItem className="menu-item">
            <ListItemIcon>
              <AccountCircleIcon />
            </ListItemIcon>
            <StyledLink to="/profile">
              <StyledListItemText primary="My Profile" />
            </StyledLink>
          </StyledListItem>
          <StyledListItem className="menu-item">
            <ListItemIcon>
              <HotelIcon />
            </ListItemIcon>
            <StyledLink to="/dormitory">
              <StyledListItemText primary="Dormitory" />
            </StyledLink>
          </StyledListItem>
          <StyledListItem className="menu-item">
            <ListItemIcon>
              <PeopleIcon />
            </ListItemIcon>
            <StyledLink to="/roommate">
              <StyledListItemText primary="Roommate" />
            </StyledLink>
          </StyledListItem>
          <StyledListItem className="menu-item">
            <ListItemIcon>
              <PaymentIcon />
            </ListItemIcon>
            <StyledLink to="/payments">
              <StyledListItemText primary="Payments" />
            </StyledLink>
          </StyledListItem>
        </List>
      </ThemeProvider>
  );
}

export default Menu;