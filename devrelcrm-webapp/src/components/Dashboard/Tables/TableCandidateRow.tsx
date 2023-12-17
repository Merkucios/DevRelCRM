"using client";

import {
  Avatar,
  Badge,
  Button,
  Flex,
  Td,
  Text,
  Tr,
  useColorModeValue,
} from "@chakra-ui/react";
import React from "react";
import Link from "next/link";

interface TablesTableCandidateRowProps {
  logo: string;
  name: string;
  email: string;
  level?: string;
  lastEvent?: string;
  place?: string;
  date: string;
  contact?: string;
  git?: string;
  isLast: boolean;
}

function TablesTableCandidateRow(props: TablesTableCandidateRowProps) {
  const {
    logo,
    name,
    email,
    level,
    lastEvent,
    place,
    date,
    contact,
    git,
    isLast,
  } = props;
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
        borderBottom={isLast ? undefined : "none"}
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
      <Td borderColor={borderColor} borderBottom={isLast ? undefined : "none"}>
        <Text fontSize="md" color={textColor} fontWeight="bold">
          {level}
        </Text>
      </Td>
      <Td borderColor={borderColor} borderBottom={isLast ? undefined : "none"}>
        <Text fontSize="md" color={textColor} fontWeight="bold">
          {lastEvent}
        </Text>
      </Td>
      <Td borderColor={borderColor} borderBottom={isLast ? undefined : "none"}>
        <Text
          fontSize="md"
          color={
            place !== undefined
              ? parseInt(place) === 1
                ? "orange"
                : parseInt(place) === 2
                ? "silver"
                : parseInt(place) === 3
                ? "bronze"
                : textColor
              : textColor
          }
          fontWeight="bold"
        >
          {place}
        </Text>
      </Td>
      <Td borderColor={borderColor} borderBottom={isLast ? undefined : "none"}>
        <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
          {contact}
        </Text>
      </Td>
      <Td borderColor={borderColor} borderBottom={isLast ? undefined : "none"}>
        <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
          {git}
        </Text>
      </Td>
      <Td borderColor={borderColor} borderBottom={isLast ? undefined : "none"}>
        <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
          {date}
        </Text>
      </Td>
    </Tr>
  );
}

export default TablesTableCandidateRow;
