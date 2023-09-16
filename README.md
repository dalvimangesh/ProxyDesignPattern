# Proxy Design Pattern

## Overview
The Proxy design pattern is a structural design pattern that provides a surrogate or placeholder for another object to control access to it. It acts as an intermediary, allowing you to add additional functionality or control over the actual object without modifying its code.

Real-world applications of the Proxy pattern include:

1. Virtual Proxies: When you want to create objects only when they are needed to save resources.
2. Remote Proxies: Used in distributed systems to represent objects that exist in different address spaces.
3. Cache Proxies: Caching data to improve performance by avoiding repetitive, expensive operations.
4. Protection Proxies: Adding access control and permissions to restrict access to the real object.
5. Logging Proxies: Recording usage statistics or logging method calls for debugging or monitoring purposes.

In summary, the Proxy design pattern allows you to control access to objects and can be applied in various scenarios to enhance an object's behavior or manage its lifecycle.

## Design
In this project, I have implemented a simple proxy server. The client needs to use a valid API key to connect to the server through the proxy. Within the proxy server, I check if the API key is valid before allowing the client to establish a connection with the server. Once connected, the client can send and receive data from the server. Even if the client gets disconnected and then reconnects, their previous data is retained on the server. However, if a client is not connected, they are not allowed to use the send, get, or disconnect functions.

In this design, each function returns a Status object containing a status code and any associated data if the client requests it.

![image](https://github.com/dalvimangesh/ProxyDesignPattern/assets/75742776/390b9e85-c2b5-4fbe-9270-05c5f4f91733)


