## Intro

Toasts are like a simple notification to the user. In most cases this is used for error handling, which is a must in your project.

A Toast service/component will consist of: a message, level, countdown.

The level is mostly an enumeration.
The component itself consists of the message en level as arguments and a timer to countdown, as most toasts only apear for a few seconds.


Also you need to think about the solid principles: the open/closed principle is the one  you need to think in this kind of situation.

To add a new level for instance: you have to edit the enumeration and add the level in the component.
However removing a level is the same backwards, but chances are high you will encounter errors as the certain level does not exist anymore.


In my line of work I only have come across 2 levels of display: success and fail.
This depends on the project, and or how you will display notifications to the user;

How often do you come across a website that actullay gives a message, maybe in a general error or critical error you will be redirected to an error page.

In logging you will have more levels for instance: debug, information, warning, error



## Sample

The sample i'm going to use and reuse is from chris sainty.
Take a look at his origianl sample: https://chrissainty.com/blazor-toast-notifications-using-only-csharp-html-css/
or take a look at github: https://github.com/chrissainty/BlazorToast

 #### I don't take any credit for someone else work.





