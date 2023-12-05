"use client";

import { Icons } from "./Icons";
import React, { useEffect, useState } from "react";
import Link from "next/link";
import { checkAuthentication } from "@/utils/authUtils";
import { Button } from "react-bootstrap";

const Navbar = () => {
  const authServerUrl = process.env.AUTH_SERVER_URL;
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    setIsAuthenticated(checkAuthentication());
  }, []);

  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container-fluid">
        <Link href="/" className="navbar-brand">
          <Icons.logo className="img-fluid" />
        </Link>

        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <Link href="/help" className="nav-link">
                База знаний
              </Link>
            </li>
          </ul>

          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              {isAuthenticated ? (
                <Button
                  className="btn btn-dark"
                  onClick={() => console.log("Logout logic")}
                >
                  Выйти
                </Button>
              ) : (
                <Link href={authServerUrl + "login"} className="btn btn-dark">
                  Логин
                </Link>
              )}
            </li>
          </ul>
        </div>
      </div>
      <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"
        defer
      ></script>
    </nav>
  );
};

export default Navbar;
