#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/1.0-Presentation/FrameBook.AuthAPI/FrameBook.AuthAPI.csproj", "Services/1.0-Presentation/FrameBook.AuthAPI/"]
COPY ["Services/5.0-Authentication/Framebook.Authentication/Framebook.Authentication.csproj", "Services/5.0-Authentication/Framebook.Authentication/"]
COPY ["Services/2.0-Business/Framebook.Business.DTO/Framebook.Business.DTO.csproj", "Services/2.0-Business/Framebook.Business.DTO/"]
COPY ["Services/3.0-Domain/Framebook.Domain/Framebook.Domain.csproj", "Services/3.0-Domain/Framebook.Domain/"]
COPY ["Services/4.0-Infrastructure/4.2-CrossCutting/Framebook.Infra.CrossCutting.Adapter/Framebook.Infra.CrossCutting.Adapter.csproj", "Services/4.0-Infrastructure/4.2-CrossCutting/Framebook.Infra.CrossCutting.Adapter/"]
COPY ["Services/4.0-Infrastructure/4.1-Data/Framebook.Infra.Data/Framebook.Infra.Data.csproj", "Services/4.0-Infrastructure/4.1-Data/Framebook.Infra.Data/"]
COPY ["Services/4.0-Infrastructure/4.2-CrossCutting/Framebook.Infra.CrossCutting.IOC/Framebook.Infra.CrossCutting.IOC.csproj", "Services/4.0-Infrastructure/4.2-CrossCutting/Framebook.Infra.CrossCutting.IOC/"]
COPY ["Services/4.0-Infrastructure/4.1-Data/Framebook.Infra.Repository/Framebook.Infra.Repository.csproj", "Services/4.0-Infrastructure/4.1-Data/Framebook.Infra.Repository/"]
COPY ["Services/2.0-Business/Framebook.Business/Framebook.Business.csproj", "Services/2.0-Business/Framebook.Business/"]
RUN dotnet restore "Services/1.0-Presentation/FrameBook.AuthAPI/FrameBook.AuthAPI.csproj"
COPY . .
WORKDIR "/src/Services/1.0-Presentation/FrameBook.AuthAPI"
RUN dotnet build "FrameBook.AuthAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrameBook.AuthAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrameBook.AuthAPI.dll"]