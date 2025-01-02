ARG DOTNET_VERSION=9.0
ARG DOCKER_RUNNER_VERSION=27.3.1

ARG APP_NAME=ContextualizedNotification.Platform
ARG APP_SRC_PATH=src


# ------------------- docker-runner ------------------- #
FROM docker:${DOCKER_RUNNER_VERSION}-dind AS docker-runner

ARG DOCKER_HOST

ENTRYPOINT ["sh", "-c", "dockerd --host=unix:///var/run/docker.sock --host=$DOCKER_HOST --tls=false"]


# -------------------- dotnet-base -------------------- #
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-bookworm-slim AS dotnet-base

RUN set -x \
    && apt-get update \
    && apt-get install -y curl git \
    && apt-get clean


# -------------------- dotnet-app --------------------- #
FROM dotnet-base AS dotnet-app

ARG APP_NAME
ARG APP_SRC_PATH

WORKDIR /contextualized-notification-platform

COPY ./${APP_SRC_PATH}/${APP_NAME}.sln ./${APP_SRC_PATH}/

COPY ./src/Infrastructure/Organizations.Api.Stack/Organizations.Api.Stack.csproj ./src/Infrastructure/Organizations.Api.Stack/
COPY ./src/Libraries/Api.Build.Infrastructure/Api.Build.Infrastructure.csproj ./src/Libraries/Api.Build.Infrastructure/
COPY ./src/Libraries/ContainerImage.Build.Infrastructure/ContainerImage.Build.Infrastructure.csproj ./src/Libraries/ContainerImage.Build.Infrastructure/
COPY ./src/Libraries/Organizations.Domain.Fixtures/Organizations.Domain.Fixtures.csproj ./src/Libraries/Organizations.Domain.Fixtures/
COPY ./src/Libraries/Organizations.Domain/Organizations.Domain.csproj ./src/Libraries/Organizations.Domain/
COPY ./src/Services/Organizations.Api.Tests/Organizations.Api.Tests.csproj ./src/Services/Organizations.Api.Tests/
COPY ./src/Services/Organizations.Api/Organizations.Api.csproj ./src/Services/Organizations.Api/

RUN dotnet restore "${APP_SRC_PATH}/${APP_NAME}.sln"

COPY . .


# -------------------- dotnet-cli --------------------- #
FROM dotnet-base AS dotnet-cli

RUN set -x \
    && curl -fsSL https://get.pulumi.com | bash \
    && curl -fsSL https://aka.ms/InstallAzureCLIDeb | bash

WORKDIR /contextualized-notification-platform

COPY --from=dotnet-app /contextualized-notification-platform .

CMD ["sleep", "infinity"]
