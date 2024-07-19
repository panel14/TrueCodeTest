# TrueCodeTest
## Тестовое задание: Инструкции по запуску проекта
1. Docker

Чтобы запустить приложение в контейнерах необходимо склонировать репозиторий, зайти в IDE (рекомендуется Visual Studio) и выбрать конфигурацию docker-compose, затем запустить приложение

2. Локальный запуск

Запустить приложение можно также локально. Для этого сначала необходимо создать базу данных Postgres (строка подключения с параметрами базы указана в ```TrueCodeTest.Api/Configuration/appsettings.json```)

Далее в любой IDE необходимо установить TrueCodeTest.Api как стартовый и запустить приложение.

Для запуска не через IDE необходимо через терминал / командную строку зайти в корень проекта и ввести команду ```dotnet run```.

По умолчанию проект запускается по адресу [http://localhost:5093](http://localhost:5093) (страница swagger будет доступна по адресу [http://localhost:5093/swagger/index.html](http://localhost:5093/swagger/index.html)).

Чтобы изменить профиль запуска (по умолчанию http) нужно ввести команду ```dotnet run --launch-profile https```. Тогда проект будет доступен по адресу [http://localhost:5093](https://localhost:7217) (страница swagger будет доступна по адресу [https://localhost:7217/swagger/index.html](https://localhost:7217/swagger/index.html)).
