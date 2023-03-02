
# senior-tech-interview

# Sebastian Garcia
Github: [sebasgarcia29](https://github.com/sebasgarcia29)

#### Example:  

Clone down this repository. You will need `dotnet` and `visual studio` installed globally on your machine.  

When you start the project, you go to 

https://localhost:7007/swagger/index.html for check the services enable.

The services enable are;

## 1: Get all patients (It's mandatory send a bearer token)
 https://localhost:7007/patients

## 2: Get specify patient (It's mandatory send a bearer token and the id in the URL) 
example:
https://localhost:7007/patient/62421a54-0e45-4030-932c-0eeed3e08a2e

## 3: Get bearer token

This service needs a follow the same structure in body params:

example:
https://localhost:7007/login

{
  "email": "sebas@test.com",
  "password": "Test1234"
}

















