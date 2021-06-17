import {
    STORE_USER,
    USER_SIGNED_OUT,
    USER_EXPIRED,
    STORE_USER_ERROR,
    LOADING_USER,
} from "../constants/auth";

export function userStore(user) {
    return {
        type: STORE_USER,
        payload: user
    }
};

export function userLoading() {
    return {
        type: LOADING_USER
    }
};

export function userSignedOut() {
    return {
        type: USER_SIGNED_OUT
    }
} 