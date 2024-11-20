### Application based on Open Trivia Database

![](./Docs/TriviaDb.png)

# https://opentdb.com/

# QuizzApp API
- [User Authentication](#user-api)
  - [Register](#register)
     - [Register Request](#register-request)
     - [Register Response](#register-response)
  - [Login](#login)
     - [Login Request](#login-request)
     - [Login Response](#login-response)
- [QuizzApp API](#breakfast-api)


## User Authentication

### Register

#### Register Request
```js
POST /auth/register
Content-Type: application/json
```
```json
{
    "firstName": "John",
    "lastName": "Smith",
    "email": "test@test.com",
    "password": "passwd"
}
```
#### Register Response
```js
201 Created
```
```json
{
  "firstName": "John",
  "lastName": "Smith",
  "email": "test@test.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmZDBlZTgwZS0yMDMxLTQ1MDUtYTZmZi03MWEwMjA3ZjkwNDAiLCJqdGkiOiIwNzE5NDI4MC01MjdjLTRjNTItOTBhYy0zNjNiOWFjZDE5YWMiLCJnaXZlbl9uYW1lIjoiV2lrdG9yIiwiZmFtaWx5X25hbWUiOiJLcnp5Y3prb3dza2kiLCJhdWQiOiJCdWJiZXJCcmVha2Zhc3QiLCJleHAiOjE3MzE4NzM2NzAsImlzcyI6IkJ1YmJlckJyZWFrZmFzdCJ9.-ccl2nU1TO_-NUGd1IQhmqLmKedRh8ybv9ZH5GF8oG0"
}
```

---

### Login

#### Login Request
```js
POST /auth/login
Content-Type: application/json
```
```json
{
    "email": "wiktor@abc.pl",
    "password": "haslo123"
}
```
#### Login Response
```js
200 OK
```
```json
{
  "id": "e14585c9-85ff-4f30-85c0-8d19ced5c18e",
  "firstName": "Wiktor",
  "lastName": "Krzyczkowski",
  "email": "test@test.pl",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlMTQ1ODVjOS04NWZmLTRmMzAtODVjMC04ZDE5Y2VkNWMxOGUiLCJqdGkiOiJmZGRlMTBjNS00Y2NiLTQ1YzAtOWQ0Mi04NWRhYjg1M2FjZTYiLCJnaXZlbl9uYW1lIjoiV2lrdG9yIiwiZmFtaWx5X25hbWUiOiJLcnp5Y3prb3dza2kiLCJhdWQiOiJCdWJiZXJCcmVha2Zhc3QiLCJleHAiOjE3MzE4NzM4NDgsImlzcyI6IkJ1YmJlckJyZWFrZmFzdCJ9.H_Emb5mAMgG_eOy9-67N4ffX_GF5NklUEOesaEGP0v8"
}
```
---

## Authorization

For endpoints requiring authorization, include the following HTTP header in your requests:
Authorization: Bearer <your-token>

Replace <your-token> with the token received from the Login response.

---

## QuizzApp Api
### Work in Progress: under development