import "./myProfile.scss";
import Menu from "../../components/Menu/Menu";
import { Container, Typography, Grid, TextField, Box, Button, Alert, AlertTitle, Fade } from "@mui/material";
import { styled } from "@mui/system";
import foto from "../StudentProfile/img/blona.jpg";
import agent from "../../api/account_agent";
import { useState, useEffect } from "react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../stores/store";
import LoadingComponent from "../LoadingComponent/LoadingComponent";

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

  const attributeList = [
    'firstName',
    'lastName',
    'gender',
    'username',
    'fathersName',
    'city',
    'gpa',
    'status',
    'major',
    'dormNumber',
  ];

  useEffect(() => {
    const fetchStudent = async () => {
      try {
        const student = await userStore.getStudent();
        setFormValues(userStore.student);
        setLoading(false);
      } catch (error) {
        console.log(error);
        setLoading(false);
      }
    };
    fetchStudent();
  }, []);

  const initialProfile = userStore.student ?? {
    firstName: '',
    lastName: '',
    gender: '',
    username: '',
    fathersName: '',
    city: '',
    gpa: '',
    status: '',
    major: '',
    dormNumber: '',
  };

  const [formValues, setFormValues] = useState(initialProfile);

  const handleTextFieldChange = (event) => {
    const { name, value } = event.target;
    setFormValues({
      ...formValues,
      [name]: value,
    });
    console.log(formValues);
  };

  const handleSubmit = async () => {
    if (await userStore.updateStudent(formValues)) {
      setSuccess(true);
      setTimeout(() => {
        setSuccess(false);
      }, 3000);
    }
    console.log(userStore.student)
  }

  if (loading) {
    return <LoadingComponent />
  }
  return (
    <Container sx={{ mt: 8 }}>
      <div className="menu">
        <Menu />
      </div>
      <Grid container spacing={2}>
        <Grid item xs={4}>
          <StyledTitle variant="h2">My profile</StyledTitle>
          <Box
            component="img"
            sx={{
              width: 350,
              maxWidth: { xs: 350, md: 250 },
              objectFit: 'contain'
            }}
            alt="The house from the offer."
            src={foto}
          />
        </Grid>
        <Grid item xs={8}>
          <Grid container spacing={2}>
            {attributeList.map((attribute) => {
              const label = `${attribute.charAt(0).toUpperCase()}${attribute.slice(1)}`;
              return (
                <Grid item xs={6}>
                  <TextField
                    key={attribute}
                    label={label}
                    name={attribute}
                    defaultValue={userStore.student[attribute]}
                    id={attribute}
                    fullWidth
                    sx={{ mb: 2 }}
                    onChange={handleTextFieldChange}
                  />
                </Grid>
              );
            })}
            <Button variant="contained" sx={{ width: '100%', marginLeft: '16px' }} onClick={handleSubmit}>Save</Button>
            {success &&
              <Fade in={success} out={success} timeout={500}>
                <Alert
                  className={`alert success ${success ? 'show' : ''}`}
                  severity="success"
                >
                  <AlertTitle>Success</AlertTitle>
                  User <strong>successfully</strong> updated!
                </Alert>
              </Fade>
            }
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
});

export default MyProfile;
