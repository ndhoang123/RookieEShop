// in src/App.js
import * as React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { LIST_CATEGORY } from "./constants/page";
import "bootstrap/dist/css/bootstrap.min.css";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import PageLayout from "./containers/PageLayout";
import Router from "./Routers";
import ListCategory from "./pages/categories/ListCategories"
import EditCategories from "./pages/categories/EditCategories";


const App = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/">
        <ListCategory />
      </Route>

      <Route exact path="/EditCategory/:id">
        <EditCategories />
      </Route>
    </Switch>
  </BrowserRouter>
)

export default App;