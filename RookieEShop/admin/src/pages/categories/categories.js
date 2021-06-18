import http from "../anxiosConfig";

class categories {
  pathSer = "api/Category";

  getList() {
    return http.get(this.pathSer);
  }

  get(id) {
    return http.get(this.pathSer + "/" + id).then(res=>{return res.data});
  }

  edit(id, objectEdit) {
    return http.put(this.pathSer + "/" + id, objectEdit);
  }

  delete(id) {
    return http.delete(this.pathSer + "/" + id);
  }

  create(objectNew) {
    return http.post(this.pathSer, objectNew).then(res =>{ return res.data});
  }
}

export default new categories();