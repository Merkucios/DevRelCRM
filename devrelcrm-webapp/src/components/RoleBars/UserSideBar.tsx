"use client";

import React, { useEffect, useState } from "react";
import UserDevRelBar from "./UserDevRelBar";
import { checkAuthentication, getJwtToken, getRoleFromToken } from "@/utils/authUtils";
import UserProgrammerBar from "./UserProgrammerBar";

const UserSideBar = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [userRole, setUserRole] = useState("");

  useEffect(() => {
    const authCheck = checkAuthentication();
    setIsAuthenticated(authCheck);
    if(authCheck){
        const token = getJwtToken();
        const role = getRoleFromToken(token || undefined);
        console.log("User Role:", role);
        setUserRole(role);
    }
  }, []);

  return (
    <div className="d-flex flex-column flex-shrink-1 p-1 text-white bg-light">
      {isAuthenticated && userRole === "DevRel" &&
      <UserDevRelBar /> }
      {isAuthenticated && userRole === "Programmer" &&
      <UserProgrammerBar />}
    </div>
  );
};

export default UserSideBar;
