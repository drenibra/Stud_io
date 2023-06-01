import { useState } from "react";
import "./App.scss";
import ResponsiveAppBar from "./components/Navbar/ResponsiveAppBar";
import Navbar from "./components/Navbar/Navbar";
import Footer from "./components/Footer/footer";
import { ThemeProvider } from "@emotion/react";
import theme from "./styles/theme";
import { Routes, Route } from "react-router-dom";
import { observer } from "mobx-react-lite";
import { useStore } from "./stores/store";
import LoginForm from "./pages/Login/LoginForm";

import {
  LandingPage,
  Maintenance,
  Payment,
  Payments,
  MyProfile,
  RegisterCustomer,
  Announcement,
} from "./pages";
import Apply from "./pages/Application/Apply";

const App = observer(function App() {
  const { userStore } = useStore();

  return userStore.isLoggedIn ? (
    <ThemeProvider theme={theme}>
      <ResponsiveAppBar />
      <div className="main-container">
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/Mirembajtja" element={<Maintenance />} />
          <Route path="/Pagesa" element={<Payment />} />
          <Route path="/Pagesat" element={<Payments />} />
          <Route path="/Apply" element={<Apply />} />
          <Route path="/MyProfile" element={<MyProfile />} />
          <Route path="/RegisterCustomer" element={<RegisterCustomer />} />
        </Routes>
      </div>
      <Footer />
    </ThemeProvider>
  ) : (
    <>
      {console.log(import.meta.env.VITE_REACT_APP_API_AUTH_URL)}
      <LoginForm />
    </>
  );
});

export default App;
