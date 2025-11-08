FROM alpine:3.22.2

RUN addgroup -S nginx && adduser -S -G nginx nginx

RUN apk add --no-cache nginx

RUN mkdir -p /var/www/html \
    /var/log/nginx \
    /var/run/nginx

RUN chown -R nginx:nginx /var/www /var/log/nginx /var/run/nginx /var/lib/nginx /etc/nginx

COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 8080

USER nginx

CMD ["nginx", "-g", "daemon off;"]