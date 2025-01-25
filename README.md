# RapidPayTest

This project is based in .NET8, with C#.

I used JWT for the authentication and authorization.




## Database Configuration

To create the database and the related table Card, you have to change the ConnectionString named "SqlServer", with your own credentials.

This is an example:

```
"SqlServer": "Server=Localhost;Database=RapidPayDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
```

You can find this key in the appsettings.json file.


## Migrations

After that, you need to run the migrations that are into the Persistence Layer.

For that, you can use command-line and navigate to the RapidPay.Persistence project and execute:

```
dotnet ef database update
```

Thats all, It should be enough to start working with the project.
## Usage Credentials

The only user is:

- username: user
- password: password


## Finally

I used visual studio endpoint explorer to test my endpoints without external tools.

You can check it in the file __RapidPay.Api.http__.
