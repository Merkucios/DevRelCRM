"use client";

import { Col, Row, Nav } from "react-bootstrap";
import { Box, Image, Text } from "@chakra-ui/react";
import {
  checkAuthentication,
  getJwtToken,
  getRoleFromToken,
  getUserNameFromToken,
} from "@/utils/authUtils";
import Link from "next/link";
import { UsersRound, Sparkles, Speech, CalendarCheck2 } from "lucide-react";
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
      {
        title: "Проекты",
        path: "/dashboard/projects",
        icon: <Sparkles />,
      },
      // {
      //   title: "HR-метрики",
      //   path: "/dashboard/hr",
      //   icon: <Speech />,
      // },
      {
        title: "Прошедшие ивенты",
        path: "/dashboard/last-events",
        icon: <CalendarCheck2 />,
      }
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
              className="rounded-circle mx-auto"
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
                <Link className="nav-link d-flex" href={item.path}>
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
