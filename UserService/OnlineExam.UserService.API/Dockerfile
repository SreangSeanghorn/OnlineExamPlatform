FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7083

ENV ASPNETCORE_URLS=http://+:7083

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["OnlineExam.UserService.API/OnlineExam.UserService.API.csproj", "OnlineExam.UserService.API/"]
RUN dotnet restore "OnlineExam.UserService.API/OnlineExam.UserService.API.csproj"
COPY . .
WORKDIR "/src/OnlineExam.UserService.API"
RUN dotnet build "OnlineExam.UserService.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "OnlineExam.UserService.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineExam.UserService.API.dll"]
