
FROM node:latest AS build

RUN npm install -g @angular/cli

WORKDIR /app

COPY ./app/GerenciadorDeDocumentos/package.json ./

RUN npm install

COPY ./app/GerenciadorDeDocumentos .
