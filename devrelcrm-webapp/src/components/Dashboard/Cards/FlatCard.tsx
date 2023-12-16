"use client";
import { ReactNode } from "react";
import { Card } from "react-bootstrap";

interface FlatCardProps {
  icon?: string | ReactNode;
  text?: string;
  subText?: string;
}

const FlatCard: React.FC<FlatCardProps> = ({ icon, text, subText }) => {
  return (
    <Card
      className="shadow p-3 mt-2 mb-5 bg-white rounded text-center"
      style={{ width: "17.5rem"}}
    >
      <Card.Body className="p-0">
        {icon && typeof icon === "string" ? (
          <Card.Img
            className={`img-fluid mx-auto d-block`}
            src={icon as string}
          />
        ) : (
          icon
        )}
        {text && <Card.Text className="mt-1 fs-3">{text}</Card.Text>}
        {subText && (
          <Card.Text className="fs-6 text-muted">{subText}</Card.Text>
        )}
      </Card.Body>
    </Card>
  );
};

export default FlatCard;
