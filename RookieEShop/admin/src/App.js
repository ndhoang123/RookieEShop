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
import ListUser from "./pages/users/ListUsers"


const App = () => (
  <Router history={history}>
    <Switch>
      <Route exact path="/">
        <ListCategory />
      </Route>

      <Route exact path={["/EditCategory/:id", "/NewCategory"]}>
        <EditCategories />
      </Route>
      
      <Route exact path="/Product">
        <ListProduct />
      </Route>

      <Route exact path={["/EditProduct/:id", "/NewProduct"]}>
        <EditProducts />
      </Route>

      <Route exact path="/User">
        <ListUser />
      </Route>
    </Switch>
  </Router>
)

export default App;