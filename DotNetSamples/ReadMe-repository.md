The repository pattern is a generaic abstraction pattern used for the repository.
There are many implementations of the repository pattern and not all of them are correct.

Most people complain about the update statement: should it be included or not because yeah, update is a action within the repository.
Well in my case I don't include it in my repository interface why? : becasue yes mssql server can handle update statements, but entityframework or your code not directly.
When you want to update an existing object in the databse you call the get method to get your item out of the database, then use logic to change the properties and then back the insert to update the object. Meaning you call get and insert not directly update.
However at the same time it also think it should included because if you have an interface you are going to use the interface to implement and if it is not included you wont have the update method.

But not everything is true tough, some people like to have an IRepository and then a specific implementation per repository that uses the IRepository: for example IRepository and ICustomerRepository : IRepository.

However if you don't have anything extra why do you want to create a new interface for the repository, it is not necessary. 
Most repositories go hand in hand with unit of work.


And what about the implementation itself: Let's say you have a method GetById you can have multiple possibilities for example get by guid or get by int or get by long.



