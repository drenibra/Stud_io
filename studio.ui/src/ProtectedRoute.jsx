import { Navigate } from "react-router-dom";
import PropTypes from "prop-types";

ProtectedRoute.propTypes = {
  loggedIn: PropTypes.boolean,
  children: PropTypes.node.isRequired,
};

export default function ProtectedRoute({ loggedIn, children }) {
  console.log("loggedIn: " + loggedIn);
  if (!loggedIn) {
    return <Navigate to="/login" replace />;
  }
  return children;
}
