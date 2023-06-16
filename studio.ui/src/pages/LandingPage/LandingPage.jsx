import React from "react";
import "./styles.css";
import { Link } from "react-router-dom";
import Lista from "./list.png";
import ListaPritjes from "./listing.png";
import Konkursi from "./application.png";
import Ankesa from "./complaint.png";
import { useStore } from "../../stores/store";
import { Grid, Container, Box, Typography, Paper } from "@mui/material";

const LandingPage = function LandingPage() {
  return (
    <div className="base-container">
      <div className="main-div-landing-page">
        <div className="ballina-title">MIRE SE VINI NE STUD.IO</div>
      </div>

      <Container className="njoftimet-container" maxwidth="true">
        <div className="njoftimet">
          <p className="njoftimet-e-reja-title">Njoftimet e reja</p>
          <Grid container spacing={4}>
            <Grid item xs={3}>
              <Link to="#" className="njoftimet-item">
                <img src={Ankesa} />
                <p>Hapet konkursi per ankese</p>
              </Link>
            </Grid>
            <Grid item xs={3}>
              <Link to="#" className="njoftimet-item">
                <img src={ListaPritjes} />
                <p>Lista e pritjes 22/23</p>
              </Link>
            </Grid>
            <Grid item xs={3}>
              <Link to="#" className="njoftimet-item">
                <img src={Lista} />
                <p>Lista e rezultateve 22/23</p>
              </Link>
            </Grid>
            <Grid item xs={3}>
              <Link to="#" className="njoftimet-item">
                <img src={Konkursi} />
                <p>
                  Hapet konkursi per aplikim <br /> per vitin 2022/23
                </p>
              </Link>
            </Grid>
          </Grid>
        </div>
      </Container>
    </div>
  );
};

export default LandingPage;
