import http from "../config";

class categories {
  pathSer = "api/Category";

  getList() {
    return http.get(this.pathSer);
  }

  get(id) {
    return http.get(this.pathSer + "/" + id);
  }

  edit(id, objectEdit) {
    return http.put(this.pathSer + "/" + id, objectEdit);
  }

  delete(id) {
    return http.delete(this.pathSer + "/" + id);
  }

  create(objectNew) {
    return http.post(this.pathSer, objectNew);
  }
}

export default new categories();