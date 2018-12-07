#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 56144
EXPOSE 44374

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["Orders_Microservice/Orders_Microservice.csproj", "Orders_Microservice/"]
RUN dotnet restore "Orders_Microservice/Orders_Microservice.csproj"
COPY . .
WORKDIR "/src/Orders_Microservice"
RUN dotnet build "Orders_Microservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Orders_Microservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Orders_Microservice.dll"]