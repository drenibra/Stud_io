import React, { useState } from 'react';
import Box from '@material-ui/core/Box';
import Menu from '../../components/Menu/Menu';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';

export default function Dormitories() {
  const [showDormitories, setShowDormitories] = useState(false);

  const handleToggleDormitories = () => {
    setShowDormitories(!showDormitories);
  };

  const dormitories = [
    {
      DormNo: 1,
      Gender: 'M',
      NoOfRooms: 10,
      Capacity: 40,
      CurrentStudents: 30,
    },{
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },{
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },{
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },{
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },
      {
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },
      {
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },
      {
        DormNo: 1,
        Gender: 'M',
        NoOfRooms: 10,
        Capacity: 40,
        CurrentStudents: 30,
      },
   
  ];

  return (
    <div>
      <Box maxWidth="250px" marginRight="16px">
        <Menu />
      </Box>
      <Grid container justifyContent="center" marginTop={4}>
        <Button
          variant="contained"
          color="secondary"
          onClick={handleToggleDormitories}
          style={{ backgroundColor: '#bf1a2f', borderRadius: '10px' }}
          
        >
          Cakto studentët në konvikte
        </Button>
      </Grid>
      {showDormitories && (
        <Grid container justifyContent="center">
          <Grid item xs={12} md={10} lg={8}>
            <Container style={{ padding: '30px' }}>
              <Grid container spacing={2}>
                {dormitories.map((dormitory, index) => (
                  <Grid item key={index} xs={12} sm={6} md={3}>
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
                            Konvikti {dormitory.DormNo}
                          </Typography>
                        </Container>
                        <Typography variant="body2" color="textSecondary">
                          Gjinia: {dormitory.Gender}
                        </Typography>
                        <Typography variant="body2" color="textSecondary">
                          Numri i dhomave: {dormitory.NoOfRooms}
                        </Typography>
                        <Typography variant="body2" color="textSecondary">
                          Kapaciteti: {dormitory.Capacity}
                        </Typography>
                        <Typography variant="body2" color="textSecondary">
                          Studentët aktual: {dormitory.CurrentStudents}
                        </Typography>
                      </CardContent>
                    </Card>
                  </Grid>
                ))}
              </Grid>
            </Container>
          </Grid>
        </Grid>
      )}
    </div>
  );
}
