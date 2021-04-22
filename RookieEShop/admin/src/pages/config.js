import Axios from 'axios'

const config = Axios.create({
    baseURL: "https://rookieeshop.azurewebsites.net",
  });
  
export default config;