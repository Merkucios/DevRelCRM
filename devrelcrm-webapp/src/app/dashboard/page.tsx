import MaxWidthWrapper from "@/components/Main/MaxWidthWrapper";
import FlatCard from "@/components/Dashboard/Cards/FlatCard";
import { User, ClipboardCheck, MessageCircle, Smile } from "lucide-react";
import FlatCardHolder from "@/components/Dashboard/Cards/FlatCardHolder";
import FlatSocialCard from "@/components/Dashboard/Cards/FlatSocialCard";

export default function Dashboard() {
  return (
    <MaxWidthWrapper>
      <h1 className="mt-3">Привет</h1>
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
    </MaxWidthWrapper>
  );
}
