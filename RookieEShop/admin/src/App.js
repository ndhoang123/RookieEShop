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
import { Provider } from "react-redux";
import store from './store';
import userManager, { loadUserFromStorage } from "./services/authServices";
import AuthProvider from "./ultis/authProvider";

function App() {
  React.useEffect(() => {
    // fetch current user from cookies
    loadUserFromStorage(store);
  }, []);

  return (
    <Provider store={store}>
      <AuthProvider userManager={userManager} store={store}>
        <Router>
          <PageLayout
            header={<Header />}
            nav={<SideBar footer={<Footer />} />}
            content={<Routes />}
          />
        </Router>
      </AuthProvider>
    </Provider>
  )
}

export default App;