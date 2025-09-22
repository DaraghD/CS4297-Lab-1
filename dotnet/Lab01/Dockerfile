FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Debug -o out
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=builder /app/out ./
ENV ASPNETCORE_URLS=http://+:5280
EXPOSE 5280 5005
RUN apt-get update && apt-get install -y unzip curl \
    && mkdir /vsdbg \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg
ENTRYPOINT ["dotnet", "Lab01.dll"]