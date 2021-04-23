// in src/App.js
import * as React from "react";
import { Router, Route, Switch } from "react-router-dom";
import history from './helpers/history';
import { LIST_CATEGORY } from "./constants/page";
import "bootstrap/dist/css/bootstrap.min.css";
import ListCategory from "./pages/categories/ListCategories";
import EditCategories from "./pages/categories/EditCategories";
import ListProduct from "./pages/products/ListProducts";
import EditProducts from "./pages/products/EditProducts";


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

      <Route exact path="/Product">
        <ListProduct />
      </Route>

      <Route exact path="/EditProduct/:id">
        <EditProducts />
      </Route>

      <Route exact path="/NewProduct">
        <EditProducts />
      </Route>
    </Switch>
  </Router>
)

export default App;