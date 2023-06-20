import { Link } from 'react-router-dom';
import { List, ListItem, ListItemIcon, ListItemText, ThemeProvider } from '@mui/material';
import { styled } from '@mui/system';
import HomeIcon from '@mui/icons-material/Home';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import PeopleIcon from '@mui/icons-material/People';
import PaymentIcon from '@mui/icons-material/Payment';
import { createTheme } from '@mui/material/styles';
import { AddCard } from '@mui/icons-material';
import FormatListBulletedIcon from '@mui/icons-material/FormatListBulleted';
import AddAlertTwoToneIcon from '@mui/icons-material/AddAlertTwoTone';
import { useStore } from '../../stores/store';
import { observer } from 'mobx-react-lite';
import FeedbackTwoToneIcon from '@mui/icons-material/FeedbackTwoTone';

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

const Menu = observer(function Menu()
{
  const { userStore } = useStore();

  const studentList = [
    {
      name: 'Shtëpia',
      path: '/',
      icon: <HomeIcon />,
    },
    {
      name: 'Profili im',
      path: '/MyProfile',
      icon: <AccountCircleIcon />,
    },
    {
      name: 'Shoku i dhomes',
      path: '/Roommate',
      icon: <PeopleIcon />,
    },
    // {
    //   name: 'Regjistrohu',
    //   path: '/RegisterCustomer',
    //   icon: <AddCard />,
    // },
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
      name: 'Konviktet',
      path: '/Dormitories',
      icon: <HomeIcon />,
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
      name: 'Ankesat',
      path: '/Getcomplaints',
      icon: <FeedbackTwoToneIcon />,
    },
    {
      name: 'Statistikat',
      path: '/Statistics',
      icon: <FormatListBulletedIcon />,
    },
  ];

  var list;

  if (userStore.roles.includes('Admin'))
  {
    list = adminList;
  } else if (userStore.roles.includes('Student'))
  {
    list = studentList;
  }

  return (
    <ThemeProvider theme={theme}>
      <List className="menu">
        {list.map((item) =>
        {
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
