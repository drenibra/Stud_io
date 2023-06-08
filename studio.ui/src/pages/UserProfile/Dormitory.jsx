import React from "react";
import { Grid, Container } from "@mui/material";
import { styled } from "@mui/system";
import Menu from "../../components/Menu/Menu";
import "./dormitory.scss";

const StyledRowContainer = styled("div")({
  background: "#f3f3f3",
  padding: "10px",
  borderRadius: "10px",
  position: "relative",
});

export default function Dormitory() {
  return (
    <>
      <div className="menu">
        <Menu />
      </div>

      <Container maxWidth="sm">
        <h2
          style={{ marginBottom: "50px", marginTop: "2em", marginLeft: "10px" }}
        >
          Konvikti
        </h2>
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
    </>
  );
}
