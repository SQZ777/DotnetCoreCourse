# install dotnet-ef
dotnet tool install --global dotnet-ef --version 3.0.0
# install mysql db
docker run --name dev-mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=password -d mysql
# install postgres db
docker run --name dev-postgres -p 5432:5432 -e POSTGRES_PASSWORD=password -d postgres
