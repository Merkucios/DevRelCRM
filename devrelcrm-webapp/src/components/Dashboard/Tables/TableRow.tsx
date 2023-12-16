"using client";

import {
    Avatar,
    Badge,
    Button,
    Flex,
    Td,
    Text,
    Tr,
    useColorModeValue
  } from "@chakra-ui/react";
  import React from "react";
  
  interface TablesTableRowProps {
    logo: string;
    name: string;
    email: string;
    subdomain: string;
    domain: string;
    status: string;
    date: string;
    isLast: boolean;
  }

  function TablesTableRow(props: TablesTableRowProps) {
    const { logo, name, email, subdomain, domain, status, date, isLast } = props;
    const textColor = useColorModeValue("gray.600", "white");
    const titleColor = useColorModeValue("gray.700", "white");
    const bgStatus = useColorModeValue("gray.400", "navy.900");
    const borderColor = useColorModeValue("gray.200", "gray.600");
  
    return (
      <Tr>
        <Td
          minWidth={{ sm: "250px" }}
          pl="0px"
          borderColor={borderColor}
          borderBottom={isLast ? undefined  : "none"}
        >
          <Flex align="center" py=".8rem" minWidth="100%" flexWrap="nowrap">
            <Avatar src={logo} w="50px" borderRadius="12px" me="18px" />
            <Flex direction="column">
              <Text
                fontSize="md"
                color={titleColor}
                fontWeight="bold"
                minWidth="100%"
              >
                {name}
              </Text>
              <Text fontSize="sm" color="gray.400" fontWeight="normal">
                {email}
              </Text>
            </Flex>
          </Flex>
        </Td>
  
        <Td borderColor={borderColor} borderBottom={isLast ? undefined  : "none"}>
          <Flex direction="column">
            <Text fontSize="md" color={textColor} fontWeight="bold">
              {domain}
            </Text>
            <Text fontSize="sm" color="gray.400" fontWeight="normal">
              {subdomain}
            </Text>
          </Flex>
        </Td>
        <Td borderColor={borderColor} borderBottom={isLast ? undefined  : "none"}>
          <Badge
            bg={status === "Свободен" ? "green.400" : status === "Участвует" ? "red.400" : bgStatus}
            color={status === "Свободен" || status === "Участвует" ? "white" : "white"}
            fontSize="16px"
            p="3px 10px"
            borderRadius="8px"
          >
            {status}
          </Badge>
        </Td>
        <Td borderColor={borderColor} borderBottom={isLast ? undefined  : "none"}>
          <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
            {date}
          </Text>
        </Td>
        <Td borderColor={borderColor} borderBottom={isLast ? undefined  : "none"}>
          <Button p="0px" bg="transparent" variant="no-effects">
            <Text
              fontSize="md"
              color="gray.400"
              fontWeight="bold"
              cursor="pointer"
            >
              Изменить
            </Text>
          </Button>
        </Td>
      </Tr>
    );
  }
  
  export default TablesTableRow;
  