FROM mcr.microsoft.com/dotnet/sdk:10.0.301@sha256:ea8bde36c11b6e7eec2656d0e59101d4462f6bd630730f2c8201ed0572b295d5 AS builder
WORKDIR /build
COPY ./ .
RUN dotnet publish ./src -o "./bildur"
RUN dotnet publish ./Migrator -o "./migrator"

FROM mcr.microsoft.com/dotnet/aspnet:10.0.9-noble-chiseled-extra@sha256:f35864ca57c18f2dcd7164dd20256a1b5236c34f7883a7f32abc42ba70a56f0f AS bildur
WORKDIR /app
COPY --from=builder /build/bildur .
ENTRYPOINT ["dotnet", "Bildur.dll"]

FROM mcr.microsoft.com/dotnet/runtime:10.0.9 AS migrator
WORKDIR /app
COPY --from=builder /build/migrator .
ENTRYPOINT ["dotnet", "Migrator.dll"]