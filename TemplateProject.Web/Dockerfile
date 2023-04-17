FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TemplateProject.Web/TemplateProject.Web.csproj", "TemplateProject.Web/"]
RUN dotnet restore "TemplateProject.Web/TemplateProject.Web.csproj"
COPY . .
WORKDIR "/src/TemplateProject.Web"
RUN dotnet build "TemplateProject.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemplateProject.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemplateProject.Web.dll"]
