import { useState } from "react";
import "./App.scss";
import Navbar from "./components/Navbar/Navbar";
import { ThemeProvider } from "@emotion/react";
import theme from "./styles/theme";
import { Routes, Route } from "react-router-dom";
import { LandingPage, Maintenance, Payment, Payments } from "./pages";

function App() {
  return (
    <ThemeProvider theme={theme}>
      <div className="main-container">
        <Navbar />
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/Mirembajtja" element={<Maintenance />} />
          <Route path="/Pagesa" element={<Payment />} />
          <Route path="/Pagesat" element={<Payments />} />
        </Routes>
      </div>
    </ThemeProvider>
  );
}

export default App;
