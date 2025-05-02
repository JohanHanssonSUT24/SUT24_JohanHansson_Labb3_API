# Johan Hansson - SUT24 - Labb3, API
This is my Lab 3 - API for the course and implements basic REST methods for managing people, interests, and links. The API uses ASP.NET Core and Entity Framework to communicate with a SQL database.
The API provides endpoints for creating, retrieving, and managing relationships between people and their interests, as well as managing links associated with these interests.

## Endpoints

### PersonController

1. **GET /api/person**  
   Hämtar alla personer från databasen.

   **Svar:**
   200 OK: Listar alla personer.

   **Request URL:**
   https://localhost:7146/api/Person

   **Request:**
   "id": int,
    "firstName": "string",
    "lastName": "string",
    "phone": "string",

   **Exempel Response:**
  {
    "id": 1,
    "firstName": "Johan",
    "lastName": "Hansson",
    "phone": "0700532273"
  },
  {
    "id": 2,
    "firstName": "Jenny",
    "lastName": "Hansson",
    "phone": "0700515273"
  },


2. **GET /api/person/{id}/interests**  
   Hämtar alla intressen kopplade till en specifik person.

   **Parametrar:**
   - `id` (int): Personens unika ID.

   **Svar:**
   - 200 OK: En lista på intressen kopplade till personen.
   
   **Exempel:**
   - 404 Not Found: Om personen inte finns.
   
   **Request URL:**
   https://localhost:7146/api/Person/1/interests
   
   **Request:**
   "id": int,
    "title": "string",
    "description": "string",
    "personInterests": [
      "string"
   
   **Exempel Response:**
   {
    "id": 6,
    "title": "Mechanics",
    "description": "Fixing engines and repairing cars"
  },
  {
    "id": 1,
    "title": "Programming",
    "description": "Coding and software development"
  },
 

4. **POST /api/person/{id}/interest/{interestId}**  
   Lägg till ett intresse för en specifik person.

   **Parametrar:**
   - `id` (int): Personens unika ID.
   - `interestId` (int): Intressets unika ID.

   **Svar:**
   - 200 OK: Intresset är tillagt för personen.
   - 400 Bad Request: Om intresset redan finns kopplat till personen.

   **Request URL:**
   
   **Request:**
   
   **Exempel Response:**


### InterestController

1. **GET /api/interest**  
   Hämtar alla intressen från databasen.

   **Svar:**
   - 200 OK: En lista på alla intressen.

2. **GET /api/interest/{id}**  
   Hämtar ett specifikt intresse baserat på dess ID.

   **Parametrar:**
   - `id` (int): Intressets unika ID.

   **Svar:**
   - 200 OK: Det specifika intresset.
   - 404 Not Found: Om intresset inte finns.
  
   **Request URL:**
   
   **Request:**
   
   **Exempel Response:**

3. **POST /api/interest**  
   Skapar ett nytt intresse.

   **Body (JSON):**
   ```json
   {
     "title": "New Interest",
     "description": "Description of the interest"
   }
   
   **Request URL:**
   
   **Request:**
   
   **Exempel Response:**
