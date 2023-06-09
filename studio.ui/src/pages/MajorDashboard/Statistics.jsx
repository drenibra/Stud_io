import React from 'react';
import { ResponsiveBar } from '@nivo/bar';
import { Grid, Container, Box, Typography, Paper } from "@mui/material";
import { styled } from "@mui/system";
import Sidebar from "../../components/Sidebar/Sidebar";

const StyledRowContainer = styled("div")({
  background: "#f3f3f3",
  padding: "10px",
  borderRadius: "10px",
  position: "relative",
});

const ComplaintsFeedbackChart = () => {
  const data = [
    {
      category: 'Maintenance',
      count: 25,
    },
    {
      category: 'Cleanliness',
      count: 18,
    },
    {
      category: 'Noise',
      count: 12,
    },
    {
      category: 'Facilities',
      count: 15,
    },
    // Add more data objects for other categories
  ];

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Sidebar />
      </Box>
      <Container maxWidth="md">
        <Box textAlign="center" marginTop={4}>
          <Typography
            variant="h4"
            gutterBottom
            style={{ fontFamily: "Poppins", marginBottom: " 1em" }}
          >
            Ankesat
          </Typography>
        </Box>
        <div style={{ height: '400px' }}>
          <ResponsiveBar
            data={data}
            keys={['count']}
            indexBy="category"
            margin={{ top: 50, right: 130, bottom: 50, left: 60 }}
            padding={0.3}
            colors={{ scheme: 'category10' }}
            axisBottom={{
              tickSize: 5,
              tickPadding: 5,
              tickRotation: 0,
            }}
            axisLeft={{
              tickSize: 5,
              tickPadding: 5,
              tickRotation: 0,
              legend: 'Count',
              legendPosition: 'middle',
              legendOffset: -40,
            }}
            labelSkipWidth={12}
            labelSkipHeight={12}
            labelTextColor={{ from: 'color', modifiers: [['darker', 1.6]] }}
            animate={true}
            motionStiffness={90}
            motionDamping={15}
          />
        </div>
      </Container>
    </div>
  );
};

export default ComplaintsFeedbackChart;
