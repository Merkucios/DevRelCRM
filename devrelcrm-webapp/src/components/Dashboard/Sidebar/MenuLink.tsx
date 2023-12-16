"use client";

import Link from 'next/link';
import { Nav } from 'react-bootstrap';
import { ReactNode } from 'react';

interface MenuLinkProps {
  item: {
    title: string;
    path: string;
    icon: ReactNode; // Замените React.ReactNode на конкретный тип вашего иконного компонента
  };
}

const MenuLink: React.FC<MenuLinkProps> = ({ item }) => {
  return (
    <Link href={item.path}>
      <Nav.Link className={'nav-link'}>
        {item.icon}
        {item.title}
      </Nav.Link>
    </Link>
  );
}

export default MenuLink;