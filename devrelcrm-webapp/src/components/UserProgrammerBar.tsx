import React from "react";
import Link from "next/link";
import { Icons } from "./Icons";
import { Nav } from "react-bootstrap";

const UserProgrammerBar = () => {
  return (
    <Nav className="flex-row justify-content-center">
      <Nav.Item className="d-flex mx-2">
        <Icons.git className="img-fluid" />
        <Link
          href="/git"
          className="nav-link link-dark p-2 
            link-body-emphasis link-offset-1 link-underline-opacity-25 link-underline-opacity-75-hover"
        >
          Git репозитории
        </Link>
      </Nav.Item>
    </Nav>
  );
};

export default UserProgrammerBar;
