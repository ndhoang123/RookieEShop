import { History } from "./history";
import { Route } from "react-router-dom";
import {loadUserFromStorage, signinRedirect} from "../services/authServices";
import React from 'react';

export default function ProtectedRoute({
    children,
    component: Component,
    ...rest
}) {
    const [user, setUser] = React.useState(null);
    React.useEffect(() => {
        loadUserFromStorage().then(data => {
            console.log(data);
            if(!data) {
                signinRedirect();
            }
            else setUser(data);})
    }, [])
    return user && <Route {...rest} component={Component} />;
}