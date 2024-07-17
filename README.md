**This is an example of my Web API application implementation, featuring exception handling and processing, model validation and RESTful support.**

*There is a part of the real large-scale project. For demonstration purposes in the WebAPI, I've selected three controllers: two for managing similar entities—Revoked Devices and Registered Devices—and one for Vendors, which is common to both device types.*

- The project ` WebApiExample.Core` has defined interfaces to manage data with a source (in the real project this is typically a database, but not included in this example). It includes DTO classes for manipulating this data, as well as classes for paging, filtering and exceptions that services may throw. For demonstration purposes, only two exceptions are included: one for when an entity is not found, and another for when an entity already exists."

- The library` Web.Framework.Api` contains additional code for API functionality, including exception handlers (EntityAlreadyExistsAttribute, EntityNotFoundAttribute etc), a common error model to provide additional error information to client app, static strings and classes for validating data passed from client app (utilizing third-party NuGet package `FluentValidation`).

- The entry point application `WebApiExample` consists of controllers with API methods, including exception handling with the defined handlers, Swagger integration for API documentation, and other relevant functionalities.
