import React, { useState, useEffect } from "react";
import { Table, Button } from "reactstrap";
import UserService from "./Users";

const ListUser = () => {
  const [Users, setUsers] = useState([]);
  useEffect(() => {
    fetchUser();
  }, []);

  const fetchUser = () => {
    UserService.getList().then(({ data }) => {
      setUsers(data);
    });
  };
  console.log(Users);
  return (
    <div>
      <Table bordered>
        <thead>
          <tr>
            <th>#</th>
            <th>User Name</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          {Users.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i}</th>
                <td>{item.userName}</td>
                <td>{item.email}</td>
                <td className="text-right">
                  <Button color="btn btn-primary"><i class="fas fa-unlock">Enable</i></Button>{' '}
                  <Button color="danger"><i class="fas fa-lock">Block</i></Button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default ListUser;