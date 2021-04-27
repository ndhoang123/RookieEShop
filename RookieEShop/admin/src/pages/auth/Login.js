import React from "react";
import { Button } from "reactstrap";
import { signinRedirect } from "../../services/authServices";

export default function Login() {
  const handleClick = () => signinRedirect();
  return (
    <>
      <p>You need to login before continuing.</p>
      <Button color="primary" onClick={handleClick}>
        Login
      </Button>
    </>
  );
}