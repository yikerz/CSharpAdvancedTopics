### Red Green Refactor

1. Create `xUnit Test` Project `Flight`
2. Install NuGet package, `FluentAssertion`
3. Change the test name to be descriptive
4. In the first test, test the following statements:
   1. The original seat capacity of the flight is 3
   2. The seat capacity should be 2 after 1 seat is booked
5. Fix the error in the test MINIMALLY
   1. Create new `class Library` project to the solution called `Domain.Test`
   2. Define method and prop for testing
   3. DO NOT implement test
6. Run the test and see it fails
7. Implement the method to make the test passed
8. (Optional) Refactoring
9. Create another `class Library` called `Domain`
10. In `Domain.Test.Flight`, click `Quick Actions and Refactorings -> Move content to namespaces` and move the class to `Domain`
11. Copy `Flight.cs` to `Domain` and delete it from `Domain.Test`
12. Add project reference to `FlightTest`

### Avoid Overbooking

13. Create test `Avoids_overbooking` with Given When Then Pattern
14. Modify `Book` method to make the test with no error
    1.  Change return type to `Object?` (`object` or `null`)
15. Create new class `OverbookingError`
16. Run test and see it fails
17. Implement logic in `Book` method

### Devils Advocate For Trustworthiness

18. Create test `Books_Flights_Successfully`
19. Error should be null if no overbooking

### Parameterized Test

20. Create another test using `[Theory]`and `[InlineData(vars)]` instead of `[Fact]` based on the first test
21. Allow input params for the test

### Booking List

22. Create another test `Verify_Booking`
23. Use TDD to finish the test (Hint: use `Should().ContainEquivalentOf`)
24. Refactoring, make `BookingList` read-only and can be added by `Book` only (Encapsulation)
    1.  Create `private bookingList` with `new()`
    2.  Create method `BookingList` returning `bookingList`
    3.  Modify constructor
    4.  Make sure the test is passed

### Cancel Booking

25. Implement parameterized test `Canceling_Bookings_Frees_Up_Seats`
    1.  Book flight
    2.  Cancel flight (create non-exist method)
    3.  Check seat capacity
26. Fail the test
27. Pass the test
28. Implement test using step 25-27
    1.  `Doesnt_cancel_bookings_for_passengers_who_have_not_booked`
    2.  `Returns_null_when_successfully_cancels_booking`

### Application Layer

29. Add new projects to the solution
    1.  `xUnit Test`: `Application.Tests`
    2.  `class library`: `Application`
    3.  `class library`: `Data`
30. Change the class name of `Application.Tests` to `FlightApplicationSpec`
31. Implement test `Books_flights`
    1.  Instantiate `BookingService`
    2.  Run method `bookService.Book`
        1. Param:`BookingDto(Guid.NewGuid, string email, int numberOfSeats)`
    3.  Method `FindBookings` should contain equivalent of
        1. `BookingRm("test@gmail.com", 2)`
32. Create new classes, `BookDto` and `BookingRm`, with constructor and properties
33. Look at why the test is failed and make it pass with minimum changes
    1.  `FindBookings` should return `array` contains`BookingRm("test@gmail.com", 2)`

### Connection With Backend

34. At the beginning of the test, instantiate `Entities` and `Flight` objects
35. Create `Entities` class in `Data` project (fix the error at step 34)
36. In the test, when the `BookingService` is instantiated, it takes `Entities` object as param
37. Create constructor for `BookingService` taking `Entities` as param
38. In the next line after instantiating `Entities`, add new `Flight` instance into `entities.Flights`
39. `Entities` class to be extended from `DbContext` (need to install `Microsoft.EntityFrameworkCore`)
    (NOTE: `Entities` can now be considered as a database )
40. Since `Entities` is a database, create read-only properties `Flights` for `DbSet<Flight>` type
    (NOTE: `Flights`in `Entities` can be considered as data table in the database)
    `public DbSet<Flight> Flights => Set<Flight>();`
41. In the test,
    1.  `BookingDto` should take `flight.Id` instead of `Guid.NewGuid` (create prop in Flight to fix the error)
    2.  `FindBookings` should take param `flight.Id`

### Configure In Memory Database

43. Install `EntityFramework.InMemory`
44. In test, we should pass `DbContextOptionsBuilder` to the `Entities` when it is instantiated (for database configuration)
    `var entities = new Entities(new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options);`
45. Create a proper constructor in `Entities` (base constructor should also be declared in this case)
46. Create default constructor for `Flight` with `Obsolete` attribute: "Needed by EF"
47. In `Entities` class, create method as below (this method is called when the model for the `DBContext` is being created):

```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	// config the primary key for Flight class
	modelBuilder.Entity<Flight>().HasKey(f => f.Id);
	// configures a relationship where Flight entity owns many Booking entities
	modelBuilder.Entity<Flight>().OwnsMany(f => f.BookingList);
	base.OnModelCreating(modelBuilder);
}
```

### Parameterize Book Flight Test

48. Modify test from `Fact` to `Theory` and add `InlineData` with some emails and seats
49. Change the hard coded inputs in the test to variables
50. Fail the test

### Implement Booking Service

51. Implement `Book`method
    1.  Since `Book` method adds `Booking` into database, it should take `Entities` as param (also need to create property `Entities` in `BookService` class)
    2.  Use `Entities` to `Find` the `Flight` by `bookDto.FlightId` (fix error)
    3.  Run `Book` method in the `flight` instance
    4.  Save `Entities` by `Entities.SaveChanges`
52. Implement `FindBookings`
    1.  Return `Entities.Flights.Find(flightId).BookingList.Select(booking => new BookingRm(...)`

### Refactoring

53. Move `BookingService`, `BookingDto` and `BookingRm` to namespace `Application`

### Create Test for Cancelling Bookings

54. Create test `Cancels_booking`
    1.  Create `Entities` like previous test
    2.  Create `Flight` and add into `Entities.Flights`
    3.  Create `BookingService`
    4.  Book a flight using `BookingService.Book`
    5.  Run `CancelBooking` from `bookingService` and pass `CanceBookingDto`, which takes `FlightId`, `Email` and `NumberOfSeats`
    6.  Check `CheckSeatCapacity(flightId)` should be ...
55. Create `CancelBookingDto` and constructor
56. Change the test from `Fact` to `Theory` and parameterize the test
57. Implement `CancelBooking` in `BookingService`
    1.  Find the `Flight` from `Entities`
    2.  Run `CancelBooking` from flight object
    3.  Save changes
58. Implement `CheckSeatCapacity`

### Refactoring

59. In the test, move the `Entities` instantiation and `BookingService` instantiate to the top before the first test (make them `readonly)
