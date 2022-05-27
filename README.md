# _Animal Shelter_

#### By _Daniel Lindsey_

#### API application for an animal shelter

## Technologies Used

- _C#_
- _.NET Framework_
- _HTML_
- _CSS_
- _Javascript_
- _jQuery_
- _MySQL_
- _Entity_
- _Linq_
- _Swagger_

## Description

This is a C# API application for an animal shelter build during a solo Friday project during my time at Epicodus. This repository serves as the API portion of the application, serving data only via API requests. A separate application has been built for the front end, and can be found [here](https://github.com/dlinds/AnimalShelterClient.Solution).

<br>

You can view the Swagger documentation and endpoints for this API here: [http://animalshelterapi.dlinds.com:6003/swagger/index.html](http://animalshelterapi.dlinds.com:6003/swagger/index.html). If you would like to view the front end application that calls the API animals endpoint, please navigate to [http://animalshelter.dlinds.com:6003](http://animalshelter.dlinds.com:6003).

# Setup/Installation Requirements

## Cloning the repository

To view this application, you must clone it to your computer. To do so,

1. Locate and click the green Code button at the top of this [Repository Page](https://github.com/dlinds/AnimalShelter.Solution), and choose the option to _Download ZIP_.
2. Once downloaded, navigate to your Downloads folder and extract the contents to a location of your choosing.

## Installing C# and .NET

Once the project is downloaded to your computer, you will need to download and install C# and the .NET SDK.

1. First, download and install the .NET 5 SDK

- [Mac](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.401-macos-x64-installer)
- [Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.401-windows-x64-installer)

2. Once installed, open a new terminal either via Command Prompt (Windows) or Terminal (OSX).
3. Type the following command:
   - **_dotnet tool install -g dotnet-script_**
4. Next, configure your terminal environment with the following command

   - Mac: **_echo 'export PATH=$PATH:~/.dotnet/tools' >> ~/.zshrc_**
   - Windows: **_echo 'export PATH=$PATH:~/.dotnet/tools' >> ~/.bash_profile_**
     <br>
     <br>

## Setting up the database

Prior to running the application, you will need to install MySQL and MySQL Workbench.

- During install, take note of the password you set for MySQL.
  <br>

[Mac and Windows Download Link](https://dev.mysql.com/downloads/workbench/)

## Set up appsettings.json

Next, you will need to tell the application how to create, write to, and access a database.

1. In the AnimalShelter.Solution directory, locate a file called appsettings.json
2. Add the following into the file, editing both the database name with a name of your choosing, and the password you set when installing MySql.
~~~
    {
      "Logging": {
        "LogLevel": {
          "Default": "Warning",
          "System": "Information",
          "Microsoft": "Information"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=(my_database_name);uid=root;pwd=(my password);"
      }
    }
~~~
<br>

# Run the project
  Now that everything is installed and set up, you may run the project.

1. Open up a new terminal and navigate to the AnimalShelter.Solution Folder
2. Type in the following command: **_dotnet ef database update_**
  * this will create a database with the structure needed for the application to run
3. Type in the following command: **_dotnet run_**
4. Open a web browser and navigate to http://localhost:5000

<br>

# API Documentation
  This application is a API that does not have any authentication integrated. Should you just wish to view information in the database, refer to the documentation below on any GET endpoints (just retrieving information).

  If you would like to add, edit, or delete information in the database, you will need to install Postman or another API interface application of your choosing. Alternatively, download and run the repo listed [here](https://github.com/dlinds/AnimalShelterClient.Solution), which will offer you full CRUD capabilities.

## Swagger
<hr>

This application is equipped with [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0), which per Microsoft is

 "_a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code._"

Swagger is utilized in this application via documentation of each endpoint, parameters for end points when applicable, and viewing example requests of each route. To view the documentation created with Swagger, please navigate to http://localhost:5000/swagger/index.html once you've completed the section **_Run the project_**. Once you are viewing the Swagger page, click on any of the Animals routes to view information on the route and even test out the route as well if you'd like.

## GET
<hr>
GET requests are API calls to the database that return information based on parameters you pass in. For example, your GET request could be finding all Female Cats under the age of 3. Once a GET request is made, the application will return all animals that match your criteria.

  <br>

### GET -  /api/Animals
**Purpose**: Gets all animals currently listed with the shelter

**Example Request**:
~~~
GET /Animals
{

}
~~~

**Example Response**:
~~~
  {
    "animalId": 1,
    "name": "Babby",
    "species": "Dog",
    "breed": "Beagle",
    "gender": "Female",
    "age": 6,
    "adoptionPrice": 500,
    "goodWithOtherAnimals": true,
    "goodWithChildren": true,
    "dateListed": "2022-01-15T00:00:00",
    "animalPhotoURL": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsuPg3g3nAvGkX3pJKCxVT92YlipcQW87tMQ&usqp=CAU"
  }
~~~

**Parameters:**
* gender (string) - filter animals by either Male or Female
* species (string) - filter animals by species, such as dog or cat
* breed (string) - filter different breeds available in the shelter
* age (int) - used with ageSearchType. Enter an age, then choose paramrter for ageSearchType
* ageSearchType (string) - used with age. Enter in either _older_ or _younger_
* adoptionBudget (int) - results will only be returned if adoption price is lower than price specified here
* goodWithOtherAnimals (bool) - true or false
* goodWithChildren (bool) - true or false
* sort (string) - sort your animal results by the date the animal was entered into the system in ascending or descending order. Use _new_ or _old_

**Example URLs (if applicable):**

* http://localhost:5000/api/animals - all animals
* http://localhost:5000/api/animals?species=dog&gender=female - all female dogs
* http://localhost:5000/api/animals?age=7&ageSearchType="younger" - all animals younger than 7 years old
* http://localhost:5000/api/animals?species=dog&adoptionBudget=500 - all dogs with an adoption price under $500
* http://localhost:5000/api/animals?species=dog&breed=beagle - all Beagles

Utilize the above to mix and match for different search queries.


### GET -  /api/Animals/id

Get any animal based on a specific Id. For example, in the previous GET request, only one animal was returned and it had an Id of 1. Searching for just that Id will return the same results as the above request, but unlike the above (at least, in the future when more data is present), it will only return the one specific animal.

**Example Request**:
~~~
GET /Animals/1
{

}
~~~

**Example Response**:
~~~
  {
    "animalId": 1,
    "name": "Babby",
    "species": "Dog",
    "breed": "Beagle",
    "gender": "Female",
    "age": 6,
    "adoptionPrice": 500,
    "goodWithOtherAnimals": true,
    "goodWithChildren": true,
    "dateListed": "2022-01-15T00:00:00",
    "animalPhotoURL": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsuPg3g3nAvGkX3pJKCxVT92YlipcQW87tMQ&usqp=CAU"
  }
~~~

**Parameters**
* id (int) - the unique Id of the animal in the database.


**Example URLs (if applicable):**

* http://localhost:5000/api/animals/1 - the animal with the Id of 1 is returned


## POST
<hr>
POST requests are API calls to the database that add information to the database. You would use a POST request when you wanted to add a brand new animal to the database.

  <br>

### POST -  /api/Animals
**Purpose**: Posts animals to the database

**Example Request**:
~~~
POST /Animals
{
   "name": "Buddy",
   "species": "Dog",
   "breed": "Australian Shepard",
   "gender": "Male",
   "age": 0,
   "adoptionPrice": 800,
   "goodWithOtherAnimals": true,
   "goodWithChildren": true,
   "dateListed": "2022-01-15T00:00:00",
   "animalPhotoURL": "https://www.akc.org/wp-content/uploads/2017/01/australian-shepherd-puppy.jpeg"
}
~~~

**Example Response**:
~~~
  {
    200 Success
  }
~~~


## PUT
<hr>
PUT requests are API calls to the database that modify information in the database. You would use a PUT request when you wanted to edit the price of a dog, or any other property of an animal.

Note that with PUT requests, all properties are overwritten in the database for the entry you are modifying. For example, if you were to change just the price via a PUT request, you must also include all other information about the animal that is currently in the database, otherwise these entries will be overwritten with **null** values.

For every PUT request, you must include the AnimalID. Failing to do so will result in a 404 error, resulting in an unsuccessful call.

  <br>

### PUT -  /api/Animals/Id
**Purpose**: Posts animals to the database

**Example Request**:
~~~
PUT /Animals
{
   "AnimalId": 4
   "name": "Buddy",
   "species": "Dog",
   "breed": "Australian Shepard",
   "gender": "Male",
   "age": 0,
   "adoptionPrice": 200,
   "goodWithOtherAnimals": true,
   "goodWithChildren": true,
   "dateListed": (2022, 3, 2),
   "animalPhotoURL": "https/puppypictures.com/picture.jpg"
}
~~~

**Example Response**:
~~~
  {
    200 Success
  }
~~~

## DELETE
<hr>
DELETE requests remove an entry from the database. The only thing that is required when making a DELETE request is the animal Id in the database.

<br>

### DELETE -  /api/Animals/Id
**Purpose**: Deletes animals in the database

**Example Request**:
~~~
DELETE /Animals/3
{
}
~~~

**Example Response**:
~~~
  {
    200 Success
  }
~~~

# Known Bugs

- _There is no authentication present at this time._

<br>

# License

_MIT_

Copyright (c) _4-1--2022_ _Daniel Lindsey_
