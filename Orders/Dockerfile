#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 58945
EXPOSE 44399

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["Orders/Orders.csproj", "Orders/"]
RUN dotnet restore "Orders/Orders.csproj"
COPY . .
WORKDIR "/src/Orders"
RUN dotnet build "Orders.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Orders.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Orders.dll"]