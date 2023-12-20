"use client";
import {
  Flex,
  Table,
  Tbody,
  Text,
  Th,
  Thead,
  Tr,
  useColorModeValue,
} from "@chakra-ui/react";
import { useRouter } from 'next/navigation';
import { useEffect, useState } from "react";
import Card from "@/components/Dashboard/Cards/Card/Card";
import CardHeader from "@/components/Dashboard/Cards/Card/CardHeader";
import CardBody from "@/components/Dashboard/Cards/Card/CardBody";
import { ChakraProvider } from "@chakra-ui/react";
import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import { tablesUserTableData } from "@/variables/general";
import TablesTableUserRow from "@/components/Dashboard/Tables/TableUserRow";

export default function DashboardUsers() {
  const router = useRouter();
  const textColor = useColorModeValue("gray.700", "white");
  const borderColor = useColorModeValue("gray.200", "gray.600");
  const handleEditClick = (name : string) => {
    console.log("row.name")
    router.push(`/edit/${name}`);
  };

  
  useEffect(() => {
  }, [router]);
  

  return (
    <MaxWidthWrapper>
      <ChakraProvider>
        <Flex direction="column" pt={{ base: "120px", md: "75px" }}>
          <Card overflowX={{ sm: "scroll", xl: "hidden" }} pb="0px">
            <CardHeader p="6px 0px 22px 0px">
              <Text fontSize="xl" color={textColor} fontWeight="bold">
                Страница пользователей
              </Text>
            </CardHeader>
            <CardBody>
              <Table variant="simple" color={textColor}>
                <Thead>
                  <Tr my=".8rem" pl="0px" color="gray.400">
                    <Th pl="0px" borderColor={borderColor} color="gray.400">
                      Пользователь
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Уровень
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Специализация
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Статус
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Контакты
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Добавлен
                    </Th>
                    <Th borderColor={borderColor}></Th>
                  </Tr>
                </Thead>
                <Tbody>
                  {tablesUserTableData.map((row, index, arr) => {
                    return (
                      <TablesTableUserRow
                        name={row.name}
                        logo={row.logo.src}
                        email={row.email}
                        level={row.level}
                        subdomain={row.subdomain}
                        domain={row.domain}
                        status={row.status}
                        contact={row.contact}
                        date={row.date}
                        isLast={index === arr.length - 1 ? true : false}
                        key={index}
                        onEditClick={() => handleEditClick(row.name)}
                      />
                    );
                  })}
                </Tbody>
              </Table>
            </CardBody>
          </Card>
        </Flex>
      </ChakraProvider>
    </MaxWidthWrapper>
  );
}
