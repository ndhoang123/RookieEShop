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

const App = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/">
        <ListCategory />
      </Route>
    </Switch>
  </BrowserRouter>
)

export default App;