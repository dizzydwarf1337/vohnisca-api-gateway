FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY . .
WORKDIR /app/vohnisca-api-gateway
EXPOSE 5000
CMD ["dotnet", "watch"]
