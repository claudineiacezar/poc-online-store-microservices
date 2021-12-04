# Web Api

## Create web api application

dotnet new webapi -n <app-name>
version: 5.0.402

## AutoMapper

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 8.1.1

## Entity Framework Core

dotnet add package Microsoft.EntityFrameworkCore --version 5.0.8

## Entity Framework Core Desing

dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.8

## Entity Framework in Memory

dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 5.0.8

## Entity Framework SQL Server

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.8

# Folders Structure

## Models

Internal Models

## DTOs

External Models

# Docker

## Commands

### To build a image

#### $docker build -t claudineiacezar/inventoryservice .

### To push a image to dockerhub

#### $docker push claudineiacezar/inventoryservice

### To run a container

#### $docker run -p 8080:80 claudineiacezar/inventoryservice