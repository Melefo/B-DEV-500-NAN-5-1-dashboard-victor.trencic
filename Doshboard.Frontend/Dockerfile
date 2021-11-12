FROM node:lts-alpine
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY ["Doshboard.Frontend/", "/app"]
RUN npm install
RUN npm install @vue/cli

CMD ["npm", "run", "serve"]