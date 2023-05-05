import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import Avatar from "@mui/material/Avatar";
import AirplanemodeActiveIcon from "@mui/icons-material/AirplanemodeActive";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <div>
        <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
        <AirplanemodeActiveIcon />

        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 2)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  );
}

export default App;
