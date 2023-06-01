import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import { useStore } from '../../stores/store';
import { Link, NavLink, useNavigate } from 'react-router-dom';
import Logo from "../../assets/logo/icon-stud-io.svg";
import { observer } from 'mobx-react-lite';
import "../../styles/navbar.css";

const pages = [
  {
    name: 'Home',
    path: '/',
  },
  {
    name: 'Mirembajtja',
    path: '/mirembajtja',
  },
  {
    name: 'Ankesa',
    path: '/ankesa',
  },
  {
    name: 'Konkursi',
    path: '/konkursi',
  },
  {
    name: 'Apliko',
    path: '/apliko',
  },
  {
    name: 'Pagesa',
    path: '/pagesa',
  },
  {
    name: 'About Us',
    path: '/about',
  },
];

const ResponsiveAppBar = observer(function ResponsiveAppBar() {
  const navigate = useNavigate();

  const { userStore } = useStore();

  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  return (
    <AppBar position="static">
      <Container maxWidth="xl">
        <Toolbar disableGutters style={{padding: "1vh 0"}}>
            <Link to="/" className="logo">
              <img
                src={Logo}
                alt="Our logo."
                style={{ width: "50px" }}
                />
            </Link>
          <AdbIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} />
          <Typography
            variant="h5"
            noWrap
            component="a"
            href=""
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            LOGO
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
            {pages.map((page) => (
              <NavLink key={page.name} to={page.path} className="navlink">
                {page.name}
              </NavLink>
            ))}
          </Box>
          {userStore.isLoggedIn && (
            <Box sx={{ flexGrow: 0 }}>
              <Tooltip title="Open settings">
                <IconButton id="openSettings" onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
                </IconButton>
              </Tooltip>
              <Menu
                class="menu"
                sx={{ mt: '45px' }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem onClick={handleCloseUserMenu}>
                  <Link id="profileButton" to="/MyProfile">
                    <Typography color="common.black" textAlign="center">Profile</Typography>
                  </Link>
                </MenuItem>
                <MenuItem onClick={handleCloseUserMenu}>
                  <Typography color="common.black" textAlign="center" onClick={() => navigate('/pagesat')}>
                    Pagesat
                  </Typography>
                </MenuItem>
                <MenuItem
                  onClick={() => {
                    handleCloseUserMenu();
                    userStore.logout();
                  }}
                >
                  <Typography color="common.black" textAlign="center">Log Out</Typography>
                </MenuItem>
              </Menu>
            </Box>
          )}
        </Toolbar>
      </Container>
    </AppBar>
  );
});

export default ResponsiveAppBar