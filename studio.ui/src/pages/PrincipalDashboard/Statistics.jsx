import React from 'react';
import { ResponsiveBar } from '@nivo/bar';
import { ResponsiveLine } from '@nivo/line';
import { Grid, Container, Box, Typography, Paper } from '@mui/material';
import Menu from '../../components/Menu/Menu';

const ComplaintsFeedbackChart = () => {
  const barChartData = [
    {
      category: 'Mirembajtje',
      count: 25,
    },
    {
      category: 'Pasterti',
      count: 18,
    },
    {
      category: 'Zhurme',
      count: 12,
    },
    {
      category: 'Paisjet',
      count: 15,
    },
  ];

  const lineChartData = [
    {
      id: 'Aplikantët',
      data: [
        { x: '2010', y: 11421 },
        { x: '2011', y: 10705 },
        { x: '2012', y: 11096 },
        { x: '2013', y: 10058 },
        { x: '2014', y: 9855 },
        { x: '2015', y: 11300 },
        { x: '2016', y: 10296 },
        { x: '2017', y: 9033 },
        { x: '2018', y: 10089 },
        { x: '2019', y: 10468 },
        { x: '2020', y: 6542 },
        { x: '2021', y: 7650 },
        { x: '2022', y: 8326 },
        { x: '2023', y: 10063 },
      ],
      // data: Array.from({ length: 14 }, (_, i) => ({
      //   x: (2010 + i).toString(),
      //   y: Math.floor(Math.random() * (11000 - 8000 + 1)) + 8000,
      // })),
    },
  ];

  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      <Container maxWidth="md">
        <Box textAlign="center" marginTop={4}>
          <Typography variant="h4" gutterBottom style={{ fontFamily: 'Poppins', marginBottom: ' 1em' }}>
            Statistikat
          </Typography>
        </Box>
        <Grid container spacing={4}>
          <Grid item xs={12}>
            <Paper>
              <Box textAlign="center">
                <Typography variant="h6" gutterBottom style={{ fontFamily: 'Poppins' }}>
                  Ankesat
                </Typography>
              </Box>
              <Box height={400} padding={3}>
                <ResponsiveBar
                  data={barChartData}
                  keys={['count']}
                  indexBy="category"
                  margin={{ top: 10, right: 130, bottom: 50, left: 60 }}
                  padding={0.3}
                  colors="#bf1a2f"
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
              </Box>
            </Paper>
          </Grid>
          <Grid item xs={12} marginBottom={5}>
            <Paper>
              <Box textAlign="center">
                <Typography variant="h6" gutterBottom style={{ fontFamily: 'Poppins' }}>
                  Aplikantët ndër vite
                </Typography>
              </Box>
              <Box height={400} padding={3}>
                <ResponsiveLine
                  data={lineChartData}
                  margin={{ top: 10, right: 110, bottom: 50, left: 60 }}
                  xScale={{ type: 'point' }}
                  yScale={{
                    type: 'linear',
                    min: 'auto',
                    max: 'auto',
                    stacked: true,
                    reverse: false,
                  }}
                  yFormat=" >-.2f"
                  axisTop={null}
                  axisRight={null}
                  axisBottom={{
                    tickSize: 5,
                    tickPadding: 5,
                    tickRotation: 0,
                    legend: 'Year',
                    legendOffset: 36,
                    legendPosition: 'middle',
                  }}
                  axisLeft={{
                    tickSize: 5,
                    tickPadding: 5,
                    tickRotation: 0,
                    legend: 'Count',
                    legendOffset: -40,
                    legendPosition: 'middle',
                  }}
                  pointSize={10}
                  pointColor={{ theme: 'background' }}
                  pointBorderWidth={2}
                  pointBorderColor="#bf1a2f"
                  pointLabelYOffset={-12}
                  useMesh={true}
                  legends={[
                    {
                      anchor: 'bottom-right',
                      direction: 'column',
                      justify: false,
                      translateX: 100,
                      translateY: 0,
                      itemsSpacing: 0,
                      itemDirection: 'left-to-right',
                      itemWidth: 80,
                      itemHeight: 20,
                      itemOpacity: 0.75,
                      symbolSize: 12,
                      symbolShape: 'circle',
                      symbolBorderColor: 'rgba(0, 0, 0, .5)',
                      effects: [
                        {
                          on: 'hover',
                          style: {
                            itemBackground: 'rgba(0, 0, 0, .03)',
                            itemOpacity: 1,
                          },
                        },
                      ],
                    },
                  ]}
                />
              </Box>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

export default ComplaintsFeedbackChart;
