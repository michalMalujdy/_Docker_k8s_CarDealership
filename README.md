# Car Dealership - Docker and Kubernetes demo

## Overview

## Acheived goals
- Hands on experience with Docker
- Hands on experience with docker-compose
- Hands on experience with Kubernetes
- A full stack system composed of the frontend, API and persistence
- The system was contenerized
- The docker-compose.yaml file created to setup local development environment easily
- The system was hosted on Kubernetes with use of deployments and service IP
- Ingress installed and configured

## Demo

### Setup local development environment
To setup the environment locally, run following command from the repo root
```bash
docker-compose -f docker-compose.development.yml up
```

### Setup Kubernetes hosting
- Install Ingress provided by [kubernetes/ingress-nginx](https://github.com/kubernetes/ingress-nginx/) on the chosen platform.
- Run this command from the root of the repo to setup k8s objects
```bash
kubectl apply -f ./k8s
```

## Technology stack
- Docker 20
- Kubernetes 1.22, provided by Docker Desktop
- ASP.NET 6
- SQL Server 19
- React 17 on hooks