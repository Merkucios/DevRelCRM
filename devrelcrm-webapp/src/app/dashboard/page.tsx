"use client";

import {
  Box,
  Flex,
  Progress,
  Table,
  Tbody,
  Td,
  Text,
  Th,
  Thead,
  Tr,
  useColorModeValue,
} from "@chakra-ui/react";

import Card from "@/components/Dashboard/Cards/Card/Card";
import { ChakraProvider } from "@chakra-ui/react";
import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import FlatCard from "@/components/Dashboard/Cards/FlatCard";
import { User, ClipboardCheck, MessageCircle, Smile } from "lucide-react";
import FlatCardHolder from "@/components/Dashboard/Cards/FlatCardHolder";
import FlatSocialCard from "@/components/Dashboard/Cards/FlatSocialCard";

import BarChart from "@/components/Dashboard/Charts/BarChart";
import { pageVisits, socialTraffic } from "@/variables/general";

import {
  barChartData,
  barChartOptions,
} from "@/variables/charts";

export default function Dashboard() {
  const textColor = useColorModeValue("gray.900", "white");
  const tableRowColor = useColorModeValue("#F7FAFC", "navy.900");
  const borderColor = useColorModeValue("gray.200", "gray.600");
  const textTableColor = useColorModeValue("gray.700", "white");

  return (
    <MaxWidthWrapper>
      <ChakraProvider>
        <div className="mt-4"></div>
        <FlatCardHolder
          cards={[
            <>
              <FlatCard
                icon={<User color="orange" size={61} />}
                text="2581"
                subText="Активных участников"
              ></FlatCard>
              <FlatCard
                icon={<ClipboardCheck color="#24adef" size={61} />}
                text="1029"
                subText="Проведённых митапов"
              ></FlatCard>
              <FlatCard
                icon={<MessageCircle color="#f3642d" size={61} />}
                text="3094"
                subText="Сообщений от участников"
              ></FlatCard>
              <FlatCard
                icon={<Smile color="#71cf49" size={61} />}
                text="91%"
                subText="Фидбек участников"
              ></FlatCard>
            </>,
          ]}
        ></FlatCardHolder>

        <FlatCardHolder
          cards={[
            <FlatSocialCard
              imageUrl="/vk.jpg"
              text1="35.4k"
              subtext1="Подписчиков"
              text2="192.1k"
              subtext2="Лайков"
            />,
            <FlatSocialCard
              imageUrl="/youtube.jpg"
              text1="10.4k"
              subtext1="Подписчиков"
              text2="61.4k"
              subtext2="Лайков"
            />,
            <FlatSocialCard
              imageUrl="/habr_logo.png"
              text1="898.34"
              subtext1="Рейтинг"
              text2="433"
              subtext2="Статей"
            />,
            <FlatSocialCard
              imageUrl="/telegram.webp"
              text1="13.5k"
              subtext1="Подписчиков"
              text2="102.3k"
              subtext2="Реакций"
            />,
          ]}
        />
        <Card p="0px" maxW={{ sm: "320px", md: "100%" }}>
          <Flex direction="column" mb="40px" p="28px 0px 0px 22px">
            <Text color="gray.800" fontSize="sm" fontWeight="bold" mb="6px">
              Вовлечённость
            </Text>
            <Text color="gray.800" fontSize="lg" fontWeight="bold">
              Количества пользователей
            </Text>
          </Flex>
          <Box minH="300px">
            <BarChart chartData={barChartData} chartOptions={barChartOptions} />
          </Box>
        </Card>

        <Flex
          flexDirection="row"
          align="center"
          justify="center"
          w="100%"
          gap={30}
          mt={25}
        >
          <Card p="0px" maxW={{ sm: "320px", md: "100%" }}>
            <Flex direction="column">
              <Flex align="center" justify="space-between" p="22px">
                <Text fontSize="lg" color={textColor} fontWeight="bold">
                  Характеристика уровня специалистов
                </Text>
              </Flex>
              <Box overflow={{ sm: "scroll", lg: "hidden" }}>
                <Table>
                  <Thead>
                    <Tr bg={tableRowColor}>
                      <Th color="gray.400" borderColor={borderColor}>
                        Уровень специалиста
                      </Th>
                      <Th color="gray.400" borderColor={borderColor}>
                        Количество
                      </Th>
                      <Th color="gray.400" borderColor={borderColor}>
                        Рейтинг участия в мероприятиях
                      </Th>
                    </Tr>
                  </Thead>
                  <Tbody>
                    {pageVisits.map((el, index, arr) => {
                      return (
                        <Tr key={index}>
                          <Td
                            color={textTableColor}
                            fontSize="sm"
                            fontWeight="bold"
                            borderColor={borderColor}
                            border={
                              index === arr.length - 1 ? "none" : undefined
                            }
                          >
                            {el.dev_level}
                          </Td>
                          <Td
                            color={textTableColor}
                            fontSize="sm"
                            border={
                              index === arr.length - 1 ? "none" : undefined
                            }
                            borderColor={borderColor}
                          >
                            {el.count}
                          </Td>
                          <Td
                            color={textTableColor}
                            fontSize="sm"
                            border={
                              index === arr.length - 1 ? "none" : undefined
                            }
                            borderColor={borderColor}
                          >
                            {el.rating}
                          </Td>
                        </Tr>
                      );
                    })}
                  </Tbody>
                </Table>
              </Box>
            </Flex>
          </Card>

          <Card p="0px" maxW={{ sm: "320px", md: "100%" }}>
            <Flex direction="column">
              <Flex direction="column" p="28px 0px 0px 22px">
                <Text color="gray.800" fontSize="lg" fontWeight="bold" mb="6px">
                  Текущие мероприятия
                </Text>
                <Text color="gray.800" fontSize="sm" fontWeight="bold">
                  Количество участников
                </Text>
              </Flex>
            </Flex>
            <Box overflow={{ sm: "scroll", lg: "hidden" }}>
              <Table>
                <Thead>
                  <Tr bg={tableRowColor}>
                    <Th color="gray.400" borderColor={borderColor}>
                      Мероприятие
                    </Th>
                    <Th color="gray.400" borderColor={borderColor}>
                      Участники
                    </Th>
                    <Th color="gray.400" borderColor={borderColor}>
                      Прогресс
                    </Th>
                  </Tr>
                </Thead>
                <Tbody>
                  {socialTraffic.map((el, index, arr) => {
                    return (
                      <Tr key={index}>
                        <Td
                          color={textTableColor}
                          fontSize="sm"
                          fontWeight="bold"
                          borderColor={borderColor}
                          border={index === arr.length - 1 ? "none" : undefined}
                        >
                          {el.referral}
                        </Td>
                        <Td
                          color={textTableColor}
                          fontSize="sm"
                          borderColor={borderColor}
                          border={index === arr.length - 1 ? "none" : undefined}
                        >
                          {el.visitors}
                        </Td>
                        <Td
                          color={textTableColor}
                          fontSize="sm"
                          borderColor={borderColor}
                          border={index === arr.length - 1 ? "none" : undefined}
                        >
                          <Flex align="center">
                            <Text
                              color={textTableColor}
                              fontWeight="bold"
                              fontSize="sm"
                              me="12px"
                            >{`${el.percentage}%`}</Text>
                            <Progress
                              size="xs"
                              colorScheme={el.color}
                              value={el.percentage}
                              minW="120px"
                            />
                          </Flex>
                        </Td>
                      </Tr>
                    );
                  })}
                </Tbody>
              </Table>
            </Box>
          </Card>
        </Flex>
      </ChakraProvider>
    </MaxWidthWrapper>
  );
}
