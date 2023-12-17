<center>

# Configuración de Inicio Rápido

### **Configuración:**
1. **Clona este repositorio en tu máquina local:**
    ```bash
    git clone https://github.com/VictorVenegas07/Prueba_inteia.git

3. **Descarga la imagen de MongoDB desde Docker Hub:**
    ```bash
    docker pull mongo

3. **Crea una red personalizada para permitir que tu aplicación se conecte a MongoDB:**
   ```bash
   docker network create --driver bridge mi-red
   
5. **Inicia un contenedor de MongoDB en la red creada:**
   ```bash
   docker run -d --network=mi-red --name mongo mongo

6. **Construye la imagen de la aplicación y ejecútala en la misma red:**
   ```bash
   docker build -t nombre-de-tu-aplicacion .
   docker run -p 80:80 --network mi-red -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS=http://+:80 api:tag

</center>
