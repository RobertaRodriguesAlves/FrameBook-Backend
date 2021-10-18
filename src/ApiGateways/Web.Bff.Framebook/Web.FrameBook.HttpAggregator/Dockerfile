#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApiGateways/Web.Bff.Framebook/Web.FrameBook.HttpAggregator/Web.FrameBook.HttpAggregator.csproj", "ApiGateways/Web.Bff.Framebook/Web.FrameBook.HttpAggregator/"]
RUN dotnet restore "ApiGateways/Web.Bff.Framebook/Web.FrameBook.HttpAggregator/Web.FrameBook.HttpAggregator.csproj"
COPY . .
WORKDIR "/src/ApiGateways/Web.Bff.Framebook/Web.FrameBook.HttpAggregator"
RUN dotnet build "Web.FrameBook.HttpAggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.FrameBook.HttpAggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.FrameBook.HttpAggregator.dll"]