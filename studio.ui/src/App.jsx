import { useState } from "react";
import "./App.scss";
//import ResponsiveAppBar from "./components/Navbar/ResponsiveAppBar";
import Navbar from "./components/Navbar/Navbar"
import Footer from "./components/Footer/footer";
import { ThemeProvider } from "@emotion/react";
import theme from "./styles/theme";
import { Routes, Route } from "react-router-dom";
import
{
  LandingPage,
  Maintenance,
  Payment,
  Payments,
  MyProfile,
  RegisterCustomer,
  Announcement,
} from "./pages";
import Apply from "./pages/Application/Apply";
// import { observer } from 'mobx-react-lite';
// import { useStore } from './stores/store';
// import LoginForm from "./pages/Login/LoginForm";

function App()
{
  return (
    <ThemeProvider theme={theme}>
      <div className="main-container">
        <Navbar />
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/Mirembajtja" element={<Maintenance />} />
          <Route path="MyProfile/RegisterCustomer" element={<RegisterCustomer />} />
          <Route path="MyProfile/Pagesa" element={<Payment />} />
          <Route path="/Pagesat" element={<Payments />} />
          <Route path="/Apply" element={<Apply />} />
          <Route path="/MyProfile" element={<MyProfile />} />
          <Route path="/Announcements" element={<Announcement />}></Route>
        </Routes>
      </div>
      <Footer />
    </ThemeProvider>
  );
}
// const App = observer(function App() {
//   const { userStore } = useStore();

//   return userStore.isLoggedIn ? (
//     <ThemeProvider theme={theme}>
//       <Navbar/>
//       {/* <ResponsiveAppBar /> */}
//       <div className="main-container">
//         <Routes>
//           <Route path="/" element={<LandingPage />} />
//           <Route path="/Mirembajtja" element={<Maintenance />} />
//           <Route path="/Pagesa" element={<Payment />} />
//           <Route path="/Pagesat" element={<Payments />} />
//           <Route path="/Apply" element={<Apply />} />
//           <Route path="/MyProfile" element={<MyProfile />} />
//           <Route path="/RegisterCustomer" element={<RegisterCustomer />} />
//         </Routes>
//       </div>
//       <Footer />
//     </ThemeProvider>
//   ) : (
//     <LoginForm />
//   )
// });

export default App;
