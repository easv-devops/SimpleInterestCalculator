FROM node:18 AS build
WORKDIR /app
COPY . /app
RUN npm install
RUN npm install -g @angular/cli
RUN ng build

FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
