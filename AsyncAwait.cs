using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwait1 : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log(AsyncFunc1());
        AsyncFunc2(); //I cannot await this, since it's return type is void. I can await Func1, since it's return type is Task.
        var value = await Task.Run(async () =>
        {
            Debug.Log("Task 3 started. Wait for 3 seconds...");
            await Task.Delay(3000);
            Debug.Log("Task 3 Completed. Returning value: ");
            return 30;
        });
        Debug.Log(value);
    }

    //Func1 and Func2 run in background asynchronously if await is not used. But you cant get the return value for Func 1 since you dont use await.
    //Instead, you could use a lambda function
    //Task 3 uses an async lambda function and since we use await, we actually get the return value
    private async void AsyncFunc2() //Has void return type.
    {
        Debug.Log("Task 2 Started. Wait for 2 seconds...");
        await Task.Delay(2000);
        Debug.Log("Task 2 Completed");
    }

    private async Task<int> AsyncFunc1()
    {
        Debug.Log("Task 1 started. Wait for 3 seconds...");
        await Task.Delay(3000);
        Debug.Log("Task 1 Completed. Returning value: ");
        return 30; // This will not get returned/get caught (which one actually?)
    }
}

//NOTE: 
//1. ONLY FUNCTIONS WITH TASK RETURN TYPE CAN BE AWAITED.
//2. If we actually used the await keyword on Func1 and Func2, we would have to wait for both these processes to finish, i.e.
//   We would wait for Func1 to finish executing, and then when it finishes, Func2 starts executing.
//   If a function uses await keyword, it will need the async keyword included in it's declaration, just like all the functions present here.
//   If we didn't use await on both the functions(which is the case over here), we don't need the async keyword in the function declaration.  
//   This means that the functions will run PARALLELLY IN THE BACKGROUND, WE DON'T USE THE AWAIT KEYWORD FOR PARALLEL FUNCTIONS.
//   Here's an example of that:

public class AsyncAwait2 : MonoBehaviour
{
    private void Start() //START FUNCTION DOES NOT USE THE ASYNC KEYWORD since we dont use await anywhere here
    {
        Debug.Log(AsyncFunc1());
        AsyncFunc2();
    }

    //Func1 and Func2 run in background asynchronously if await is not used. But you cant get the return value for Func 1 since you dont use await.
    private async void AsyncFunc2()
    {
        Debug.Log("Task 2 Started. Wait for 2 seconds...");
        await Task.Delay(2000);
        Debug.Log("Task 2 Completed");
    }

    private async Task<int> AsyncFunc1()
    {
        Debug.Log("Task 1 started. Wait for 3 seconds...");
        await Task.Delay(3000);
        Debug.Log("Task 1 Completed. Returning value: ");
        return 30;
    }
    //Func1 and Func2 start at the same time since both run asynchronously
}
