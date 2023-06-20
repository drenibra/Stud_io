import React, { useState, useEffect } from 'react';
import Box from '@material-ui/core/Box';
import Menu from '../../components/Menu/Menu';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import CircularProgress from '@material-ui/core/CircularProgress';
import axios from 'axios';
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer, toast } from 'react-toastify';
import Slide from '@material-ui/core/Slide';
import Grow from '@material-ui/core/Grow';
import { Link } from 'react-router-dom';

export default function Dormitories() {
  const [dormitories, setDormitories] = useState([]);
  const [refreshKey, setRefreshKey] = useState(0);
  const [isLoading, setIsLoading] = useState(true);
  const [profileMatches, setProfileMatches] = useState([]);

  const updateDormitoryData = async () => {
    try {
      await axios.post('https://localhost:7023/AssignStudentsToDormitories', userStore.user.token);
      const updatedDormitories = dormitories.map((dormitory) => {
        return { ...dormitory, currentStudents: dormitory.currentStudents };
      });
      setDormitories(updatedDormitories);
      setRefreshKey((prevKey) => prevKey + 1);

      toast.success('Studentët u caktuan me sukses në konvikte!');
    } catch (error) {
      console.error(error);
      toast.error('Ndodhi një gabim gjatë caktimit të studentëve në konvikte!');
    }
  };

  const lists = async () => {
    await axios
      .get('https://localhost:7007/api/ProfileMatch/topMatches')
      .then((response) => {
        setProfileMatches(response.data);
        console.log(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  useEffect(() => {
    const fetchDormitories = async () => {
      try {
        const response = await axios.get('https://localhost:7023/GetDormitories', userStore.user.token);
        setDormitories(response.data);
        setIsLoading(false);
      } catch (error) {
        console.error(error);
        setIsLoading(false);
      }
    };

    fetchDormitories();
  }, [refreshKey]);

  return (
    <div>
      {!isLoading && (
        <Box maxWidth="250px" className="sidebar">
          <Menu />
        </Box>
      )}

      <Grid container justifyContent="center" marginTop={4}>
        {isLoading ? (
          <CircularProgress color="secondary" />
        ) : (
          <Button variant="contained" color="secondary" onClick={updateDormitoryData} style={{ backgroundColor: '#bf1a2f', borderRadius: '10px' }}>
            Cakto studentët në konvikte
          </Button>
        )}
      </Grid>
      <Grid container justifyContent="center">
        <Grid item xs={12} md={10} lg={8}>
          <Container style={{ padding: '30px' }}>
            <Grid container spacing={2}>
              {dormitories.map((dormitory, index) => (
                <Grid item key={index} xs={12} sm={6} md={3}>
                  <Slide direction="up" in timeout={300}>
                    <Link to="/dormitory" style={{ textDecoration: 'none' }}>
                      <Card
                        style={{
                          backgroundColor: '#f3f3f3',
                          boxShadow: '0px 0px 10px rgba(148, 9, 9, 0.479)',
                          borderRadius: '10px',
                          transition: 'width 250ms ease-in-out, transform 150ms ease',
                          '&:hover': {
                            cursor: 'pointer',
                          },
                        }}
                      >
                        <Grow in timeout={300}>
                          <CardContent>
                            <Container
                              style={{
                                backgroundColor: '#bf1a2f',
                                padding: '8px',
                                marginBottom: '8px',
                                borderRadius: '10px',
                              }}
                            >
                              <Typography variant="h6" gutterBottom style={{ fontWeight: 'bold', color: '#ffffff' }}>
                                Konvikti {dormitory.dormNo}
                              </Typography>
                            </Container>
                            <Typography variant="body2" color="textSecondary">
                              Gjinia: {dormitory.gender}
                            </Typography>
                            <Typography variant="body2" color="textSecondary">
                              Numri i dhomave: {dormitory.noOfRooms}
                            </Typography>
                            <Typography variant="body2" color="textSecondary">
                              Kapaciteti: {dormitory.capacity}
                            </Typography>
                            <Typography variant="body2" color="textSecondary">
                              Studentët aktual: {dormitory.currentStudents}
                            </Typography>
                          </CardContent>
                        </Grow>
                      </Card>
                    </Link>
                  </Slide>
                </Grid>
              ))}
            </Grid>
          </Container>
        </Grid>
      </Grid>
      <ToastContainer />
    </div>
  );
}
