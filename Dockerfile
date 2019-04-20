FROM microsoft/dotnet:2.2-sdk
WORKDIR /app
COPY ["src/BCUniversity.Domain/BCUniversity.Domain.csproj", "src/BCUniversity.Domain/"]
COPY ["src/BCUniversity.Service/BCUniversity.Service.csproj", "src/BCUniversity.Service/"]
COPY ["src/BCUniversity.Infrastructure/BCUniversity.Infrastructure.csproj", "src/BCUniversity.Infrastructure/"]
COPY ["src/BCUniversity.Api/BCUniversity.Api.csproj", "src/BCUniversity.Api/"]
COPY ["BCUniversity.sln", "./"]

RUN dotnet restore "BCUniversity.sln"

COPY . .
WORKDIR /app
RUN dotnet build "src/BCUniversity.Api/BCUniversity.Api.csproj" -c Release -o /build
