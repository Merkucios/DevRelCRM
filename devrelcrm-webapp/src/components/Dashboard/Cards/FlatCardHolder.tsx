import React from "react";
import { Container, Row } from "react-bootstrap";
import { ReactNode } from "react";

interface FlatCardHolderProps {
  cards: ReactNode;
}

const FlatCardHolder: React.FC<FlatCardHolderProps> = ({ cards }) => {
  return (
    <Container className="d-flex">
      <Row style={{gap: 20}}>
          {cards}
      </Row>
    </Container>
  );
};

export default FlatCardHolder;
