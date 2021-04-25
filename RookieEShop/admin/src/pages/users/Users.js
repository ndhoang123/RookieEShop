import http from "../config";

class users {
  pathSer = "api/User";

  getList() {
    return http.get(this.pathSer);
  }
}

export default new users();