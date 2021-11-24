FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CA.Todos.Api/CA.Todos.Api.csproj", "CA.Todos.Api/"]
RUN dotnet restore "CA.Todos.Api/CA.Todos.Api.csproj"
COPY . .
WORKDIR "/src/CA.Todos.Api"
RUN dotnet build "CA.Todos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CA.Todos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CA.Todos.Api.dll"]