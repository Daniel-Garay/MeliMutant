# Prueba de ingreso Mercadolibre

Magneto quiere reclutar la mayor cantidad de mutantes para poder luchar
contra los X-Mens.

Te ha contratado a ti para que desarrolles un proyecto que detecte si un
humano es mutante basándose en su secuencia de ADN.

Para eso te ha pedido crear un programa con un método o función con la siguiente firma (En
alguno de los siguiente lenguajes: Java / Golang / C-C++ / Javascript (node) / Python / Ruby):

## boolean isMutant(String[] dna);

En donde recibirás como parámetro un array de Strings que representan cada fila de una tabla
de (NxN) con la secuencia del ADN. Las letras de los Strings solo pueden ser: (A,T,C,G), las
cuales representa cada base nitrogenada del ADN.

![enter image description here](https://drive.google.com/file/d/1nvA9bnl1XUawFDf_WmzdpCzR7RBUKoPH/view?usp=sharing)


Sabrás si un humano es mutante, si encuentras más de una secuencia de cuatro letras
iguales, de forma oblicua, horizontal o vertical.
Ejemplo (Caso mutante):
String[] dna = {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"};
En este caso el llamado a la función isMutant(dna) devuelve “true”.
Desarrolla el algoritmo de la manera más eficiente posible.

## Ejemplo (Caso mutante):

String[] dna = {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"};

En este caso el llamado a la función isMutant(dna) devuelve “true”.
Desarrolla el algoritmo de la manera más eficiente posible

## Desafíos:
### Nivel 1:
Programa (en cualquier lenguaje de programación) que cumpla con el método pedido por
Magneto.
### Nivel 2:
Crear una API REST, hostear esa API en un cloud computing libre (Google App Engine,
Amazon AWS, etc), crear el servicio “/mutant/” en donde se pueda detectar si un humano es
mutante enviando la secuencia de ADN mediante un HTTP POST con un Json el cual tenga el
siguiente formato:
POST → /mutant/
{
“dna”:["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
}
En caso de verificar un mutante, debería devolver un HTTP 200-OK, en caso contrario un
403-Forbidden


# Entregable

###  Consulta de estadisticas:

Verbo Http : GET
url : https://xbezbfk0i4.execute-api.sa-east-1.amazonaws.com/Prod/stats

###  Verificación de mutante:

Verbo Http : Post
url : https://xbezbfk0i4.execute-api.sa-east-1.amazonaws.com/Prod/stats


##### Metodo Post

Content-Type: application/json

Request Mutante 
```json
{
    "dna": [
        "ATGCGA",
        "CAGTGC",
        "TTATGT",
        "AGAAGG",
        "CCCCTA",
        "TCACTG"
    ]
}
```
Response Status: 200 OK

Request Humano
```json
{
    "dna": [
        "TTGCGA",
        "CAGTGC",
        "TTATGT",
        "AGAAGG",
        "CCTCTA",
        "TCACTG"
    ]
}

Response Status: 400 Bad Request

Request Rechazado (Error Json)
```json
{
    "dnaa": [
        "TTHCG",
        "CAG1GC",
        "TTATGT",
        "AGAAGG",
        "CCTCTA",
        "TCACTG"
    ]
}
```
Response Status: 400 Bad Request

#### Tecnología Utilizada
- Netbeans IDE 8.2
- Java 7
- Jdk 1.8
- Maven
- Tomcat 8
- Google Cloud
