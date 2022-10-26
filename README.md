# RepCrime
To run this application you need to have Docer Desktop installed on your system.
All vulnerable data are stored inside user secrets - therefore you need to add your own before starting.
    Secrets needed:
    - CrimeApi
        {
            "MongoDb": {
              "ConnectionString": "connection string",
              "DatabaseName": "name",
              "CollectionName": "name"
            },
            "RabbitMqUsername": "user",
            "RabbitMqPassword": "password"
        }

    - EnforcerApi
        }
            "ConnectionStrings": {
                "DefaultConnection": "connection string"
            }
        }

    - MailApi
        {
            "RabbitMqUsername": "user",
            "RabbitMqPassword": "password",
            "MailSettings": {
              "Login": "email",
              "Password": "password"
        }

    - StatsApi
        {
            "MongoDb": {
              "ConnectionString": "connection string",
              "DatabaseName": "name",
              "CollectionName": "name"
            }
        }


When that is done, open your CMD and go to folder where the solution file is located.
After that run comman - docker compose up --build -d to start the application.
Ports to every microserwis you can find in Docker Desktop.