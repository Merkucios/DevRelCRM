"use client";
import React from "react";
import { Card } from "react-bootstrap";

interface FlatSocialCardProps {
  imageUrl?: string;
  text1?: string;
  text2?: string;
  subtext1?: string;
  subtext2?: string;
}

const FlatSocialCard: React.FC<FlatSocialCardProps> = ({
  imageUrl,
  text1,
  text2,
  subtext1,
  subtext2,
}) => {
  return (
    <Card className="shadow mb-5 bg-white rounded text-center p-0" style={{maxWidth: "17.5rem"}} >
      <Card.Img
        variant="top"
        src={imageUrl}
        className="img-fluid"
        style={{ width: "17.5rem", height:"12.5rem" }}
      />
      <Card.Body>
        <div className="d-flex justify-content-between">
          <div>
            <Card.Text className="fs-6 m-0">{text1}</Card.Text>
            {subtext1 && (
              <Card.Text className="fs-6 text-muted">{subtext1}</Card.Text>
            )}
          </div>
          <div>
            <Card.Text className="fs-6 m-0">{text2}</Card.Text>
            {subtext2 && (
              <Card.Text className="fs-6 text-muted">{subtext2}</Card.Text>
            )}
          </div>
        </div>
      </Card.Body>
    </Card>
  );
};

export default FlatSocialCard;
