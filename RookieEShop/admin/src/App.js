// in src/App.js
import * as React from "react";
import { Router, Route, Switch } from "react-router-dom";
import { LIST_CATEGORY } from "./constants/page";
import "bootstrap/dist/css/bootstrap.min.css";
import ListCategory from "./pages/categories/ListCategories"
import EditCategories from "./pages/categories/EditCategories";
import history from './helpers/history';


const App = () => (
  <Router history={history}>
    <Switch>
      <Route exact path="/">
        <ListCategory />
      </Route>

      <Route exact path="/EditCategory/:id">
        <EditCategories />
      </Route>

      <Route exact path="/NewCategory">
        <EditCategories />
      </Route>
    </Switch>
  </Router>
)

export default App;