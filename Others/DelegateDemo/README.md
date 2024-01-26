## Method Filtering with Delegates

In some scenarios, we may need to pass a method as an argument to another method. Consider the following example where a method `DisplayBaby` includes filtering logic:

```csharp
public void DisplayBaby(List<Person> people)
{
  foreach(Person p in people)
  {
    if (p.Age < 5)
    {
      Console.WriteLine(p.Name);
    }
  }
}
```

To create a more generic method, such as `DisplayFilteredPeople`, capable of handling various filtering criteria, we introduce delegates. For instance:

```csharp
public void DisplayFilteredPeople(List<Person> people, FilterDelegate filter)
{
  foreach(Person p in people)
  {
    if (filter(p))
    {
      Console.WriteLine(p.Name);
    }
  }
}
```

Here, `FilterDelegate` is a delegate type representing any method that takes a Person as an argument and returns a boolean. To use this delegate, define methods with matching signatures, like:

```csharp
public bool Filter(Person p)
{
  // Custom filtering logic
  // ...
  return /* true or false based on the condition */;
}
```

Ensure that the delegate has the same signature, including the access modifier, return type, and input type, as the actual filtering methods.

There is a more convenient way of declaring delegates using the Func and Action generic delegate types. In this case, we could use `Func<Person, bool>` instead of explicitly declaring a delegate, like this:

```csharp
// Use Func delegate in your method
public void DisplayFilteredPeople(List<Person> people, Func<Person, bool> filter)
{
  foreach(Person p in people)
  {
    if (filter(p))
    {
      Console.WriteLine(p.Name);
    }
  }
}

```
