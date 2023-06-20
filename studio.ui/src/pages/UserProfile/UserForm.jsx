import './myProfile.scss';
import Menu from '../../components/Menu/Menu';
import { Container, Typography, Grid, TextField, Box, Button, Alert, AlertTitle, Fade, Select, MenuItem, Input } from '@mui/material';
import { styled } from '@mui/system';
import foto from '../UserProfile/img/blona.jpg';
import agent from '../../api/account_agent';
import { useState, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../stores/store';

const StyledContent = styled(Grid)({
  flex: '1',
  display: 'flex',
  flexDirection: 'row',
  alignItems: 'center',
  justifyContent: 'center',
  gap: '20px',
});

const StyledTitle = styled(Typography)({
  fontSize: '24px',
  fontWeight: 'bold',
});

const UserForm = observer(function UserForm(props) {
  const [success, setSuccess] = useState(false);
  const { userStore } = useStore();

  const [addPhotoMode, setAddPhotoMode] = useState(false);
  const [target, setTarget] = useState('');

  const [userImage, setUserImage] = useState({
    image: props.user.image,
    imageId: props.user.imageId,
  });

  useEffect(() => {
    setUserImage({
      image: props.user.image,
      imageId: props.user.imageId,
    });
  }, [props.user.image, props.user.imageId]);

  const initialProfile =
    props.roles[0] === 'Student'
      ? props.user ?? {
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
        }
      : props.user ?? {
          firstName: '',
          lastName: '',
          gender: '',
          username: '',
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
    if (await userStore.updateUser(formValues)) {
      setSuccess(true);
      setTimeout(() => {
        setSuccess(false);
      }, 3000);
    }
  };

  const [selectedImage, setSelectedImage] = useState(null);

  const handleImageChange = (event) => {
    const file = event.target.files[0];
    setSelectedImage(file);
  };

  const handleImageUpload = () => {
    agent.Profiles.uploadPhoto(selectedImage)
      .then((response) => {
        setAddPhotoMode(false);
        userStore.user.image = response;
        setUserImage({ image: response.data.url, imageId: response.data.id });
        console.log(response);
      })
      .catch((error) => {
        // Handle any errors that occur during the upload process
        console.error('Error uploading photo:', error);
      });

    console.log(selectedImage);
    setSelectedImage(null);
  };

  const handleDeletePhoto = async () => {
    try {
      agent.Profiles.deletePhoto(props.user.imageId);
      setUserImage({});
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div style={{ display: 'flex' }}>
      <Box maxWidth="250px">
        <Menu />
      </Box>
      <Container sx={{ mt: 10 }}>
        <StyledTitle variant="h2" sx={{ mb: 2 }}>
          My profile
        </StyledTitle>
        <Grid container>
          <Grid item xs={4}>
            <Box
              component="img"
              sx={{
                width: 350,
                maxWidth: { xs: 350, md: 250 },
                objectFit: 'contain',
              }}
              src={userImage.image}
            />
            <div>
              <Input type="file" accept="image/*" onChange={handleImageChange} />
              <div>
                <Button variant="contained" color="primary" onClick={handleImageUpload} disabled={!selectedImage}>
                  Upload Image
                </Button>
                <Button variant="outlined" color="secondary" onClick={() => handleDeletePhoto()}>
                  Delete Photo
                </Button>
              </div>
            </div>
          </Grid>
          <Grid item xs={8}>
            <Grid container spacing={2}>
              {props.attributeList.map((attribute) => {
                const label = `${attribute.charAt(0).toUpperCase()}${attribute.slice(1)}`;
                if (attribute === 'gender')
                  return (
                    <Grid item xs={6}>
                      <Select id="gender" name="gender" defaultValue={props.user[attribute]} label="Gender" sx={{ mb: 2 }} fullWidth disabled={true} onChange={handleTextFieldChange}>
                        <MenuItem value="M">M</MenuItem>
                        <MenuItem value="F">F</MenuItem>
                      </Select>
                    </Grid>
                  );
                return (
                  <Grid item xs={6}>
                    <TextField key={attribute} label={label} name={attribute} defaultValue={props.user[attribute]} id={attribute} disabled={true} fullWidth sx={{ mb: 2 }} onChange={handleTextFieldChange} />
                  </Grid>
                );
              })}
              {/* <Button variant="contained" sx={{ width: '100%', marginLeft: '16px' }} onClick={handleSubmit}>
                Save
              </Button> */}
              {success && (
                <Fade in={success} out={success} timeout={500}>
                  <Alert className={`alert success ${success ? 'show' : ''}`} severity="success">
                    <AlertTitle>Success</AlertTitle>
                    User <strong>successfully</strong> updated!
                  </Alert>
                </Fade>
              )}
            </Grid>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
});

export default UserForm;
