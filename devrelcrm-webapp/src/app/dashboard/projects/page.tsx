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

import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import { ChakraProvider } from "@chakra-ui/react";
import TableProjectRow from "@/components/Dashboard/Tables/TableProjectRow";
import Card from "@/components/Dashboard/Cards/Card/Card";
import CardBody from "@/components/Dashboard/Cards/Card/CardBody";
import CardHeader from "@/components/Dashboard/Cards/Card/CardHeader";
import { tablesProjectData } from "@/variables/general";

export default function DashboardProject() {
  const textColor = useColorModeValue("gray.700", "white");
  const borderColor = useColorModeValue("gray.200", "gray.600");

  return (
    <MaxWidthWrapper>
      <ChakraProvider>
        <CardHeader p="6px 0px 22px 0px">
          <Flex direction="column">
            <Text fontSize="lg" color={textColor} fontWeight="bold" pb=".5rem">
              Таблица проектов
            </Text>
          </Flex>
        </CardHeader>
        <CardBody>
          <Table variant="simple" color={textColor}>
            <Thead>
              <Tr my=".8rem" pl="0px">
                <Th pl="0px" color="gray.500" borderColor={borderColor}>
                  Проект
                </Th>
                <Th color="gray.500" borderColor={borderColor}>
                  Бюджет
                </Th>
                <Th color="gray.500" borderColor={borderColor}>
                  Статус
                </Th>
                <Th color="gray.500" borderColor={borderColor}>
                  Прогресс
                </Th>
                <Th></Th>
              </Tr>
            </Thead>
            <Tbody>
              {tablesProjectData.map((row, index, arr) => {
                return (
                  <TableProjectRow
                    name={row.name}
                    logo={row.logo.src}
                    status={row.status}
                    budget={row.budget}
                    progression={row.progression}
                    isLast={index === arr.length - 1 ? true : false}
                    key={index}
                  />
                );
              })}
            </Tbody>
          </Table>
        </CardBody>
      </ChakraProvider>
    </MaxWidthWrapper>
  );
}
