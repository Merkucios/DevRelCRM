"use client";

import { useState, ChangeEvent, FormEvent } from "react";
import { Form, Button, Dropdown, DropdownProps } from "react-bootstrap";
import { sendEmail, sendEmailWithAttachment } from "@/api/MessageSendingAPI";
import { EmailData } from "@/data/MessageSending/EmailData";
import AdditionalField from "./AdditionalFormField";

// Компонент формы отправки электронной почты
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

  const [formData, setFormData] = useState<EmailData>({
    to: [],
    subject: "",
    body: "",
    attachments: new FormData(),
  });

  // Состояние для отслеживания отправки сообщения
  const [sending, setSending] = useState(false);

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

  // Обработчик изменения адреса электронной почты
  const handleEmailChange = (e: ChangeEvent<HTMLInputElement>) => {
    // Разделяем строку с адресами по запятой
    const emails = e.target.value.split(",");

    // Удаляем лишние пробелы у каждого адреса
    const trimmedEmails = emails.map((email) => email.trim());

    // Обновляем форму с массивом адресов
    updateFormData("to", trimmedEmails, formData, setFormData);
  };

  // Обработчик изменения вложенных файлов
  const handleFileInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const files = e.target.files;
    if (files) {
      const newFormData = new FormData();

      Array.from(files).forEach((file: File) => {
        console.log("Adding file:", file);
        newFormData.append("Attachments", file);
      });

      updateFormData("attachments", newFormData, formData, setFormData);
    }
  };

  // Функция обновления данных формы
  // Обобщение T является подтипом объединения ключей типа EmailData -> T одно из полей EmailData
  const updateFormData = <T extends keyof EmailData>(
    key: T, // ключ - название поля данных формы
    value: EmailData[T], // значение, которое нужно установить для указанного ключа
    formData: EmailData, // текущие данные формы EmailData
    setFormData: React.Dispatch<React.SetStateAction<EmailData>> // функция для установки новых данных формы
  ) => {
    setFormData((prevFormData) => ({
      ...prevFormData, // копирование предыдущих данных формы
      [key]: value, // установка нового значения для указанного ключа
    }));
  };

  // Обработчик отправки формы
  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    if (sending) {
      // Если уже отправка в процессе, выход из функции
      return;
    }

    try {
      // Устанавливаем флаг отправки в true
      setSending(true);
      console.log(formData.attachments);

      if (
        formData.attachments &&
        formData.attachments.getAll("Attachments").length > 0
      ) {
        await sendEmailWithAttachment(formData);
      } else {
        console.log("отправка по sendEmail");
        await sendEmail(formData);
      }

      console.log("Сообщение успешно отправлено!!!");
    } catch (error) {
      console.error("Произошла ошибка отправки сообщения:", error);
    } finally {
      // Сбрасываем флаг отправки в false независимо от результата
      setSending(false);
    }
  };

  return (
    <div>
      <h1 className="mb-4 mt-3">Рассылка сообщений</h1>
      <Form onSubmit={handleSubmit}>
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
          <Form.Control type="text" onChange={handleEmailChange} />
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
          <Form.Control
            type="text"
            onChange={(e) =>
              setFormData((prevData) => ({
                ...prevData,
                subject: e.target.value,
              }))
            }
          />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Содержимое письма</Form.Label>
          <Form.Control
            as="textarea"
            rows={4}
            onChange={(e) =>
              setFormData((prevData) => ({ ...prevData, body: e.target.value }))
            }
          />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Добавить вложения</Form.Label>
          <Form.Control type="file" multiple onChange={handleFileInputChange} />
        </Form.Group>
        <Button
          className="mt-2"
          variant="primary"
          type="submit"
          disabled={sending}
        >
          {sending ? "Отправка..." : "Отправить"}
        </Button>
      </Form>
    </div>
  );
};

export default EmailForm;
