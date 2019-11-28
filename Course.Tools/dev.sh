# docker-compose故障中，先土炮一點
docker stop dev-mysql || true && docker start dev-mysql
docker stop dev-postgres || true && docker start dev-postgres