import { Link } from 'react-router-dom';
import { List, ListItem, ListItemIcon, ListItemText, ThemeProvider } from '@mui/material';
import { styled } from '@mui/system';
import HomeIcon from '@mui/icons-material/Home';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import HotelIcon from '@mui/icons-material/Hotel';
import PeopleIcon from '@mui/icons-material/People';
import PaymentIcon from '@mui/icons-material/Payment';
import { createTheme } from '@mui/material/styles';
import { AddCard } from '@mui/icons-material';
import FormatListBulletedIcon from '@mui/icons-material/FormatListBulleted';
import AddAlertTwoToneIcon from '@mui/icons-material/AddAlertTwoTone';
import { useStore } from '../../stores/store';
import { observer } from 'mobx-react-lite';

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

const Menu = observer(function Menu() {
  const { userStore } = useStore();

  const studentList = [
    {
      name: 'Home',
      path: '/',
      icon: <HomeIcon />,
    },
    {
      name: 'MyProfile',
      path: '/MyProfile',
      icon: <AccountCircleIcon />,
    },
    {
      name: 'Roommate',
      path: '/Roommate',
      icon: <PeopleIcon />,
    },
    {
      name: 'RegisterCustomer',
      path: '/RegisterCustomer',
      icon: <AddCard />,
    },
    {
      name: 'Pagesa',
      path: '/Pagesa',
      icon: <PaymentIcon />,
    },
  ];
  const adminList = [
    {
      name: 'Profili im',
      path: '/MyProfile',
      icon: <AccountCircleIcon />,
    },
    {
      name: 'Dhomat',
      path: '/dormitory',
      icon: <HotelIcon />,
    },
    {
      name: 'Pagesat',
      path: '/pagesat',
      icon: <PaymentIcon />,
    },
    {
      name: 'Konkursi',
      path: '/Deadline',
      icon: <AddAlertTwoToneIcon />,
    },
    {
      name: 'Statistikat',
      path: '/Statistics',
      icon: <FormatListBulletedIcon />,
    },
  ];

  var list;

  if (userStore.roles.includes('Admin')) {
    list = adminList;
  } else if (userStore.roles.includes('Student')) {
    list = studentList;
  }

  return (
    <ThemeProvider theme={theme}>
      <List className="menu">
        {list.map((item) => {
          return (
            <StyledListItem className="menu-item">
              <ListItemIcon>{item.icon}</ListItemIcon>
              <StyledLink to={item.path}>
                <StyledListItemText primary={item.name} />
              </StyledLink>
            </StyledListItem>
          );
        })}
      </List>
    </ThemeProvider>
  );
});

export default Menu;
