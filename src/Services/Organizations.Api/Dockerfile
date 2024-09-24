ARG DOTNET_VERSION=8.0

ARG APP_NAME=Organizations.Api
ARG APP_SRC_PATH=src/Services/Organizations.Api


# -------------------- dotnet-app --------------------- #
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-bookworm-slim AS dotnet-app

ARG APP_NAME
ARG APP_SRC_PATH

WORKDIR /contextualized-notification-platform

COPY ./src/Services/Organizations.Api/Organizations.Api.csproj ./src/Services/Organizations.Api/
COPY ./src/Libraries/Organizations.Domain/Organizations.Domain.csproj ./src/Libraries/Organizations.Domain/
COPY ./src/Libraries/Organizations.Domain.Fixtures/Organizations.Domain.Fixtures.csproj ./src/Libraries/Organizations.Domain.Fixtures/
COPY ./src/Libraries/Api.Infrastructure.Server/Api.Infrastructure.Server.csproj ./src/Libraries/Api.Infrastructure.Server/

RUN dotnet restore "${APP_SRC_PATH}/${APP_NAME}.csproj"

COPY . .

WORKDIR /contextualized-notification-platform/${APP_SRC_PATH}

RUN dotnet publish "${APP_NAME}.csproj" -c Release -o build


# ------------------ dotnet-app-api ------------------- #
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-bookworm-slim AS dotnet-app-api

ARG APP_NAME
ARG APP_SRC_PATH

WORKDIR /contextualized-notification-platform/${APP_SRC_PATH}

COPY --from=dotnet-app /contextualized-notification-platform/${APP_SRC_PATH}/build .

EXPOSE 8080

ENTRYPOINT ["dotnet", "${APP_NAME}.dll"]