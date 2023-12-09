import axios from "axios";
import MiroBoard from "@/data/MiroBoard";

// Токен доступа к Miro API из переменной окружения
const accessToken = process.env.NEXT_PUBLIC_MIRO_API_TOKEN;

 if (!accessToken) {
   throw new Error("Проверьте поле в .env NEXT_PUBLICMIRO_API_TOKEN. Установите действительное значение переменной окружения.");
 }

const MiroServiceApi =
{
  // Метод для получения списка досок из Miro
  getBoards: async () : Promise<MiroBoard[]> => {
    try {
      // URL для запросов к Miro API , v1 устаревший вариант
      const apiUrl = "https://api.miro.com/v2/boards";
      const headers = {
        accept : `application/json`,
        authorization: `Bearer ${accessToken}`,
      };

      // Выполнение GET-запроса к Miro API с использованием axios
      const response = await axios.get(apiUrl, { headers });

      // Проверка структуры полученных данных
      if ('data' in response.data && Array.isArray(response.data.data)) {
        return response.data.data as MiroBoard[];
      } 
      else 
      {
        // Вывод ошибки, если данные не соответствуют ожидаемой структуре
        throw new Error("Ошибка: Данные не содержат ожидаемую структуру.");
      }
    } catch (error: any) {
      // Вывод ошибки, если произошла ошибка при выполнении запроса
      throw new Error(`Ошибка при получении данных из Miro: ${error.message}`);
    }
  },
};

export default MiroServiceApi;
