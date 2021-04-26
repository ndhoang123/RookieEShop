import http from "../anxiosConfig";

class users {
  pathSer = "api/User";

  getList() {
    return http.get(this.pathSer);
  }
}

export default new users();