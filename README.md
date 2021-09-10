# DockerDBDotNet
Use the following command to get the npgsql
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.2

kubectl apply -f pg_persistentvolume.yaml
kubectl apply -f pg_persistentvolumeclaim.yaml
kubectl apply -f pg_pv_deployment.yaml
kubectl create -f api_deployment.yaml
kubectl get pods