FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Quotation.Api/Quotation.Api.csproj Quotation.Api/
COPY Infra/Crosscutting/Quotation.Infra.Ioc/Quotation.Infra.Ioc.csproj Infra/Crosscutting/Quotation.Infra.Ioc/
COPY Infra/Data/Quotation.Infra.Data/Quotation.Infra.Data.csproj Infra/Data/Quotation.Infra.Data/
COPY Domain/Quotation.Domain/Quotation.Domain.csproj Domain/Quotation.Domain/
COPY Quotation.Infra.Mapper/Quotation.Infra.Mapper.csproj Quotation.Infra.Mapper/
COPY Quotataion.Queries/Quotation.Queries.csproj Quotataion.Queries/
COPY Quotation.Specification/Quotation.Helper.csproj Quotation.Specification/
COPY Application/Quotation.Application/Quotation.Application.csproj Application/Quotation.Application/
COPY Infra/Crosscutting/Quotation.Infra.EventBus/Quotation.Infra.EventBus.csproj Infra/Crosscutting/Quotation.Infra.EventBus/
RUN dotnet restore Quotation.Api/Quotation.Api.csproj
COPY . .
WORKDIR /src/Quotation.Api
RUN dotnet build Quotation.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Quotation.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Quotation.Api.dll"]
