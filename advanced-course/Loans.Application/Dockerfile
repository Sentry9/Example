FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Loans.Application/Loans.Application.csproj", "src/Loans.Application/"]
RUN dotnet restore "src/Loans.Application/Loans.Application.csproj"
COPY . .
WORKDIR "/src/src/Loans.Application"
RUN dotnet build "Loans.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Loans.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loans.Application.dll"]
