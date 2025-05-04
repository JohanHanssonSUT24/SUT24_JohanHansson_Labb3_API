# Johan Hansson - SUT24 - Labb3, API
This is my Lab 3 - API for the course and implements basic REST methods for managing people, interests, and links. The API uses ASP.NET Core and Entity Framework to communicate with a SQL database.
The API provides endpoints for creating, retrieving, and managing relationships between people and their interests, as well as managing links associated with these interests.

## Endpoints

### PersonController

1. **GET /api/person**  
   Hämtar alla personer från databasen.

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
   - "id" (int): Personens unika ID.
   
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
 

3. **POST /api/person/{id}/interest/{interestId}**  
   Lägg till ett intresse för en specifik person.

   **Parametrar:**
   - "id" (int): Personens unika ID.
   - `interestId` (int): Intressets unika ID.

   **Request URL:**
   https://localhost:7146/api/Person/1/interest/4

   **Request:**
   "id": int,
    "interestId": int

   **Request:**
   If not OK: Error 400 - Intresset finns redan tillagt


### InterestController

1. **GET /api/interest**  
   Hämtar alla intressen från databasen.

   **Request URL:**
   https://localhost:7146/api/Interest

   **Request:**
   {
   "id": int,
    "title": "string",
    "description": "string",
   }
   **Exempel Response:**
   {
    "id": 1,
    "title": "Programming",
    "description": "Coding and software development"
  },
  {
    "id": 2,
    "title": "Cooking",
    "description": "Making good food"
  },

3. **GET /api/interest/{id}**  
   Hämtar ett specifikt intresse baserat på dess ID.

   **Request URL:**
   https://localhost:7146/api/Interest/1
   **Request:**
   {
   "id": id
   }
   **Exempel Response:**
   {
   "id": 1,
   "title": "Programming",
   "description": "Coding and software development"
   }

4. **POST /api/interest**  
   Skapar ett nytt intresse.

   **Request URL:**
   https://localhost:7146/api/Interest
   **Request:**
   {
   "title": "string",
   "description": "string"
   }
   **Exempel Response:**
   {
   "id": 12,
   "title": "Art",
   "description": "Painting stuff"
   }

### LinksController
1. **GET /api/Links/person/{personId}**
   Hämtar specifika länkar kopplade till personId.

   **Request URL:**
   https://localhost:7146/api/Links/person/2
   **Request:**
   {
   "id": id
   }
   **Exempel Response:**
   {
    "id": 3,
    "url": "https://open.spotify.com/"
   },
   {
    "id": 8,
    "url": "JohanHanssonWasHere"
   }

2. **POST /api/Links**
   Lägger till länk kopplat till personId och interestId

   **Request URL:**
   https://localhost:7146/api/Links
   **Request:**
   {
   "url": "string",
   "personId": 2,
   "interestId": 2
   }
   **Exempel Response:**
   {
   "id": 16,
   "url": "www.seb.com"
   }
   
   
