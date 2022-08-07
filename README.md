# Car Dealership - Docker, Kubernetes and Helm demo

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
- Install Ingress provided by [kubernetes/ingress-nginx](https://github.com/kubernetes/ingress-nginx/) on the chosen platform. My platform of choice was k8s shipped with Docker Desktop, so this command set it up
```
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.3.0/deploy/static/provider/cloud/deploy.yaml
```
Then I've reroute ingress base url so that it doesn't interfere with my local IIS. Mind that it works only as long as the process is running.
```
kubectl port-forward --namespace=ingress-nginx service/ingress-nginx-controller 5080:80
```

- Run this command from the root of the repo to setup k8s objects
```bash
kubectl apply -f ./k8s
```

## Technology stack
- Docker 20.10
- Kubernetes 1.22, provided by Docker Desktop
- Helm 3.8
- ASP.NET 6
- SQL Server 19
- React 17 on hooks

## Helm
### Test template without tenant overrides
```
cd helm
helm install --generate-name --dry-run --debug car-dealership-tenant
```

### Test template with tenant overrides
```
cd helm
helm install --generate-name --dry-run --debug car-dealership-tenant -f ./car-dealership-tenant/values.renault.yaml
```

### Test subchart template
```
cd helm
helm install --generate-name --dry-run --debug ./car-dealership-tenant/charts/car-dealership
```

### Install chart
```
cd helm
helm upgrade car-dealership-renault car-dealership-tenant --namespace car-dealership --create-namespace -f ./car-dealership-tenant/values.yaml  -f ./car-dealership-tenant/values.renault.yaml --atomic --timeout 3m --debug --install 
```

### Clean up k8s cluster from all resources from this repo
```
kubectl delete namespaces car-dealership
```