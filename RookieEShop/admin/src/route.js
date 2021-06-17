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
import { Switch, Route } from "react-router-dom";
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
import HomePage from './pages/home';

function Routes(props) {
    return (
        <Switch>
            <Route path="/login" component={Login}/>
            <Route path="/signin-oidc" component={SigninOidc}/>
            <Route path="/signout-oidc" component={SignoutOidc}/>

            <PrivateRoute exact path={HOME_PAGE} component={HomePage}/>
            <PrivateRoute path={LIST_CATEGORY} component={ListCategory}/>
            <PrivateRoute path={EDIT_CATEGORY} component={EditCategories}/>
            <PrivateRoute path={CREATE_CATEGORY} component={EditCategories}/>
            
            <PrivateRoute path={LIST_PRODUCT} component={ListProduct}/>
            <PrivateRoute path={EDIT_PRODUCT} component={EditProducts}/>
            <PrivateRoute path={CREATE_PRODUCT} component={EditProducts}/>

            <PrivateRoute path={LIST_USER} component={ListUser} />
        </Switch>
    );
}

export default Routes;