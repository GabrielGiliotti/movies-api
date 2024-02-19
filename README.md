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

