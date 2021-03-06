import React from "react";
import { Button } from "reactstrap";
//
import { useSelector } from "react-redux";
import { signoutRedirect } from "../services/authServices";

export default function Header() {
  const user = useSelector((state) => state.auth.user);
  console.log(user);

  const signOut = () => signoutRedirect();

  return (
    <div className="clearfix">
      <div className="float-left">
        <img width="40" src="./logo192.png" alt="" />
      </div>
      {user && (
        <div className="float-right ">
          <span>Hello, {user?.profile.name}</span>
          <Button
            color="link"
            onClick={signOut}
            className="pl-3 text-danger"
            size="sm"
          >
            Sign Out
          </Button>
        </div>
      )}
    </div>
  );
}