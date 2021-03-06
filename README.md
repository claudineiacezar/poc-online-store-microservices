# Web API

## Create web api application

$ dotnet new webapi -n <app-name>

## Web API dependecies

### AutoMapper

$ dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

### Entity Framework Core

$ dotnet add package Microsoft.EntityFrameworkCore

### Entity Framework Core Desing

$ dotnet add package Microsoft.EntityFrameworkCore.Design

### Entity Framework in Memory

$ dotnet add package Microsoft.EntityFrameworkCore.InMemory

### Entity Framework SQL Server

$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer

## Folders Structure

### Controllers

XXXXXXXXXX

### Models

Internal Models

### DTOs

External Models

### Data

XXXXXXXXXX

### Profiles

XXXXXXXXXX

### SyncDataServices

XXXXXXXXXX

#

# Docker

## Commands

### To build a image

#### $docker build -t claudineiacezar/productservice .

### To push a image to dockerhub

#### $docker push claudineiacezar/productservice

### To run a container

#### $docker run -dp 8080:80 <image name>

#### $docker run -dp 8080:80 claudineiacezar/productservice

#

# KUBERNETES

## Commands

## Step 0: Check if Kubernetes is running (get: Client Version and Server Version)

### $ kubectl version

## Step 01: Create the yaml deploy file

## Step 02: Create the deployment (apply the file)

### $ kubectl apply -f products-depl.yaml

## Step 03: Check the deployment

### $ kubectl get deployments

### $ kubectl get pods

## Step 04: Create a Node Port to give us acess to services running in kubernetes

### Step 04.1: Create a yaml file configuration

### Step 04.2: Apply de yaml file

#### $ kubectl apply -f product-np-srv.yaml

### Step 04.3: Check if the services was created

#### $ kubectl get services

#

# INGRESS ENGINE X

## ingress-nginx is an Ingress controller for Kubernetes using NGINX as a reverse proxy and load balancer.

ref: https://github.com/kubernetes/ingress-nginx/

## See the Getting Started document.

ref: https://kubernetes.github.io/ingress-nginx/deploy/

## Docker Desktop ingress-nginx yaml fiel

ref: https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.0/deploy/static/provider/cloud/deploy.yaml

## Apply ingress-nginx

### $ kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.0/deploy/static/provider/cloud/deploy.yaml

## To get the namespaces

### $ kubectl get namespaces

## To see the pods in the igress-nginx kubernetes namespace

### kubectl get pods --namespace=ingress-nginx

### Open the host files in windows machine

C:\Windows\System32\drivers\etc
