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
import Card from "@/components/Dashboard/Cards/Card/Card";
import CardHeader from "@/components/Dashboard/Cards/Card/CardHeader";
import CardBody from "@/components/Dashboard/Cards/Card/CardBody";
import { ChakraProvider } from "@chakra-ui/react";
import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import { tablesTableData } from "@/variables/general";
import TablesTableRow from "@/components/Dashboard/Tables/TableRow";

export default function DashboardUsers() {
  const textColor = useColorModeValue("gray.700", "white");
  const borderColor = useColorModeValue("gray.200", "gray.600");

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
                      Специализация
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Статус
                    </Th>
                    <Th borderColor={borderColor} color="gray.400">
                      Добавлен
                    </Th>
                    <Th borderColor={borderColor}></Th>
                  </Tr>
                </Thead>
                <Tbody>
                  {tablesTableData.map((row, index, arr) => {
                    return (
                      <TablesTableRow
                        name={row.name}
                        logo={row.logo.src}
                        email={row.email}
                        subdomain={row.subdomain}
                        domain={row.domain}
                        status={row.status}
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
      </ChakraProvider>
    </MaxWidthWrapper>
  );
}
