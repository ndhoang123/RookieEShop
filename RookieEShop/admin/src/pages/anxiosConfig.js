import axios from 'axios';
import { host } from "../config";

export default function httpClient(){
  axios.defaults.baseURL = host;
}