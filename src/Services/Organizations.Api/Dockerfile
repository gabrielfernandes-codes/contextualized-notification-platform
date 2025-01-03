ARG DOTNET_VERSION=9.0

ARG APP_NAME=Organizations.Api
ARG APP_SRC_PATH=src/Services/${APP_NAME}


# -------------------- dotnet-base -------------------- #
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-bookworm-slim AS dotnet-base

RUN set -x \
    && apt-get update \
    && apt-get clean


# -------------------- dotnet-app --------------------- #
FROM dotnet-base AS dotnet-app

ARG APP_NAME
ARG APP_SRC_PATH

WORKDIR /contextualized-notification-platform

COPY ./${APP_SRC_PATH}/${APP_NAME}.csproj ./${APP_SRC_PATH}/

COPY ./src/Libraries/Organizations.Domain/Organizations.Domain.csproj ./src/Libraries/Organizations.Domain/
COPY ./src/Libraries/Organizations.Domain.Fixtures/Organizations.Domain.Fixtures.csproj ./src/Libraries/Organizations.Domain.Fixtures/
COPY ./src/Libraries/Api.Build.Infrastructure/Api.Build.Infrastructure.csproj ./src/Libraries/Api.Build.Infrastructure/

RUN dotnet restore "${APP_SRC_PATH}/${APP_NAME}.csproj"

COPY . .

WORKDIR /contextualized-notification-platform/${APP_SRC_PATH}

RUN dotnet publish "${APP_NAME}.csproj" -c Release -o build


# -------------------- dotnet-api --------------------- #
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-bookworm-slim AS dotnet-api

ARG APP_NAME
ARG APP_SRC_PATH

WORKDIR /contextualized-notification-platform/${APP_SRC_PATH}

COPY --from=dotnet-app /contextualized-notification-platform/${APP_SRC_PATH}/build .

EXPOSE 8080

ENV APP_NAME=${APP_NAME}

ENTRYPOINT ["sh", "-c", "dotnet ${APP_NAME}.dll"]