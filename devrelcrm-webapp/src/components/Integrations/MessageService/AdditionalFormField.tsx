import React from "react";
import { Form, Button } from "react-bootstrap";

// Определение интерфейса свойств для компонента AdditionalField
interface AdditionalFieldProps {
  field: string;
  onRemove: (field: string) => void;
  onFieldChange: (field: string, value: string) => void;
}

// Определение функционального компонента AdditionalField
const AdditionalField: React.FC<AdditionalFieldProps> = ({
  field,
  onRemove,
  onFieldChange,
}) => {

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    onFieldChange(field, value);
  };

  return (
    // Группа формы для дополнительного поля с уникальным ключом
    <Form.Group key={field} className="mb-3">
    {/* Метка формы, отображающая тип дополнительного поля */}
      <Form.Label>{field}</Form.Label>
      <div className="d-flex align-items-center">
        {/* Поле ввода текста с указанием типа поля в качестве подсказки */}
        <Form.Control
          type="text"
          placeholder={`Введите ${field.toLowerCase()}`}
          onChange={handleChange}
        />
        {/* Кнопка удаления поля с обработчиком события onClick */}
        <Button variant="danger" onClick={() => onRemove(field)}>
          Удалить
        </Button>
      </div>
    </Form.Group>
  );
};

export default AdditionalField;
