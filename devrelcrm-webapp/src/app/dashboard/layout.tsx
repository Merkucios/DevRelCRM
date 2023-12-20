import Sidebar from "@/components/Dashboard/Sidebar/SideBar";
import { Container } from "react-bootstrap";

export default function LayoutDashboard({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <div className="d-flex min-vh-100">
      <Sidebar />
      <Container fluid className="flex-grow-1">
        {children}
      </Container>
    </div>
  );
}
