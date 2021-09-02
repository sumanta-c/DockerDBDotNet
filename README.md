# DockerDBDotNet
Use the following command to get the npgsql
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.2

kubectl create namespace $var1
kubectl apply -f ./kube_pg_configmap.yaml
kubectl create -f ./kube_pg_storage.yaml
kubectl create -f ./kube_pg_deployment.yaml
kubectl create -f ./kube_pg_service.yaml
kubectl port-forward svc/postgres 5432:5432 --namespace postgres