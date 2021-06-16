import { createStore } from "redux";
import rootReducer from "./reducers";

const initalState = {};

const store = createStore(rootReducer, initalState);

export default store;