import axios from "axios";
import { EmailData } from "@/data/MessageSending/EmailData";

// URL для сервера уведомлений
const Notification_Server_Url = process.env.NEXT_PUBLIC_NOTIFICATIONS_SERVER_URL;

// API URL 
const API_URL : string = Notification_Server_Url + 'api/v1/Notification';

// Создание экземпляра axios с базовым URL для удобства отправки запросов
const api = axios.create( {
    baseURL: API_URL,
});


// Функция для отправки электронного письма
export const sendEmail = async (emailData: EmailData): Promise<any> => {
    try {
      // Отправка POST-запроса на сервер уведомлений для отправки электронного письма
      const response = await api.post('/send-email', emailData);
      return response.data;
      
    } catch (error: any) {
      // Обработка ошибок при отправке письма
      console.error('Ошибка отправки письма:', error);
      throw error.response?.data;
    }
  };

  // Функция для отправки электронного письма
  export const sendEmailEvent = async (emailData: { event: string, email: string }): Promise<any> => {
    try {
      // Отправка POST-запроса на сервер уведомлений для отправки электронного письма
      const response = await api.post('/send-event-email', emailData, {
        headers: {
          'Content-Type': 'application/json', // Указываем, что данные в формате JSON
        },
      });
      return response.data;
      
    } catch (error: any) {
      // Обработка ошибок при отправке письма
      console.error('Ошибка отправки письма:', error);
      throw error.response?.data;
    }
  };
  
// Функция для отправки электронного письма с вложением
  export const sendEmailWithAttachment = async (emailData: EmailData ): Promise<any> => {
    try {
      console.log(emailData)
      // Создаем новый объект FormData для формирования данных для отправки
      const formData = new FormData();

      // Добавляем в FormData получателей, тему и тело письма
      ['to', 'bcc', 'cc'].forEach((recipientType) => {
        const recipients = emailData[recipientType as keyof EmailData];
      
        if (Array.isArray(recipients)) {
          for (let i = 0; i < recipients.length; i++) {
            formData.append(`${recipientType}[]`, recipients[i]);
          }
        }
      });
      
      formData.append('from', emailData.from ?? "");
      formData.append('displayName', emailData.displayName ?? "");
      formData.append('replyTo', emailData.replyTo ?? "");
      formData.append('replyToName', emailData.replyToName ?? "");


      formData.append('subject', emailData.subject);
      formData.append('body', emailData.body ?? "");

      // Если есть вложения, добавляем их в FormData
      if (emailData.attachments) {
        const attachmentFiles = emailData.attachments.getAll('Attachments');
        for (let i = 0; i < attachmentFiles.length; i++) {
          formData.append('Attachments', attachmentFiles[i]);
        }
      }

      // Отправка POST-запроса с указанием 'multipart/form-data' в заголовке для работы с файлами
      const response = await api.post('/send-email-with-attachment', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      console.log(response);

      return response.data;
    } catch (error: any) {
      // Обработка ошибок при отправке письма с вложением
      console.error('Ошибка отправки письма с вложением:', error);
      throw error.response?.data;
    }
};