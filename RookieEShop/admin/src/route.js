import React from 'react';
import {
    LIST_CATEGORY,
    EDIT_CATEGORY,
    CREATE_CATEGORY,
    LIST_USER,
    LIST_PRODUCT,
    EDIT_PRODUCT,
    CREATE_PRODUCT,
    HOME_PAGE,
  } from "./constants/page";
import { Switch, Route, Redirect } from "react-router-dom";
import ListCategory from "./pages/categories/ListCategories";
import EditCategories from "./pages/categories/EditCategories";
import ListProduct from "./pages/products/ListProducts";
import EditProducts from './pages/products/EditProducts';
import ListUser from "./pages/users/ListUsers";
//authen
import SigninOidc from "./pages/auth/Signin-oidc";
import SignoutOidc from "./pages/auth/Signout-oidc";
import PrivateRoute from "./ultis/protectedRoute";
import Login from "./pages/auth/Login";

function Routes(props) {
    return (
        <Switch>
            <Route path="/login" component={Login}/>
            <Route path="/signin-oidc" component={SigninOidc}/>
            <Route path="/signout-oidc" component={SignoutOidc}/>
            <Redirect exact from="/" to="/" />

            <PrivateRoute path="/categories" component={ListCategory}/>
            <PrivateRoute path="/products" component={ListProduct}/>
            <PrivateRoute path="/users" component={ListUser} />
            {/* <Route exact path={HOME_PAGE}>
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
            </Route> */}
        </Switch>
    );
}

export default Routes;