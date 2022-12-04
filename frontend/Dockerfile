FROM node:16-alpine3.14 as build
WORKDIR /app
COPY package.json ./
COPY package-lock.json ./
RUN npm install
COPY ./ ./
RUN npm run build:dev-k8s

FROM nginx:1.21.6-alpine as final
COPY --from=build app/build/. /usr/share/nginx/html/