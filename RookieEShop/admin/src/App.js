// in src/App.js
import * as React from "react";
import { BrowserRouter, Route } from "react-router-dom";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";

const App = () => (
  <BrowserRouter>
      <Header />
      <Sidebar />
  </BrowserRouter>
)

export default App;