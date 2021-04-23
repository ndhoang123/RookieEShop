import Axios from 'axios'

const config = Axios.create({
    // baseURL: "https://localhost:44305/",
    baseURL: "https://rookieeshop.azurewebsites.net/",
  });
  
export default config;