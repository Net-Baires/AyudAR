# Idea
Tenes ropa de más? No sabes donde donarla, no tienes tiempo? te ayudamos a resolver el problema. Les presentamos AyudAR, una app que te permite donar lo que ya no utilizas, para las personas que más lo necesitan. Solo agrega lo que tengas para donar y nosotros nos encargamos de hacerlo posible. Al momento de ser recibida tu donación se compartirá en redes sociales, motivando a nuevos donantes.

[Docs](https://docs.google.com/document/d/1hqhDULoA6OCCamnrv_AI4dafbFr8M1FCcqMQcQmUg8w/edit#)

## Nombre
**AyudAR**

## Publico
Usuarios que deseen donar ropa y no saben donde o no tienen tiempo de llevarla al centro de la organizacion.

Conductores con ganas de transladar donaciones a los centros de acopio

## Mockup
https://pr.to/ARJB90/

## Api
Postman [link](https://www.getpostman.com/collections/d47be06824ade77fa722)

## Azure functions Url
https://ayudar-functions-dev.azurewebsites.net/api/drivers

https://ayudar-functions-dev.azurewebsites.net/api/donations

### Aspectos de seguridad
- Palabra clave entre donante y conductor generada por la aplicacion.
- tracking para los distintos checkpoints o puntos de control de los paquetes.


### Gratificaciones
- la plataforma comparte en Facebook cuando un conductor translada los paquetes de los donantes al centro de acopio.
- la plataforma notifica al donante cada checkpoint.
- la plataforma notifica cuando la donacion llego al destino final.


### Donaciones

#### Crear una nueva donacion
Request
```http
POST /api/donations HTTP/1.1
Host: ayudar-functions-dev.azurewebsites.net
Content-Type: application/json
Cache-Control: no-cache

{
	"device":"some mobile device",
	"whoIs":{
		"firstname":"German",
		"lastname":"Kuber",
		"email":"ger@gmail.com"
	},
	"collectAddress":{
		"street1":"Moldes 3089 1F",
		"street2":"",
		"state":"CABA",
		"Zipcode":"1429"
	},
	"packages":[
		{
			"category":"Less than 3 years",
			"genre":"Unisex"
		}
	],
	"availability":{
		"schedule":[
			{
			"day":"Saturday",
			"start":"10:00",
			"end":"15:00"
			},
			{
			"day":"Sunday",
			"start":"10:00",
			"end":"15:00"
				
			}
		]
	}
}
```

Response
```json
{
    "Id": "a02a00af-83bb-4fd9-ac26-2c8498859aba",
    "Device": "some mobile device",
    "WhoIs": {
        "FirstName": "German",
        "LastName": "Kuber",
        "Email": "ger@gmail.com"
    },
    "CollectAddress": {
        "Street1": "Moldes 3089 1F",
        "Street2": "",
        "State": "CABA",
        "Zipcode": "1429"
    },
    "Availability": {
        "Schedule": [
            {
                "Day": "Saturday",
                "Start": "10:00:00",
                "End": "15:00:00"
            },
            {
                "Day": "Sunday",
                "Start": "10:00:00",
                "End": "15:00:00"
            }
        ]
    },
    "Packages": [
        {
            "Category": "Less than 3 years",
            "Code": null,
            "Genre": 2
        }
    ]
}
```

### Crear un nuevo chofer
Request
```http
POST /api/drivers HTTP/1.1
Host: ayudar-functions-dev.azurewebsites.net
Content-Type: application/json
Cache-Control: no-cache

{
	"driver":{
		"firstName":"Gabriel",
		"lastName":"Barzola",
		"email":"barcho@gmail.com",
		"socialNumber":"33227582",
		"collectZone":"Belgrano",
		"availability":{
			"schedule":[
				{
					"day":"Monday",
					"start":"10:00",
					"end":"20:00"
				}
			]
		}
		
		
	}
}
```

Response
```json
{
    "Id": "849900f8-c24b-438d-9eee-f14177231e26",
    "Driver": {
        "Firstname": "Gabriel",
        "Lastname": "Barzola",
        "Email": "barcho@gmail.com",
        "SocialNumber": "33227582",
        "CollectZone": "Belgrano",
        "Availability": {
            "Schedule": [
                {
                    "Day": "Monday",
                    "Start": "10:00:00",
                    "End": "20:00:00"
                }
            ]
        }
    }
}
```
