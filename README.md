# AsyncAwaitReference
A small reference repo I made in case my amnesiac dumbass didnt understand the async await functionality again in C#(which is still goddamn confusing tbh)

This is the output for class AsyncAwait1:
![42571d9c-e359-4c27-8f14-6128041d93b1](https://github.com/gaurdian2701/AsyncAwaitReference/assets/55644010/495ef44b-8942-4898-9eb2-3b77ddbb5cab)

This is the output for class AsyncAwait2:
![be60655c-d68c-44d9-8ace-c9c2f688b705](https://github.com/gaurdian2701/AsyncAwaitReference/assets/55644010/b769f923-b058-4bb0-8fb1-e1120fb38172)

Both are the same, it's just that I added a lambda task in the AsyncAwait1 class to show that awaited functions allow us to catch the returned values(do they even get returnd at all if await is not used?).
As of now I don't know whether asynchronous(non-awaited) functions allow us to catch updated values as well, but I will update this repo in case I come across a solution.
