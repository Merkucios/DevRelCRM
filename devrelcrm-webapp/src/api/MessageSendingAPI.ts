import axios from "axios";
import { EmailData } from "@/data/MessageSending/EmailData";

const API_URL : string = 'https://localhost:7021/api/v1/Notification';

const api = axios.create( {
    baseURL: API_URL,
});

export const sendEmail = async (emailData: EmailData): Promise<any> => {
    try {
      const response = await api.post('/send-email', emailData);
      return response.data;
    } catch (error: any) {
      console.error('Ошибка отправки письма:', error);
      throw error.response.data;
    }
  };

  export const sendEmailWithAttachment = async (emailData: FormData): Promise<any> => {
    try {
      const response = await api.post('/send-email-with-attachment', emailData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      return response.data;
    } catch (error: any) {
      console.error('Ошибка отправки письма с вложением:', error);
      throw error.response.data;
    }
};