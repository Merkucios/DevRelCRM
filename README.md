# DevRelCRM

![C# Requirements](https://img.shields.io/badge/.NET-8.100-black?logo=C%23&logoColor=%2321c210&labelColor=white) ![Next.js Requirements](https://img.shields.io/badge/Next.js-14.0.3-black?logo=Next.js&logoColor=%23226eb5&labelColor=white) ![MongoDB Requirements](https://img.shields.io/badge/MongoDB-7.0.4-black?logo=Mongodb&logoColor=%233b9646&labelColor=white) ![PostgreSQL Requirements](https://img.shields.io/badge/PostgreSQL-16.0-black?logo=PostgreSQL&logoColor=%233b4096&labelColor=white) ![License](https://img.shields.io/badge/License-MIT-black?style=plastic&logoColor=%233b4096&labelColor=white) ![Tests](https://img.shields.io/badge/Tests-passed-%233b9656?style=plastic&logoColor=%233b4096&labelColor=white)

<img src="assets/landing.png" align="center">

## Информация о проекте
Это CRM проект для DevRel специалиста выполненный в рамках хакатона «DevRel Hack 2.0» 💥 <br>
В проекте используется Next.js на компонентах TSX (фронтенд) и ASP.NET с "чистой архитектурой" также известная как луковая архитектура (бекенд) 🐱‍👤. <br>

## Требования для развёртывания 👓

| Программное обеспечение | Версии                                        |
|-------------------------|-----------------------------------------------|
| Docker                  | 24.0.6                                        |
| Node.js                 | 10.2.4                                        |
| .NET                    | 8.100                                         |
| PostgreSQL              | 16.0 (+ добавление миграций EntityFramework) |
| MongoDB                 | 7.0.4                                         |

## Схема проекта 👀

<img src="assets/Architecture.png" align="center">

## Техническая часть проекта 👨‍💻
Клиентская часть поделена на гибкие компоненты, которые удобно встраиваются в страницу. Запросы сервера фетчатся с использованием библиотеки axios. <br>
На сайте определены _страницы_ : 
- Главная страница (/)
- Дашборд (/dashboard)
- Информация о пользователях (/dashboard/users)
- Редактирование пользователях (/dashboard/users/edit/[name])
- Информация о проектах организации (/dashboard/projects)
- Информация о прошедших мероприятиях (/dashboard/last-events)
- Календарь мероприятий и тасков специалиста (/calendar)
- Форма для отправки писем с шаблонизатором (/message-sending)
- Интеграция с канбан-досками (/miro) 

На стороне сервера определены микросервисы :
- WebAPI - содержит запросы для работы с данными пользователей системы
- WebAuth - содержит формы регистрации и логина 
- WebNotifications - содержит запросы отправки электронных писем с вложениями и по шаблонам
- ParsersAPI - содержит endpoint для парсинга статей и новостей Хабра

Микросервисы взаимодействуют с базами данных PostgreSQL и MongoDB используя для этого инфраструктурный слой. Данные бизнес-логики (слой Core) маппятся к ViewModel и DTO используя AutoMapper слоя Application.

На таблице приведённой ниже указаны сервисы, которые взаимодействуют с БД. 

| База данных / API | WebAPI | WebAuth | WebNotifications | ParsersAPI |
|-------------------|--------|---------|------------------|------------|
| PostgreSQL        | ✔️      | ❌       | ❌                | ❌          |
| MongoDB           | ❌      | ❌       | ❌                | ✔️          |

В проекте присутствует оркестратор контейнеров Aspire, который является стартапом для поднятия приложения. В данном проекте Aspire реализован слабо, так как на момент проектирования технология является сырой (находится в preview). Чтобы добавить Aspire нужно скачать .NET Aspire SDK в VS 2022 Preview. И после установки ввести комманды
>dotnet workload update<br>
>dotnet workload install aspire 

Для настройки отправки сообщений в WebNotifications требуется добавить данные SMTP-сервера. 
