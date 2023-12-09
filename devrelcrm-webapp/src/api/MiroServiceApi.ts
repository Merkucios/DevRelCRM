import axios from "axios";
import MiroBoard from "@/data/MiroBoard";

const accessToken = process.env.NEXT_PUBLIC_MIRO_API_TOKEN;

 if (!accessToken) {
   throw new Error("Проверьте поле в .env MIRO_API_TOKEN. Установите переменную окружения.");
 }

const MiroServiceApi =
{
  getBoards: async () : Promise<MiroBoard[]> => {
    try {
      const apiUrl = "https://api.miro.com/v2/boards";
      const headers = {
        accept : `application/json`,
        authorization: `Bearer ${accessToken}`,
      };

      const response = await axios.get(apiUrl, { headers });

      if ('data' in response.data && Array.isArray(response.data.data)) {
        return response.data.data as MiroBoard[];
      } 
      else 
      {
        console.error("Ошибка: Данные не содержат ожидаемую структуру.");
        throw new Error("Ошибка: Данные не содержат ожидаемую структуру.");
      }
    } catch (error: any) {
      throw new Error(`Ошибка при получении данных из Miro: ${error.message}`);
    }
  },
};

export default MiroServiceApi;
