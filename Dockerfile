FROM maven:3.8.7-eclipse-temurin-17-focal
VOLUME /tmp
WORKDIR /app

RUN apt-get update && apt-get install -y curl unzip
RUN curl -L https://services.gradle.org/distributions/gradle-8.5-bin.zip -o gradle-8.5-bin.zip
RUN unzip gradle-8.5-bin.zip
ENV GRADLE_HOME=/app/gradle-8.5
ENV PATH=$PATH:$GRADLE_HOME/bin
COPY . .
RUN gradle build -x test

EXPOSE 8082

ENTRYPOINT ["sh", "-c", "java -jar /app/build/libs/*-SNAPSHOT.jar"]