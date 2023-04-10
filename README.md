# **Movie Store Web App**

## 1) Project Description

It is an example that reflects Asp.Net MVC structure and is written by adhering to OOP principles. 
The example is inspired by the Movie Store assignment in the [Intermediate .Net Core training](https://app.atika.dev/courses/net-core/19-project-1) on the website [patika.dev](patika.dev).

This part of the project is considered as the admin screen of a website that sells movies. The project includes Film, category, director, actor and language entities. In the application, data can be created, removed and updated to the Entities and details can be seen in the web pages (**CRUD**).

## 2) Packages That Use In The Project

- Microsoft.EntityFrameworkCore(6.0.15)
- Microsoft.EntityFrameworkCore.SqlServer(6.0.15)
- Microsoft.EntityFrameworkCore.Tools(6.0.15)
- Automapper.Extensions.Microsoft.Dependencyinjection(12.0.0)
- Bogus(34.0.2)
- Fluentvalidation.Aspnetcore(11.2.2)
- Microsoft.Visualstudio.Web.Codegeneration.Design(6.0.12)

## 3) Project Path

- Entities to be used in the application are defined in the model folder.
- **Fluent API** is used for mapping of entities.
- Context created. Database connection is provided with **Dependency Injection**.
- Database was created with migration operations.
- Methods for database operations were written using the **Repository Design Pattern**.
- View models were created to be used in controllers.
- **Data Annotation** and **Fluent Validation** were used for the validation of the view models.
- Objects to be used in the controller (such as Repositories and mappers) were created in accordance with **IoC/DI container** principles.
- **AutoMapper** is used to map View Models and Entities.
- View pages were created using **Boostrap** and **BoostrapWatch**.
- **Bogus** was used to generate data for the database.

## 4) Future Aspect

- App user class will be added to the project by using Microsoft.AspNetCore.Identity.EntityFrameworkCore package.
- n-tier architecture will be applied to the project
- Customer entity, controller and views will be created.
- Authentication, Authorization will be applied.
- AJAX will be entegrated with views.
- Unit tests will be written



#### Customer =>
- UserName = customer 
- Password = 1234

#### Admin => 
- UserName = admn1 
- Password = 1234
