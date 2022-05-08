import { Container } from "@mui/material";
import {
  BrowserRouter as Router,
  unstable_HistoryRouter as HistoryRouter,
  Route,
  Routes,
  Outlet,
} from "react-router-dom";
import { ToastContainer } from "react-toastify";
import Login from "../../features/account/Login";
import Register from "../../features/account/Register";
import CarDetail from "../../features/car/CarDetail";
import HomePage from "../../features/home/HomePage";
import Header from "./Header";
import "react-toastify/dist/ReactToastify.css";
import { useAppDispatch } from "../store/configureStore";
import { fetchCurrentUser } from "../../features/account/accountSlice";
import { createBrowserHistory } from "history";
import { history } from "../../app/history";
import RegisterCar from "../../features/car/RegisterCar";
function App() {
  const dispatch = useAppDispatch();
  dispatch(fetchCurrentUser());

  const NavLayout = () => (
    <>
      <Header />
      <Container>
        <Outlet />
      </Container>
    </>
  );

  return (
    <>
      <ToastContainer position="bottom-right" hideProgressBar />
      <HistoryRouter history={history}>
        <Routes>
          <Route path="" element={<NavLayout />}>
            <Route path="/" element={<HomePage />} />
            <Route path="/:Id" element={<CarDetail />} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login />} />
            <Route path="/RegisterCar" element={<RegisterCar />} />
          </Route>
        </Routes>
      </HistoryRouter>
    </>
  );
}

export default App;
