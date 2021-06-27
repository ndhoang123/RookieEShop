import http from "axios";

class users {
  pathSer = "api/User";

  getList() {
    return http.get(this.pathSer);
  }
}

export default new users();