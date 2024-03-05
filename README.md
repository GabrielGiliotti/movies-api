# Movies API

Movie API for review and practice of concepts.

## So what is an API?

API (Application Programming Interface) is a programming interface that abstracts implementation rules and allows resources to be made available in a standardized and secure way, that is, it allows different applications to access their resources as long as the rules established by the interface are met.

In a way, we can say that an API makes resources available without one or more external applications needing to know details of the implementation responsible for making the resources available, in addition to controlling what can or cannot be accessed.

## And what is REST ?

REST (REpresentational State Transfer) is a pattern or a set of architectural constraints used to implement APIs, which facilitate and speed up development by ensuring a well-defined architecture.

(You are NOT REQUIRED to implement this pattern, but it IS WIDELY USED and WELL KNOWN)

### RESTful API

An API that implements the REST standard is called a RESTful API, and it must meet the following requirements:

* Client-server architecture: indicates an architecture based on clients, servers and resources, in which requests are made via the HTTP protocol. This condition is linked to the independence between the client and the server. In other words, changes made by the user to the application on their device must not affect the server and its data structure. Likewise, changes made by developers to the application's databases should not instantly impact the user's device.

* Stateless communication: communication made between client and server must not store any information between requests. In a REST API, each request contains all the data necessary to be fulfilled, not depending on information already stored in other sessions.

* Uniform interface: the uniform interface is what allows independent development of the application between user and server. A REST API must contain a uniform interface as it offers standardized communication between the user and the software. The manipulation of resources through representations (such as JSON or XML) is one of the conditions for the development of a uniform interface.

* Layer system: each layer of the system must have a specific functionality (such as security or charging). Thus, each layer is responsible for a different step in the user request and server response processes. These layers are hierarchically ordered but, despite being separate, they all interact with each other.

* Cache: A REST API must be developed in such a way that it can cache data. When information is stored in cache, requests and responses between client and server are optimized.

## Controller-Service-Repository pattern .NET core

The Controller-Service-Repository pattern implemented in this repository is a bit different from the course we are reviewing, but I decided to implement it because it was a pattern widely used in my previous experiences as a developer, that is, the companies I worked for used this structure due to the benefits, which I will try to mention.

It is worth remembering that this pattern matches very well with DDD (Domain-Driven Design) which is a project architecture pattern focused on the business rules that an application may contain. 

This pattern also goes very well with TDD (Test-Driven Design) as it reduces coupling between project layers, facilitating testing and reuse (DRY - Dont't Repeat Yourself).

(We may go deeper into DDD and TDD patterns in the future)

As the name suggests, the Controller-Service-Repository pattern divides the application into three layers, where each one has its own well-defined responsibility:

* Controller: is responsible for exposing the functionality so that it can be consumed by external entities (including, perhaps, a UI component).

* Service: is where all the business logic should go. 

* Repository: is responsible for storing and retrieving some set of data.

## UnitOfWork (UoW) Pattern
 
Going further, we will implement the UnitOfWork (UoW) pattern in the repository layer. This is a design pattern used to manage transactions and ensure data consistency in your application when working with a database. It helps in coordinating multiple database operations within a single transaction scope.

## Using MySql database

After configuring the context and repository structure for data access, it is necessary to execute some commands to reflect the structure in the database installed on the machine.

Execute:

``` dotnet ef migrations add <MigrationName> ```

To create the migration for the database. 

And:

``` dotnet ef database update ```

To apply migrations to the database.

Note: The commands presented correspond to the .NET CLI, that is, they can be applied via the terminal at the command prompt or in VS Code

### 1:1 Relationship

Before performing the 1:1 mapping, if we want two entities to reflect each other's data in the response, we must configure the API to ignore cycles because, imagine the case of a 1:1 mapping of a cinema and an address, in which By placing the entities one inside the other, an infinite cycle will occur where a cinema references an address, which then references the cinema itself, which references the address...

So, in the non-ideal case where we want to carry out this mapping, we perform the following configuration in the Startup.cs class:

change

```builder.Services.AddControllers();```

for:

```builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);```

After adding the additional configuration for cyclic references in 1:1 relationships, we must reference in one of the classes that we are relating, in addition to the model data, the Id of the entity to which we want to relate. In the case of this API, the 1:1 relationship is between the cinema entity and the address entity, so either we create the address ID in the cinema entity, or we place the cinema ID in the address entity.

This must be done so that the EntityFramework understands the relationship and configures migrations correctly for the database.

NOTE: The direction of the relationship: Whether the Address will contain a single cinema or whether A cinema will contain a single address depends on the restrictions established in the project planning - it is up to the developer to decide.

### 1:n Relationship

For 1:n relationships, we must configure the relationship in the DbContext's OnModelCreating() method, defining for a given Entity, the 1:n relationship of a property and the ForeignKey.

See the example of the method below:

``` 
protected override void OnModelCreating(ModelBuilder modelBuilder) 
{   
    modelBuilder.Entity<Session>()
        .HasOne(session => session.MovieTheater)
        .WithMany(movieTheater => movieTheater.Sessions)
        .HasForeignKey(session => session.MovieTheaterId);
} 
```

### n:n Relationship

In n:n relationships, we must create an intermediate entity (table) that will make an n:1 1:n mapping with the entities that have an n:n relationship. Therefore, we must make 1:n configurations similar to those shown in the previous section, but 2 mappings will be necessary, such as:

```
1 MovieTheater has n Sessions  <-->  1 Session happen only in One MovieTheater
1 Movie can belong to n Sessions <--> 1 Session stream only One Movie

This implies that

n MovieTheaters has n Movies <--> n Movies are streamed in n MovieTheaters (Through sessions)
```

Note: The configuration is performed similarly to the 1:n relationship in the OnModelCreating() method.
