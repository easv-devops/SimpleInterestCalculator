FROM node:18 AS build
WORKDIR /app
COPY ./app app.component.css
COPY ./app app.component.html
COPY ./app app.component.ts
COPY ./app app.component.spec.ts
COPY ./app app.config.ts
COPY ./app app.routes.ts
COPY ./app entry.model.ts
COPY ./app app.service.ts
RUN npm install
RUN npm install -g @angular/cli
RUN ng build

FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
