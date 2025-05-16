# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy toàn bộ mã nguồn vào Docker
COPY . .

# Khôi phục các dependency từ .csproj
RUN dotnet restore

# Build project ở chế độ Release và publish ra thư mục /app/out
RUN dotnet publish -c Release -o /app/out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy bản đã build từ stage trước
COPY --from=build /app/out .

# Chạy project
ENTRYPOINT ["dotnet", "DATN_API.dll"]
