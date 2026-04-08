FROM maven:3.8.7-eclipse-temurin-17-focal
VOLUME /tmp
WORKDIR /app

# Install only necessary tools
RUN apt-get update && apt-get install -y curl unzip

# Copy all files
COPY . .

# Grant execute permission to gradle wrapper
RUN chmod +x ./gradlew

# Build without spotless and tests to ensure a fast & successful deployment
# Increase memory limits to avoid Error 255 (OOM) during Gradle build
RUN ./gradlew build -x test -x spotlessCheck -x spotlessApply --no-daemon --info -Dorg.gradle.jvmargs="-Xmx1024m -XX:MaxMetaspaceSize=256m"

EXPOSE 8082

ENTRYPOINT ["sh", "-c", "java -jar build/libs/ABDM-wrapper-1.0-SNAPSHOT.jar"]