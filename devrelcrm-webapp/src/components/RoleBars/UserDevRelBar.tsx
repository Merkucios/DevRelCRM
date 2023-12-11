import React from "react";
import Link from "next/link";
import { Icons } from "../Main/Icons";
import { Nav } from "react-bootstrap";

const UserDevRelBar = () => {
  return (
    <Nav className="flex-row justify-content-center">
      <Nav.Item className="d-flex mx-2">
        <Icons.dashboard className="img-fluid" />
        <Link
          href="/dashboard"
          className="nav-link link-dark p-2 
            link-body-emphasis link-offset-1 link-underline-opacity-25 link-underline-opacity-75-hover"
        >
          Дашборд
        </Link>
      </Nav.Item>

      <Nav.Item className="d-flex mx-2">
        <Icons.agile className="img-fluid" />
        <Link
          href="/agile"
          className="nav-link link-dark p-2 
            link-body-emphasis link-offset-1 link-underline-opacity-25 link-underline-opacity-75-hover"
        >
          Канбан доска
        </Link>
      </Nav.Item>

      <Nav.Item className="d-flex mx-2">
        <Icons.calendar className="img-fluid" />
        <Link
          href="/calendar"
          className="nav-link link-dark p-2 
            link-body-emphasis link-offset-1 link-underline-opacity-25 link-underline-opacity-75-hover"
        >
          Календарь мероприятий
        </Link>
      </Nav.Item>

      <Nav.Item className="d-flex mx-2">
        <Icons.letter className="img-fluid" />
        <Link
          href="/message-sending"
          className="nav-link link-dark p-2 
            link-body-emphasis link-offset-1 link-underline-opacity-25 link-underline-opacity-75-hover"
        >
          Рассылка писем
        </Link>
      </Nav.Item>

      <Nav.Item className="d-flex mx-2">
        <Icons.miro className="img-fluid" />
        <Link
          href="/miro"
          className="nav-link link-dark p-2 
            link-body-emphasis link-offset-1 link-underline-opacity-25 link-underline-opacity-75-hover"
        >
          Miro
        </Link>
      </Nav.Item>
    </Nav>
  );
};

export default UserDevRelBar;
