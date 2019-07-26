@echo off

echo Build image
docker build -t my-api-container:1.0 .

echo Tag latest image
docker tag my-api-container:1.0 my-api-container:latest

echo Completed