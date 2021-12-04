#

# Web API

## Step 0: Check if dot net is installed

### dotnet --version

## Step 01: Create web api application

$ dotnet new webapi -n <app-name>

## Step 02: Add the dependencies

### AutoMapper

$ dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 8.1.1

### Entity Framework Core

$ dotnet add package Microsoft.EntityFrameworkCore --version 5.0.8

### Entity Framework Core Desing

$ dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.8

### Entity Framework in Memory

$ dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 5.0.8

### Entity Framework SQL Server

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.8

# Folders Structure

## Models

Internal Models

## DTOs

External Models

#

# Docker

## Step 0: Check if docker is running

### $docker --version

## Step 1: Create a Dockerfile

ref: https://docs.docker.com/samples/dotnetcore/

## Step 02 : To build the image

### $docker build -t claudineiacezar/productservice .

## Step 03: To push a image to dockerhub

### $docker push claudineiacezar/productservice

## Step 04: To run a container

### $docker run -dp 8080:80 <image name>

### $docker run -dp 8080:80 claudineiacezar/productservice
