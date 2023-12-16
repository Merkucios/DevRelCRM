"use client";

import { Col, Row, Nav } from "react-bootstrap";
import {
  checkAuthentication,
  getJwtToken,
  getRoleFromToken,
  getUserNameFromToken,
} from "@/utils/authUtils";
import Image from "next/image";
import Link from "next/link";
import { UsersRound, Code2, PersonStanding, Sparkles } from "lucide-react";
import { useEffect, useState } from "react";
import styles from "./SideBar.module.css";

const menuItems = [
  {
    list: [
      {
        title: "Пользователи",
        path: "/dashboard/users",
        icon: <UsersRound />,
      },
    ],
  },
  {
    list: [
      {
        title: "Проекты",
        path: "/dashboard/projects",
        icon: <Sparkles />,
      },
    ],
  },
];

const Sidebar = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [userRole, setUserRole] = useState("");
  const [userName, setUserName] = useState("");
  const [isClient, setIsClient] = useState(false);

  useEffect(() => {
    const authCheck = checkAuthentication();
    setIsAuthenticated(authCheck);
    if (authCheck) {
      const token = getJwtToken();
      const role = getRoleFromToken(token || undefined);
      const username = getUserNameFromToken(token || undefined);
      setUserRole(role);
      setUserName(username);
    }
    setIsClient(true);
  }, []);

  return (
    <div className={`${styles.menu} bg-light`} id="sidebar">
      <Row className="d-flex flex-column align-items-center p-3">
        <Col className="text-center">
          {isClient && (
            <Image
              className="rounded-circle"
              src="/icon-site.png"
              alt=""
              width="50"
              height="50"
            />
          )}
          <div>
            <span className="d-block fw-bold">{userName}</span>
            <span className="d-block text-muted">{userRole}</span>
          </div>
        </Col>
      </Row>

      <Nav defaultActiveKey="/dashboard/users" className="flex-column">
        {menuItems.map((cat) => (
          <Nav>
            {cat.list.map((item) => (
              <Nav.Item key={item.title}>
                <Link className="nav-link" href={item.path}>
                  {item.icon} {item.title}
                </Link>
              </Nav.Item>
            ))}
          </Nav>
        ))}
      </Nav>
    </div>
  );
};

export default Sidebar;
