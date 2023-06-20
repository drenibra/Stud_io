import { useEffect, useState } from 'react';
import agent from './api/account_agent';
import './App.scss';
import ResponsiveAppBar from './components/Navbar/ResponsiveAppBar';
import Footer from './components/Footer/footer';
import { ThemeProvider } from '@emotion/react';
import theme from './styles/theme';
import { Routes, Route } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import { useStore } from './stores/store';
import LoginForm from './pages/Authentication/Loginform';
import RegisterForm from './pages/Authentication/RegisterForm';
import ProtectedRoute from './ProtectedRoute';

import
{
  LandingPage,
  Maintenance,
  Payment,
  Payments,
  MyProfile,
  RegisterCustomer,
  Announcement,
  Roommate,
  Questionnaire,
  Deadline,
  Dormitory,
  Statistics,
  StudyGroup,
  StudyGroups,
  Apply,
  Konkurset,
  AnnouncementTable,
  Complaint,
  Dormitories,
  GetComplaints,
} from './pages';
import Lists from './pages/Lists/Lists';

const routes = [
  { path: '/maintenance', element: Maintenance },
  { path: '/pagesa', element: Payment },
  { path: '/pagesat', element: Payments },
  { path: '/myprofile', element: MyProfile },
  { path: '/registerCustomer', element: RegisterCustomer },
  { path: '/announcement', element: Announcement },
  { path: '/roommate', element: Roommate },
  { path: '/questionnaire', element: Questionnaire },
  { path: '/apliko', element: Apply },
  { path: '/Deadline', element: Deadline },
  { path: '/dormitory', element: Dormitory },
  { path: '/Statistics', element: Statistics },
  { path: '/study-group/:id', element: StudyGroup },
  { path: '/study-groups', element: StudyGroups },
  { path: '/Konkurset', element: Konkurset },
  { path: '/AnnouncementTable', element: AnnouncementTable },
  { path: '/Complaint', element: Complaint },
  { path: '/Dormitories', element: Dormitories },
  { path: '/GetComplaints', element: GetComplaints },
  { path: '/Lists', element: Lists }
];

const App = observer(function App()
{
  const { commonStore, userStore } = useStore();
  const [user, setUser] = useState({});

  useEffect(() =>
  {
    if (commonStore.token)
    {
      try
      {
        const fetchData = async () =>
        {
          const userData = await agent.Account.current();
          setUser(userData);
        };
        fetchData();
      } catch (error)
      {
        console.error(error);
      } finally
      {
        commonStore.setAppLoaded();
      }
    } else
    {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore]);

  return (
    <ThemeProvider theme={theme}>
      <div className="wrapper">
        <ResponsiveAppBar />
        <Routes>
          {routes.map((route) => (
            <Route
              path={route.path}
              key={route.key}
              element={
                <ProtectedRoute loggedIn={userStore.isLoggedIn}>
                  <route.element />
                </ProtectedRoute>
              }
            />
          ))}
          <Route element={<LoginForm />} path="/login" />
          <Route element={<RegisterForm />} path="/register" />
          <Route path="/" element={<LandingPage />} />
          <Route path="*" element={<LandingPage />} />
        </Routes>
        <Footer />
      </div>
    </ThemeProvider>
  );
});

export default App;
