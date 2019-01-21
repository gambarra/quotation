FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Quotation.Api/Quotation.Api.csproj", "Quotation.Api/"]
RUN dotnet restore "Quotation.Api/Quotation.Api.csproj"
COPY . .
WORKDIR "/src/Quotation.Api"
RUN dotnet build "Quotation.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Quotation.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Quotation.Api.dll"]