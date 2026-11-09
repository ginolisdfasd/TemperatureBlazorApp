# ЭТАП 1: Сборка приложения в SDK (используем образ .NET 8)
FROM ://microsoft.com AS build-env
WORKDIR /app

# Копируем csproj файл и восстанавливаем NuGet-зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем абсолютно все файлы проекта и публикуем релизную сборку
COPY . ./
RUN dotnet publish -c Release -o out

# ЭТАП 2: Запуск приложения в легковесном Runtime
FROM ://microsoft.com
WORKDIR /app
COPY --from=build-env /app/out .

# Открываем порт 8080 для веб-приложения внутри контейнера
EXPOSE 8080

# Переменная среды для привязки приложения к порту 8080
ENV ASPNETCORE_URLS=http://+:8080

# Команда запуска нашей скомпилированной библиотеки
ENTRYPOINT ["dotnet", "TemperatureBlazorApp.dll"]
