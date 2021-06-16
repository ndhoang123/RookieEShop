import {
    STORE_USER,
    USER_SIGNED_OUT,
    USER_EXPIRED,
    STORE_USER_ERROR,
    LOADING_USER,
} from "../constants/auth";

const initialState = {
    user: null,
    isLoadingUser: false
};

function authReducer(state= initialState, action){
    switch (action.type) {
        case STORE_USER:
            return {
                ...state,
                isLoadingUser: false,
                user: action.payload
            }
        case USER_SIGNED_OUT:
            return{
                ...state,
                isLoadingUser: false,
                user: null
            }
        case USER_EXPIRED:
        case STORE_USER_ERROR:
        case LOADING_USER:
            return {
                ...state,
                isLoadingUser: true,
            }
        default:
            return state;
    }
}

export default authReducer;