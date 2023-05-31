import Logo from "../../assets/logo/icon-stud-io.svg";
import { Link } from "react-router-dom";
import "./styles.css";
import React, { useState } from 'react';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleDropdown = () => {
    setIsOpen(!isOpen);
  }

  return (
    <div className="navbar">
      <div className="logo">
        <img
          src={Logo}
          alt="Our logo."
          style={{ width: "50px", padding: "1vw" }}
        />
      </div>

      <div className="navbar-links">
        <Link to=".">
          <p>Home</p>
        </Link>
        <Link to="./Mirembajtja">
          <p>Mirembajtja</p>
        </Link>
        <Link to="#">
          <p>Ankesa</p>
        </Link>
        <Link to="#">
          <p>Konkursi</p>
        </Link>
        <Link to="./Apply">
          <p>Apliko</p>
        </Link>
        <Link to="./Pagesa">
          <p>Pagesa</p>
        </Link>
        <Link to="./Pagesat">
          <p>Pagesat</p>
        </Link>
        <Link to="./MyProfile" className="my-profile-link">
          <AccountCircleIcon className="my-profile-icon" />
        </Link>

        <div className="butoni-signUp">
          <Link to="/">
            <button type="button" className="sign-in-btn">Sign in</button>
          </Link>
        </div>
      </div>
    </div>
  )
}

export default Navbar;
