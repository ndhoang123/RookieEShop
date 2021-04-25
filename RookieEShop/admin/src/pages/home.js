import React from "react";
import { Router, Switch, Route, Link } from "react-router-dom";
import {
  LIST_CATEGORY,
  EDIT_CATEGORY,
  CREATE_CATEGORY,
  LIST_USER,
  LIST_PRODUCT,
  EDIT_PRODUCT,
  CREATE_PRODUCT,
  HOME_PAGE,
} from "../constants/page";
import ListCategory from "../pages/categories/ListCategories";
import EditCategories from "../pages/categories/EditCategories";
import ListProduct from "../pages/products/ListProducts";
import EditProducts from "../pages/products/EditProducts";
import ListUser from "../pages/users/ListUsers"
import history from "../helpers/history";

const sidebar = () => {
  return (
    <Router history={history}>
      <div>
        <div className="d-flex" id="wrapper">
          <div className="bg-light border-right" id="sidebar-wrapper">
            <div className="sidebar-heading">RookieEShop </div>
            <div className="list-group list-group-flush">
              <Link
                to={HOME_PAGE}
                className="list-group-item list-group-item-action bg-light"
              >
                Home
              </Link>
              <Link
                to={LIST_USER}
                className="list-group-item list-group-item-action bg-light"
              >
                Users
              </Link>
              <Link
                to={LIST_CATEGORY}
                className="list-group-item list-group-item-action bg-light"
              >
                Categories
              </Link>
              <Link
                to={LIST_PRODUCT}
                className="list-group-item list-group-item-action bg-light"
              >
                Products
              </Link>
            </div>
          </div>
          <div id="page-content-wrapper">
            <nav className="navbar navbar-expand-lg navbar-light bg-light border-bottom">
              <div
                className="collapse navbar-collapse"
                id="navbarSupportedContent"
              >
                <ul className="navbar-nav ml-auto mt-2 mt-lg-0">
                  <li className="nav-item">
                    <Link to={HOME_PAGE}>
                      Welcome, admin!
                    </Link>
                  </li>
                </ul>
              </div>
            </nav>
            <div>
              {" "}
              <Switch>
                <Route exact path={HOME_PAGE}>
                  <h2>Welcome back, my admin!</h2>
                </Route>
                <Route path={LIST_CATEGORY}>
                  <ListCategory />
                </Route>
                <Route path={EDIT_CATEGORY}>
                  <EditCategories />
                </Route>
                <Route path={CREATE_CATEGORY}>
                  <EditCategories />
                </Route>
                <Route path={LIST_USER}>
                  <ListUser />
                </Route>
                <Route path={LIST_PRODUCT}>
                  <ListProduct />
                </Route>
                <Route path={EDIT_PRODUCT}>
                  <EditProducts />
                </Route>
                <Route path={CREATE_PRODUCT}>
                  <EditProducts />
                </Route>
              </Switch>
            </div>
          </div>
        </div>
      </div>
    </Router>
  );
};

export default sidebar;