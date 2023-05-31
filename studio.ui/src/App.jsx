import { useState } from "react";
import "./App.scss";
import Navbar from "./components/Navbar/Navbar";
import Footer from "./components/Footer/footer";
import { ThemeProvider } from "@emotion/react";
import theme from "./styles/theme";
import { Routes, Route } from "react-router-dom";
import { LandingPage, Maintenance, Payment, Payments, MyProfile} from "./pages";
import Apply from "./pages/Application/Apply";

function App()
{
  return (
    <ThemeProvider theme={theme}>
      <div className="main-container">
        <Navbar />
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/Mirembajtja" element={<Maintenance />} />
          <Route path="/Pagesa" element={<Payment />} />
          <Route path="/Pagesat" element={<Payments />} />
          <Route path="/Apply" element={<Apply />} />
          <Route path="/MyProfile" element={<MyProfile />} />
        </Routes>

      </div>
      <Footer />
    </ThemeProvider>
  );
}

export default App;
