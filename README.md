# Introduction

Forecourt server api

## Manage users

After login in the admin call the following endpoint to get the token to manage the users

```http
GET /api/settings HTTP/1.1
Host: localhost:7071
Cache-Control: no-cache
```

the response will have this properties. The most important to manage users is the userToken

```json
{
    "token": "?sv=2015-12-11&sr=c&sig=y45wTNZF79%2FuUlwfkwvTL%2B99jyRypE2zp7PCPRarJzw%3D&se=2017-07-26T04%3A40%3A27Z&sp=w",
    "url": "https://forecourtstorage1.blob.core.windows.net/incident-pictures",
    "userToken": "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik9UQkdNVFpGTlVGQ01FSXhOME01TURBME1qazFRamRHT1RBNE1UYzBOa1UxUlRJNU9UZ3hSZyJ9.eyJpc3MiOiJodHRwczovL2ludGVsaWNvLmF1dGgwLmNvbS8iLCJzdWIiOiJNTDJTNkZJVThRTm1FMG1zYW12dDRQR2Z2WEIwY3ZPV0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9pbnRlbGljby5hdXRoMC5jb20vYXBpL3YyLyIsImV4cCI6MTUwMTEyMzIyNywiaWF0IjoxNTAxMDM2ODI3LCJzY29wZSI6InJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMifQ.InHWcQQIPaYI5qFZJmNsPbP9_Khy-DCz7K72XgkCTIgc8VLT6M6ZSrSTYUCog6ajgCyUxROcugpLk8OsnFqdSzti6N8oDkRNIjWzeYaqx88leLBHRhpsSALYyFKa4_GtH4wokju-_8Tfcum4I_M7ao7psiS_8rq6fMU4UwMNZ6DH9VQjk2BePyBsIXar_5Uqa_0FscIYFQ9ey6BFzZBu4I4swuf8fNJKJOZ24VxXyCogsyuNHxRublMUK-iIgBQW32wpfzW9KHZW0zq-VsVTziDgAkRg5_4h43WPkryGjWFPeX2V39F70CwBfZXWJIt8IlMxmv7GCUNfNPF7DZLPaA"
}
```

### Create user

To create a new user please send the following request

Request

```http
POST /api/v2/users HTTP/1.1
Host: intelico.auth0.com
Content-Type: application/json
Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik9UQkdNVFpGTlVGQ01FSXhOME01TURBME1qazFRamRHT1RBNE1UYzBOa1UxUlRJNU9UZ3hSZyJ9.eyJpc3MiOiJodHRwczovL2ludGVsaWNvLmF1dGgwLmNvbS8iLCJzdWIiOiJNTDJTNkZJVThRTm1FMG1zYW12dDRQR2Z2WEIwY3ZPV0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9pbnRlbGljby5hdXRoMC5jb20vYXBpL3YyLyIsImV4cCI6MTUwMTEyMzIyNywiaWF0IjoxNTAxMDM2ODI3LCJzY29wZSI6InJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMifQ.InHWcQQIPaYI5qFZJmNsPbP9_Khy-DCz7K72XgkCTIgc8VLT6M6ZSrSTYUCog6ajgCyUxROcugpLk8OsnFqdSzti6N8oDkRNIjWzeYaqx88leLBHRhpsSALYyFKa4_GtH4wokju-_8Tfcum4I_M7ao7psiS_8rq6fMU4UwMNZ6DH9VQjk2BePyBsIXar_5Uqa_0FscIYFQ9ey6BFzZBu4I4swuf8fNJKJOZ24VxXyCogsyuNHxRublMUK-iIgBQW32wpfzW9KHZW0zq-VsVTziDgAkRg5_4h43WPkryGjWFPeX2V39F70CwBfZXWJIt8IlMxmv7GCUNfNPF7DZLPaA
Cache-Control: no-cache
Postman-Token: 5c81cc33-4360-c496-43fd-a3575e77449b

{
"connection": "Username-Password-Authentication",
"email": "john.doe@gmail.com",
"password": "Test123456",
"user_metadata": {
    "role":"standard",
    "locations":[1,2,3],
    "phone_number": "+199999999999999",
    "company":{
        "id":1,
        "name":"Esso"
    }
},
"verify_email": true
}
```

Response

```json
{
    "email": "john.doe@gmail.com",
    "user_metadata": {
        "role": "standard",
        "locations": [
            4,
            5,
            6
        ],
        "phone_number": "+199999999999999",
        "company": {
            "id": 1,
            "name": "Esso"
        }
    },
    "email_verified": false,
    "user_id": "auth0|59780589497425796a80aefa",
    "picture": "https://s.gravatar.com/avatar/e13743a7f1db7f4246badd6fd6ff54ff?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fjo.png",
    "identities": [
        {
            "connection": "Username-Password-Authentication",
            "user_id": "59780589497425796a80aefa",
            "provider": "auth0",
            "isSocial": false
        }
    ],
    "updated_at": "2017-07-26T03:04:21.877Z",
    "created_at": "2017-07-26T02:59:21.082Z"
}
```

### update user

To update user its required to send the _user_id_ in the request please use the following request. This is a PATCH request so any property that was sent on the create user can used here to. I put an example on how to update the _locations_ under the _user_metadata_

```http
PATCH /api/v2/users/<user_id> HTTP/1.1
Host: intelico.auth0.com
Content-Type: application/json
Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik9UQkdNVFpGTlVGQ01FSXhOME01TURBME1qazFRamRHT1RBNE1UYzBOa1UxUlRJNU9UZ3hSZyJ9.eyJpc3MiOiJodHRwczovL2ludGVsaWNvLmF1dGgwLmNvbS8iLCJzdWIiOiJNTDJTNkZJVThRTm1FMG1zYW12dDRQR2Z2WEIwY3ZPV0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9pbnRlbGljby5hdXRoMC5jb20vYXBpL3YyLyIsImV4cCI6MTUwMTEyMzIyNywiaWF0IjoxNTAxMDM2ODI3LCJzY29wZSI6InJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMifQ.InHWcQQIPaYI5qFZJmNsPbP9_Khy-DCz7K72XgkCTIgc8VLT6M6ZSrSTYUCog6ajgCyUxROcugpLk8OsnFqdSzti6N8oDkRNIjWzeYaqx88leLBHRhpsSALYyFKa4_GtH4wokju-_8Tfcum4I_M7ao7psiS_8rq6fMU4UwMNZ6DH9VQjk2BePyBsIXar_5Uqa_0FscIYFQ9ey6BFzZBu4I4swuf8fNJKJOZ24VxXyCogsyuNHxRublMUK-iIgBQW32wpfzW9KHZW0zq-VsVTziDgAkRg5_4h43WPkryGjWFPeX2V39F70CwBfZXWJIt8IlMxmv7GCUNfNPF7DZLPaA
Cache-Control: no-cache
Postman-Token: 10000b45-38b1-abf6-565c-0af2d43c70c1

{
    "user_metadata": {
        "locations":[4,5,6]
    }
}
```
