// in src/App.js
import * as React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import Home from "./pages/home";
import "./App.css";
import Footer from "./components/Footer";
import Header from "./components/Header";
import SideBar from "./components/Sidebar";
import { BrowserRouter as Router } from "react-router-dom";
import PageLayout from "./containers/PageLayout";
import Routes from "./route";

const App = () => (
  <Router>
    <PageLayout 
      header={<Header/>}
      nav={<SideBar footer={<Footer />}/>}
      content={<Routes/>}
    />
  </Router>
)

export default App;