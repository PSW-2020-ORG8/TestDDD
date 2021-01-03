FROM mysql
WORKDIR /docker-entrypoint-initdb.d
COPY Backend/init.sql 0init.sql
EXPOSE 3306
EXPOSE 33060