# DevRelCRM v0.1

В проекте DevRelCRM реализована клиентская и серверная части приложения.

Клиентская часть состоит из Next.js фреймворка, поддерживающий рендеринг на стороне сервера (SSR), статическую генерацию страниц (SG), удобный "чёрный ящик" маршрутизации страниц и горячую перезагрузку билда.

Серверная часть состоит из ASP.NET фреймворка с посадкой на систему оркестрации контейнеров Aspire

## Реализация клиентской части
Клиентская часть содержит в себе адаптивную вёрстку сайта. 
Реализованы страницы и функционал: 
1. Лендинг страница,
2. Интеграция с Miro API (/miro)
3. Рассылка сообщений при помощи DevRelCRM.WebNotificationsAPI (/message-sending)

## Реализация серверной части
Серверная часть выполнена по "луковой" архитектура также известной как "чистая архитектура"
Слой DevRelCRM.Core - представляет собой бизнес-логику системы,
Слой DevRelCRM.Infrastructure - представляет собой реализацию сервисов системы,
Слой DevRelCRM.Application - представляет собой CQRS операции и Mapping между типами слоя Core и ViewModel

### Зависимости приложения
Зависимости клиентской части описаны в файле package.json

Зависимости серверной части автоматически подтягиваются с помощью Nuget-системы

## Требования к развёртыванию программы:
1. Установленный Docker Hub (WSL v2.0)
2. Установленная платформа Node.js (v21.3.0)
3. Установленный пакет SDK .NET 8.0.100 (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
4. Установленная СУБД PostgreSQL с базой данных DevRelCRM (настройки аутентификации можно изменить в appsettings.json сервисов WebAPI и WebAuth

