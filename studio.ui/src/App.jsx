import { useState } from "react";
import "./App.scss";
import ResponsiveAppBar from "./components/Navbar/ResponsiveAppBar";
import Footer from "./components/Footer/footer";
import { ThemeProvider } from "@emotion/react";
import theme from "./styles/theme";
import { Routes, Route } from "react-router-dom";
import { LandingPage, Maintenance, Payment, Payments } from "./pages";
import Apply from "./pages/Application/Apply";
import { observer } from 'mobx-react-lite';
import { useStore } from './stores/store';
import LoginForm from "./pages/Login/LoginForm";

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
        </Routes>
      </div>
      <Footer />
    </ThemeProvider>
  ) : (
    <LoginForm />
  )
});

export default App;
