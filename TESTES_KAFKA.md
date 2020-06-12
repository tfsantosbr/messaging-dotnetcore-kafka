docker run --net=host --rm confluentinc/cp-kafka:latest kafka-topics --create --topic "topico-teste" --partitions 1 --replication-factor 1 --if-not-exists --zookeeper localhost:32181

docker run --net=host --rm confluentinc/cp-kafka:latest kafka-topics --describe --topic "topico-teste" --zookeeper localhost:32181

docker run --net=host --rm confluentinc/cp-kafka:latest kafka-console-producer --broker-list localhost:29092 --topic 'topico-teste' && echo 'Producer 42 message.'