import { useState } from "react";
import "./App.scss";
import Navbar from "./components/Navbar/Navbar";
import { ThemeProvider } from "@emotion/react";
import theme from "./styles/theme";

function App() {
  const [count, setCount] = useState(0);

  return (
    <ThemeProvider theme={theme}>
      <div className="main-container">
        <Navbar />
      </div>
    </ThemeProvider>
  );
}

export default App;
