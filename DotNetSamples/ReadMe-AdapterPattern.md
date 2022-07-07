The adapter pattern is a pattern that uses an adapter.

think about your smartphone, the powersupply goes from a usb port to a wall outlet, this adapter A to B.
This pattern can be very usefull when you are using a specific system and like to change to another, but don't want to change the code.

as an example logging: let's say you are using log4net and implemented this across your entire project and like to change to serilog.

You will use the adapter patter to adapt log4net with serilog without chaning any code that logs something.


