FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /FunnyBot

COPY *.sln .
COPY FunnyBot.Application/*.csproj ./FunnyBot.Application/
COPY FunnyBot.Core/*.csproj ./FunnyBot.Core/
COPY FunnyBot.Bot/*.csproj ./FunnyBot.Bot/
COPY MemeGenerator/*.csproj ./MemeGenerator/
RUN dotnet restore

COPY FunnyBot.Application/. ./FunnyBot.Application/
COPY FunnyBot.Core/. ./FunnyBot.Core/
COPY FunnyBot.Bot/. ./FunnyBot.Bot/
COPY MemeGenerator/. ./MemeGenerator/

WORKDIR /FunnyBot/FunnyBot.Bot
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "FunnyBot.Bot.dll"]