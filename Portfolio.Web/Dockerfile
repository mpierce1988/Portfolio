# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install Node.js and create symlinks for the host-like path used by your MSBuild target
RUN apt-get update && apt-get install -y --no-install-recommends curl ca-certificates gnupg \
  && curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
  && apt-get install -y --no-install-recommends nodejs \
  && mkdir -p /opt/homebrew/bin \
  && ln -s "$(command -v npm)" /opt/homebrew/bin/npm \
  && ln -s "$(command -v npx)" /opt/homebrew/bin/npx || true \
  && rm -rf /var/lib/apt/lists/*

# Copy project file and restore (uses layer caching)
COPY ["Portfolio.Web/Portfolio.Web.csproj", "Portfolio.Web/"]
RUN dotnet restore "Portfolio.Web/Portfolio.Web.csproj"

# Copy the rest of the solution
COPY . .

WORKDIR "/src/Portfolio.Web"

# Install npm deps so Tailwind prebuild runs during publish
RUN if [ -f package-lock.json ] || [ -f package.json ]; then npm ci || npm install; fi

# Publish static Blazor WASM output into /app/publish (wwwroot contains static files)
RUN dotnet publish "Portfolio.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime: serve static files with nginx
FROM nginx:alpine AS runtime
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /app/publish/wwwroot/ /usr/share/nginx/html/

# SPA fallback + correct wasm MIME + cache control
RUN rm /etc/nginx/conf.d/default.conf && \
    printf '%s\n' \
    'server {' \
    '    listen       80;' \
    '    server_name  localhost;' \
    '    root /usr/share/nginx/html;' \
    '    index index.html;' \
    '    location / {' \
    '        try_files $uri $uri/ /index.html;' \
    '    }' \
    '    location ~* \\.wasm$ {' \
    '        add_header Cache-Control "no-store";' \
    '        default_type application/wasm;' \
    '    }' \
    '    location ~* \\.(?:manifest|appcache|html|xml|json)$ {' \
    '        add_header Cache-Control "no-store";' \
    '    }' \
    '    gzip on;' \
    '    gzip_types text/plain text/css application/javascript application/json image/svg+xml application/font-woff2 application/font-woff application/octet-stream;' \
    '}' \
    > /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
