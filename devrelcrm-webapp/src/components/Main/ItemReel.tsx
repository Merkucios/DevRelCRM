import Image from "next/image";
import React from "react";

interface ItemProps {
  imageSrc: string;
  title: string;
  description: string;
}

const IntegrationItem: React.FC<ItemProps> = ({
  imageSrc,
  title,
  description,
}) => {
  return (
    <div className="card">
      <Image width={150} height={150}
        src={"/" + imageSrc}
        className="card-img-top"
        alt={`${title} Image`}
        style={{ objectFit: "contain",}}
      />
      <div className="card-body">
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{description}</p>
      </div>
    </div>
  );
};

export default IntegrationItem;
