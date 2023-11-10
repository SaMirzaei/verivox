FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["Presentation/Verivox.Calculator/Verivox.Calculator.csproj", "Presentation/Verivox.Calculator/"]
COPY ["Core/Verivox.Application/Verivox.Application.csproj", "Core/Verivox.Application/"]
COPY ["Core/Verivox.Domain/Verivox.Domain.csproj", "Core/Verivox.Domain/"]
COPY ["Infrastructure/Verivox.Shared/Verivox.Shared.csproj", "Infrastructure/Verivox.Shared/"]

RUN dotnet restore "Presentation/Verivox.Calculator/Verivox.Calculator.csproj"

COPY . .

WORKDIR "/src/Presentation/Verivox.Calculator"
RUN dotnet build "Verivox.Calculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Verivox.Calculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Verivox.Calculator.dll"]