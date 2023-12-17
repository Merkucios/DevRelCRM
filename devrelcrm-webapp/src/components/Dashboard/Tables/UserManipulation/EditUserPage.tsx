"use client";
import { useState, useEffect } from "react";
import { Flex, Text, Input, Button, useColorModeValue } from "@chakra-ui/react";
import { UserData } from "../../../../data/Dashboard/UserData";
import { ChakraProvider } from "@chakra-ui/react";

interface EditUserPageProps {
  userData: UserData;
}

function EditUserPage({ userData }: EditUserPageProps) {
  const [editedUserData, setEditedUserData] = useState({ ...userData });
  const [isEditing, setIsEditing] = useState(false);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEditedUserData({
      ...editedUserData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSaveChanges = () => {
    console.log("Сохранение изменений", editedUserData);
    setIsEditing(false);
  };

  const handleCancelChanges = () => {
    setEditedUserData({ ...userData });
    setIsEditing(false);
  };

  const handleEditClick = () => {
    setIsEditing(true);
  };

  useEffect(() => {
    // Update editedUserData when userData changes (on mount or prop change)
    setEditedUserData({ ...userData });
  }, [userData]);

  const textColor = useColorModeValue("gray.700", "white");

  return (
    <ChakraProvider>
      <Flex direction="column" mt="4">
        <Text fontSize="xl" color={textColor} fontWeight="bold">
          Редактирование пользователя: {editedUserData.name}
        </Text>
        <Input
          name="name"
          value={isEditing ? editedUserData.name : userData?.name}
          onChange={handleChange}
          mt="2"
          placeholder="Новое имя пользователя"
          isReadOnly={!isEditing}
        />
        <Input
          name="email"
          value={editedUserData.email}
          onChange={handleChange}
          mt="2"
          placeholder="Новый email"
          isReadOnly={!isEditing}
        />
        <Input
          name="level"
          value={editedUserData.subdomain}
          onChange={handleChange}
          mt="2"
          placeholder="Новый уровень"
          isReadOnly={!isEditing}
        />
        <Input
          name="domain"
          value={editedUserData.domain}
          onChange={handleChange}
          mt="2"
          placeholder="Предприятие работы"
          isReadOnly={!isEditing}
        />
        <Input
          name="subdomain"
          value={editedUserData.subdomain}
          onChange={handleChange}
          mt="2"
          placeholder="Должность на предприятии"
          isReadOnly={!isEditing}
        />
        {/* Добавьте другие поля для редактирования */}
        {isEditing ? (
          <>
            <Button mt="2" colorScheme="teal" onClick={handleSaveChanges}>
              Сохранить изменения
            </Button>
            <Button mt="2" colorScheme="gray" onClick={handleCancelChanges}>
              Отменить
            </Button>
          </>
        ) : (
          <Button mt="2" colorScheme="teal" onClick={handleEditClick}>
            Редактировать
          </Button>
        )}
      </Flex>
    </ChakraProvider>
  );
}

export default EditUserPage;
