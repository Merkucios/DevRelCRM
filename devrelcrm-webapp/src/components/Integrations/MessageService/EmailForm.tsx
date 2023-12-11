"use client";

import { useState, ChangeEvent } from "react";
import { Form, Button, Dropdown, DropdownProps } from "react-bootstrap";
import { sendEmail } from "@/api/MessageSendingAPI";
import { EmailData } from "@/data/MessageSending/EmailData";
import { AttachmentData } from "@/data/MessageSending/AttachmentData";
import AdditionalField from "./AdditionalFormField";

const EmailForm = () => {
  // Состояния для отслеживания выбранных типов и видимости полей
  const [selectedTypes, setSelectedTypes] = useState<string[]>([]);
  const [fieldVisibility, setFieldVisibility] = useState<{
    [key: string]: boolean;
  }>({
    "Получатель скрытой копии": false,
    "Получатель копии": false,
    Отправитель: false,
    "Отображаемое имя": false,
    "Адрес ответа": false,
    "Имя для ответа": false,
  });

  // Обработчик выбора элемента из Dropdown
  const handleDropdownSelect: DropdownProps["onSelect"] = (eventKey, e) => {
    if (typeof eventKey === "string" && !selectedTypes.includes(eventKey)) {
      // Добавление выбранного типа к массиву выбранных типов
      setSelectedTypes((prevTypes) => [...prevTypes, eventKey]);
      // Установка видимости соответствующего поля в true
      setFieldVisibility((prevVisibility) => {
        const updatedVisibility = { ...prevVisibility, [eventKey]: true };
        return updatedVisibility;
      });
    }
  };

  // Обработчик удаления выбранного поля
  const handleRemoveField = (field: string) => {
    // Удаление выбранного типа из массива выбранных типов
    setSelectedTypes((prevTypes) => prevTypes.filter((type) => type !== field));
    // Установка видимости соответствующего поля в false
    setFieldVisibility((prevVisibility) => ({
      ...prevVisibility,
      [field]: false,
    }));
  };

  return (
    <div>
      <h1 className="mb-4 mt-3">Рассылка сообщений</h1>
      <Form>
        {/* Добавление Dropdown для выбора типа адреса */}
        <Form.Group className="mb-3 d-flex align-items-center">
          <Form.Label className="me-3">Добавьте дополнительное поле</Form.Label>
          <Dropdown onSelect={handleDropdownSelect}>
            <Dropdown.Toggle variant="success" id="dropdown-basic">
              {"Выберите"}
            </Dropdown.Toggle>

            <Dropdown.Menu>
              {/* Генерация элементов Dropdown на основе видимости полей */}
              {Object.keys(fieldVisibility).map((type) => (
                // Создание элементов Dropdown на основе видимости каждого типа
                <Dropdown.Item
                  key={type}
                  eventKey={type}
                  disabled={fieldVisibility[type]}
                >
                  {type}
                </Dropdown.Item>
              ))}
            </Dropdown.Menu>
          </Dropdown>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Получатель сообщения</Form.Label>
          <Form.Control type="email" />
        </Form.Group>

        {/* Рендеринг дополнительных полей на основе выбранных типов */}
        {selectedTypes.map((type) => (
          <AdditionalField
            key={type}
            field={type}
            onRemove={handleRemoveField}
          />
        ))}

        <Form.Group className="mb-3">
          <Form.Label>Заголовок сообщения</Form.Label>
          <Form.Control type="text" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Содержимое письма</Form.Label>
          <Form.Control as="textarea" rows={4} />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Добавить вложения</Form.Label>
          <Form.Control type="file" multiple />
        </Form.Group>
      </Form>
    </div>
  );
};

export default EmailForm;
