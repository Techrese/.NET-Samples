###intro 

Singleton pattern is a pattern that cannot be instantiated, but rather creates an instance inside, therefore the constructor is private.
Singleton pattern is only one instance and cannot have multiple instances, there are not alot of usecases where you would need to have one instance.
The only thing I can think of right now is in-memory databases or specific things that only need one instance: tcp listeners or udp listeners can be an example,
however in .net core you could inject it as scoped rather than singleton