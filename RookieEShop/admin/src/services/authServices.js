import { UserManager } from "oidc-client";
import { userStore } from "../actions/authAction";
import { host } from "../config";

const config = {
    authority: host,
    client_id: "oidc-react",
    redirect_uri: "http://localhost:3000/signin-oidc",
    response_type: "id_token token",
    scope: "openid profile rookieEShop.API",
    post_logout_redirect_uri: "http://localhost:3000/signout-oidc",
};

const userManager = new UserManager(config);

export async function loadUserFromStorage(store) {
    let user = await userManager.getUser();
    store.dispatch(userStore(user));
    return user;
}

export function signinRedirect() {
    return userManager.signinRedirect();
}

export function signinRedirectCallback() {
    return userManager.signinRedirectCallback();
}

export function signoutRedirect() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect();
}

export function signoutRedirectCallback() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
}

export default userManager;