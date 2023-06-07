import "./myProfile.scss";
import Menu from "../../components/Menu/Menu";
import {
  Container,
  Typography,
  Grid,
  TextField,
  Box,
  Button,
  Alert,
  AlertTitle,
  Fade,
} from "@mui/material";
import { styled } from "@mui/system";
import foto from "../UserProfile/img/blona.jpg";
import agent from "../../api/account_agent";
import { useState, useEffect } from "react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../stores/store";
import LoadingComponent from "../LoadingComponent/LoadingComponent";
import UserForm from "./UserForm";

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

const MyProfile = observer(function MyProfile() {
  const { userStore } = useStore();
  const [loading, setLoading] = useState(true);
  const [success, setSuccess] = useState(false);
  const [roles, setRoles] = useState([]);
  const [user, setUser] = useState({});

  const attributeList = ["firstName", "lastName", "gender", "username"];

  const attributesToAdd = [
    "fathersName",
    "city",
    "gpa",
    "status",
    "major",
    "dormNumber",
  ];

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const roles = await userStore.getRoles();
        setRoles(roles);
        if (roles[0] === "Student") {
          const student = await agent.Account.student();
          setUser(student);
          setLoading(false);
        } else if (roles[0] === "Admin") {
          const admin = await agent.Account.current();
          setUser(admin);
          setLoading(false);
        }
      } catch (error) {
        console.log(error);
        setLoading(false);
      }
    };
    fetchUser();
  }, []);

  let attributes = attributeList;

  if (roles[0] === "Student") {
    attributes = attributeList.concat(attributesToAdd);
  }

  if (loading) {
    return <LoadingComponent />;
  }

  return <UserForm user={user} roles={roles} attributeList={attributes} />;
});

export default MyProfile;
