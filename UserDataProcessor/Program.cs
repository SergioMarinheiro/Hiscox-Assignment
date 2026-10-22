using UserDataProcessor.Operations;
using UserDataProcessor.Data;

string fPath = Path.Combine(AppContext.BaseDirectory, "users.csv");
string email = "jane.smith@example.com";
int age = 30;

//Read users from CSV
var users = UserCsvReader.ReadUsers(fPath);

//Initialize UserOperations with the list of users
var userService = new UserOperations(users);

//Email filter
var user = userService.FindUserByEmail(email);
Console.WriteLine($"Id: {user?.Id}, Name: {user?.Name}, Age: {user?.Age}");

//Greater than age filter
var olderUsers = userService.FindUsersByAgeOlderThan(age);
Console.WriteLine($"Users older than {age}:");

foreach (var olderUser in olderUsers)
{
    Console.WriteLine($"Name: {olderUser.Name} - Age: {olderUser.Age}");
}

//Average age calculation
var averageAge = userService.CalculateAverageAge();
Console.WriteLine($"Average age of users: {averageAge}");