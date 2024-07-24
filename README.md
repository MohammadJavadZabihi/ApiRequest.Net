
# ApiRequest.Net

APIRequest - A Powerful Package for API Requests
APIRequest is a NuGet package designed to simplify sending and receiving HTTP/HTTPS requests to web APIs. This package helps developers easily access external resources, send data, and handle responses with minimal code.

Features:
Support for Multiple HTTP Methods: Including GET, POST, PUT, DELETE, and more.
Simple Management of Headers and Parameters: Allows adding custom headers and parameters to requests.
Easy Serialization and Deserialization: Full support for JSON using Newtonsoft.Json for data management.
Support for Authentication: Ability to use JWT tokens and other authentication methods.
Error Handling: Advanced features for handling errors and response statuses.


### Getting Started:
To install the APIRequest.net package, simply run the following command in the NuGet Package Manager console:


"dotnet add package ApiRequest.Net --version 1.0.8"

## Example Code:

### First, you need to add the necessary dependencies in the program.cs:

builder.Services.AddTransient<ICallApiServies, CallApi>();
builder.Services.AddTransient<IApiCallServies, ApiCallServies>();

### After that, You must add this dependency in the constructor of the class you want to use this package. For example, I took the user altogether:
<hr></hr>

![Screenshot (1208)3434343](https://github.com/user-attachments/assets/a9c2ff5e-2e54-4914-8443-b3bd8ff901a7)

### And then you create the data as follows and pass the method parameters to it:

var data = new
{
    Username = user.UserName,
    Email = user.Email,
    Password = user.Password,
    RePassword = user.RePassword
};


var response = await _callApiServies.SendPostRequest<List<UserRegisterViewModel>>("your_api_URL", data = defult null, "your_JWT_TOken" = defult null);

### response.IsSuccess : Api Send Status | return (bool)
### response.Data : Data received from the server to which we called api | return (T) or (object)
### response.Message : The message that the server sent to us or the error that occurred while doing the work | return (string)
