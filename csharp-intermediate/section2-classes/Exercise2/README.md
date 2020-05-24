# Running with Docker
You can run this example in a docker container as well.

1. Open the Exercise2 folder in your terminal

2. Create the image from the Dockerfile
```
docker build -t csharp-intermediate-section2-exercise2:latest .
```

3. Run a container using the image created at step 2
```
docker run csharp-intermediate-section2-exercise2:latest
```