"use client";
// pages/users/edit/[name].tsx
import { NextPage } from 'next';
import EditUserPage from '@/components/Dashboard/Tables/UserManipulation/EditUserPage';
import { UserData } from '@/data/Dashboard/UserData';

interface EditUserPageProps {
  userData: UserData;
}

const EditUser: NextPage<EditUserPageProps> = ({ userData }) => {
  return <EditUserPage userData={userData} />;
};


export default EditUser;
