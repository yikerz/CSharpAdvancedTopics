1. Create `xUnit Test` Project
2. Install NuGet package, `FluentAssertion`
3. Change the test name to be descriptive
4. In the first test, test the following statement:
   1. `Calculator.Sum(2,2)` should be 4
5. Fix the error in the test MINIMALLY
   1. Create new `class Library` project to the solution
   2. Define method for testing, in this case, `Sum(int int)`
   3. DO NOT implement test
6. Run the test and see it fails
7. Implement the method to make the test passed
8. (Optional) Refactoring the test to make it one line
