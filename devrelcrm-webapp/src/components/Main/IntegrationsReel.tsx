import React from "react";
import ItemReel from "./ItemReel";

const IntegrationsReel = () => {
  return (
    <div>
      <h2 className="text-center mt-1 mb-4">Интеграции приложения</h2>
      <div className="card-group row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
        <div className="card-group col">
          <ItemReel
            imageSrc="headhunter.png"
            title="HeadHunter поисковик"
            description="Уникальные профессионалы в поисках вашей компании"
          />
        </div>
        <div className="card-group col">
          <ItemReel
            imageSrc="habr.png"
            title="Хабр поисковик"
            description="Специалисты страны делятся полезными знаниями"
          />
        </div>
        <div className="card-group col">
          <ItemReel
            imageSrc="mailkit.png"
            title="Рассылка сообщений"
            description="Утилита MailKit предоставляет шикарную возможность рассылки электронных писем"
          />
        </div>
      </div>
    </div>
  );
};

export default IntegrationsReel;
