"use client";

import React from "react";
import {
Avatar,
  Tr,
  Td,
  Flex,
  Text,
  Progress,
  Icon,
  Button,
  useColorModeValue,
} from "@chakra-ui/react";
import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import { ChakraProvider } from "@chakra-ui/react";
import { ChevronDownCircle } from "lucide-react";
import { ElementType } from "react";

interface TableProjectRowProps {
  logo: string;
  name: string;
  status: string;
  budget: string;
  progression: number;
  isLast: boolean;
}

export default function TableProjectRow(props: TableProjectRowProps) {
  const { logo, name, status, budget, progression, isLast } = props;
  const textColor = useColorModeValue("gray.500", "white");
  const titleColor = useColorModeValue("gray.700", "white");
  const borderColor = useColorModeValue("gray.200", "gray.600");

  return (
    <Tr>
      <Td
        minWidth={{ sm: "250px" }}
        pl="0px"
        borderColor={borderColor}
        borderBottom={isLast ? "none" : undefined}
      >
        <Flex alignItems="center" py=".8rem" minWidth="100%" flexWrap="nowrap">
        <Avatar src={logo} w="50px" borderRadius="12px" me="18px" />
          <Text
            fontSize="md"
            color={titleColor}
            fontWeight="bold"
            minWidth="100%"
          >
            {name}
          </Text>
        </Flex>
      </Td>
      <Td borderBottom={isLast ? "none" : undefined} borderColor={borderColor}>
        <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
          {budget}
        </Text>
      </Td>
      <Td borderBottom={isLast ? "none" : undefined} borderColor={borderColor}>
        <Text fontSize="md" color={textColor} fontWeight="bold" pb=".5rem">
          {status}
        </Text>
      </Td>
      <Td borderBottom={isLast ? "none" : undefined} borderColor={borderColor}>
        <Flex direction="column">
          <Text
            fontSize="md"
            color="blue.500"
            fontWeight="bold"
            pb=".2rem"
          >{`${progression}%`}</Text>
          <Progress
            colorScheme="blue"
            size="xs"
            value={progression}
            borderRadius="15px"
          />
        </Flex>
      </Td>
      <Td borderBottom={isLast ? "none" : undefined} borderColor={borderColor}>
        <Button p="0px" bg="transparent" variant="no-effects">
          <Icon as={ChevronDownCircle} color="gray.700" cursor="pointer" />
        </Button>
      </Td>
    </Tr>
  );
}
