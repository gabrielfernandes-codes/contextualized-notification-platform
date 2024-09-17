ARG DOTNET_VERSION=8.0


# -------------------- dotnet-base -------------------- #
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS dotnet-base

WORKDIR /contextualized-notification-platform


# -------------------- dotnet-deps -------------------- #
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS dotnet-deps


# -------------------- dotnet-dev --------------------- #
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS dotnet-dev

WORKDIR /contextualized-notification-platform

COPY . .
