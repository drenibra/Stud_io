import React from "react";
import Card from "@mui/material/Card";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Carousel from "react-material-ui-carousel";

const GroupStudentsSlider = ({ attendees, atendeesLength }) => {
  const sliderItems = attendees.length > 8 ? 8 : attendees.length;
  const items = [];

  for (let i = 0; i < attendees.length; i += sliderItems) {
    if (i % sliderItems === 0) {
      items.push(
        <Card key={i.toString()}>
          <Grid container spacing={0}>
            {attendees.slice(i, i + sliderItems).map((item, index) => {
              return (
                <Avatar
                  key={index.toString()}
                  alt={item.firstName}
                  src={item.profileImage}
                  sx={{ cursor: "pointer", margin: "0 5px" }}
                  title={item.firstName}
                />
              );
            })}
          </Grid>
        </Card>
      );
    }
  }

  return (
    <Carousel
      sx={{ marginTop: "8px" }}
      animation="slide"
      autoPlay={true}
      cycleNavigation
      timeout={300}
    >
      {items}
    </Carousel>
  );
};

export default GroupStudentsSlider;
