import { createStore } from "redux";
import thunk from "redux-thunk";
import rootReducer from "./reducers";

const initalState = {};

const store = createStore(rootReducer, initalState);

export default store;