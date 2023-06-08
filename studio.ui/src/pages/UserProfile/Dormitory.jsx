import React from "react";
import { Grid, Container, Box, Typography } from "@mui/material";
import { styled } from "@mui/system";
import Menu from "../../components/Menu/Menu";

const StyledRowContainer = styled("div")({
  background: "#f3f3f3",
  padding: "10px",
  borderRadius: "10px",
  position: "relative",
});

export default function Dormitory() {
  return (
    <div>
      <Box maxWidth="250px" position="absolute">
        <Menu />
      </Box>
      <Container maxWidth="sm">
        <Box textAlign="center" marginTop={4}>
          <Typography
            variant="h4"
            gutterBottom
            style={{ fontFamily: "Poppins", marginBottom: " 1em" }}
          >
            Konvikti
          </Typography>
        </Box>
        <Grid container spacing={6}>
          <Grid item xs={12} md={6}>
            <StyledRowContainer>
              <Grid container direction="column" spacing={1}>
                <Grid item>
                  <div>Numri i konviktit:</div>
                </Grid>
                <Grid item>
                  <div>Kati:</div>
                </Grid>
                <Grid item>
                  <div>Dhoma:</div>
                </Grid>
              </Grid>
            </StyledRowContainer>
          </Grid>
          <Grid item xs={12} md={6}>
            <StyledRowContainer>
              <Grid container direction="column" spacing={1}>
                <Grid item>
                  <div>3</div>
                </Grid>
                <Grid item>
                  <div>3</div>
                </Grid>
                <Grid item>
                  <div>330</div>
                </Grid>
              </Grid>
            </StyledRowContainer>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
}
