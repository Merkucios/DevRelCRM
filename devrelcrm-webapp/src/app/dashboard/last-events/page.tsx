"use client";
import {
    Box,
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
import { useEffect, useState } from "react";
import Card from "@/components/Dashboard/Cards/Card/Card";
import CardHeader from "@/components/Dashboard/Cards/Card/CardHeader";
import CardBody from "@/components/Dashboard/Cards/Card/CardBody";
import { tablesCandidateTableData } from "@/variables/general";
import TablesTableCandidateRow from "@/components/Dashboard/Tables/TableCandidateRow";
import PieChart from "@/components/Dashboard/Charts/PieChart";
import { pieChartData, pieChartOptions } from "@/variables/charts";

export default function DashboardLastEvents() {
  const textColor = useColorModeValue("gray.700", "white");
  const borderColor = useColorModeValue("gray.200", "gray.600");

  return (
    <MaxWidthWrapper>
      <ChakraProvider>
        <Flex direction="column" pt={{ base: "120px", md: "75px" }}>
          <Card overflowX={{ sm: "scroll", xl: "hidden" }} pb="0px">
            <CardHeader>
              <Text fontSize="xl" color={textColor} fontWeight="bold">
                Кандидаты с ивентов
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
                      Последнее мероприятие
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Занятое место
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Контакты
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Репозитории
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Дата добавления
                    </Th>
                  </Tr>
                </Thead>
                <Tbody>
                  {tablesCandidateTableData.map((row, index, arr) => {
                    return (
                      <TablesTableCandidateRow
                        name={row.name}
                        logo={row.logo.src}
                        email={row.email}
                        level={row.level}
                        lastEvent={row.lastEvent}
                        place={row.place as string}
                        contact={row.contact}
                        git={row.git}
                        date={row.date}
                        isLast={index === arr.length - 1 ? true : false}
                        key={index}
                      />
                    );
                  })}
                </Tbody>
              </Table>
            </CardBody>
          </Card>
        </Flex>
        <Box minH="300px">
            <PieChart chartData={pieChartData} chartOptions={pieChartOptions} />
        </Box>
      </ChakraProvider>
    </MaxWidthWrapper>
  );
}
