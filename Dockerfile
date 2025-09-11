FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

COPY . .

RUN dotnet restore "NiftyCoders.Services.TraineeManagement/NiftyCoders.Services.TraineeManagement.csproj"
RUN dotnet publish "NiftyCoders.Services.TraineeManagement/NiftyCoders.Services.TraineeManagement.csproj" -c Release -o out --no-restore

WORKDIR /app/out

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

CMD ["dotnet", "NiftyCoders.Services.TraineeManagement.dll"]
