import Axios from 'axios';
import { host } from "../config";

const anxiosConfig = Axios.create({
    baseURL: host,
    // baseURL: "https://rookieeshop.azurewebsites.net/",
  });
  
export default anxiosConfig;