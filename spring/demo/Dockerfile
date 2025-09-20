FROM maven:3.9-eclipse-temurin-23 AS builder
WORKDIR /app
COPY . .
RUN mvn clean package -DskipTests
FROM eclipse-temurin:23-jdk
WORKDIR /app
COPY --from=builder /app/target/*.jar app.jar
ENTRYPOINT ["java","-agentlib:jdwp=transport=dt_socket,server=y,suspend=n,address=*:5005","-jar","app.jar"]
EXPOSE 8080 5005