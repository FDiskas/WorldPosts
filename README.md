# WorldPosts
WPF app that loads a 100 random posts

## Context

This application was build as an assessment task.
It does not meet the requirements by one point: it does not contain a 10x10 grid, but instead a 4x25 grid.
That was done on purpose just for visual representation reasons, as 10x10 grid wasn't looking too great :)

## Screenshot

![Screenshot](https://github.com/VytautasLozickas/WorldPosts/blob/master/screenshot.png)

## Running the app

To run this app first you need to install NuGet packages. After that - build and run as usual.

## Assessment Q&A

> 1. In C\# there are several ways to make code run in multiple threads. To make things easier, the await keyword was introduced; what does this do?

The await keyword allows async method to be suspended until asynchronous operation is completed in another thread. The result of asynchronous thread operation is evaluated only when thread completes and calling async method execution continues.

---

> 2. If you make http requests to a remote API directly from a UI component, the UI will freeze for a while, how can you use await to avoid this and how does this work?

You can avoid this by wrapping API calls inside async methods and waiting for http request results with await. This allows main thread to continue execution (updating the UI, executing other code or event listeners) while another thread is waiting on response from the request.

---

> 3. Imagine that you have to process a large unsorted CSV file with two columns: productId (int) and availableIn (ISO2 String, e.g. "US", "NL"). The goal is to group the file sorted by productId together with a list where the product is available. Example: `1, "DE" 2, "NL" 1, "US" 3, "US"` Becomes: `1 -> ["DE", "US"] 2 -> ["NL"] 3 -> ["US"]`
a. How would you do this using LINQ syntax (write a short example)?

Something like this could work:
```
var grouped = from p in products
    order by p.Id ascending
    group p.AvailableIn by p.Id into gp
    select new { Id = gp.key, AvailableIn = gp.ToList() };
```

> b. The program crashes with an OutOfMemoryError after processing approx. 80%. What would you do to succeed?

Split the data into chunks and merge the results after a multithreaded grouping.

---

> 4. In C# there is an interface IDisposable.
a. Give an example of where and why to implement this interface.

A class that deals with unmanaged resources should implement this interface so those resources could be released from the memory. One example could be a class that imports an unmanaged library (dll) which returns a memory pointer that we need to clean up after its use.

> b. We can use disposable objects in a using block. What is the purpose of doing this?

To dispose resources as quickly as possible. If the method has more code to execute after the block where the resource was used, we can wrap that code into the using block so the resource is disposed immediately after the code is executed inside the using block.

---

> 5. When a user logs in on our API, a JWT token is issued and our Outlook plugin uses this
token for every request for authentication. Here's an example of such a token:
`eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIi wibmFtZSI6IkplcmVteSIsImFkbWluIjpmYWxzZX0.BgcLOiwBvyuisQk9yWW0q 0ZScMyIHNmDctw12-meCHU`
Why and when is it (or isn't it) safe to use this?

It is safe to use this token as it is hardly possible to forge it as the token has embedded signature that only the server with a matching key can validate or create.
It is not safe to use this token if it was compromised even if the token has an expiration date and when stolen might not last long.
