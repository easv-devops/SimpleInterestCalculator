FROM node:18 AS build
WORKDIR /app
COPY ./app/app.component.ts ./app.component.ts
COPY ./app/app.component.spec.ts ./app.component.spec.ts
COPY ./app/app.config.ts ./app.config.ts
COPY ./app/app.routes.ts ./app.routes.ts
COPY ./app/entry.model.ts ./entry.model.ts
COPY ./app/app.service.ts ./app.service.ts
RUN npm install
RUN npm install -g @angular/cli
RUN ng build

FROM nginx:alpine
# Create a group and user
RUN addgroup -g 1001 -S nginx && \
    adduser -u 1001 -D -S -G nginx nginx && \
    chown -R nginx:nginx /var/cache/nginx && \
    chown -R nginx:nginx /var/log/nginx && \
    chown -R nginx:nginx /etc/nginx/nginx.conf && \
    touch /var/run/nginx.pid && \
    chown -R nginx:nginx /var/run/nginx.pid

USER nginx

COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
