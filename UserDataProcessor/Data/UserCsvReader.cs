using UserDataProcessor.Models;

namespace UserDataProcessor.Data;

public class UserCsvReader
{
    public static List<User> ReadUsers(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            List<User> users = new();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                users.Add(new User
                {
                    Id = int.Parse(columns[0]),
                    Name = columns[1],
                    Email = columns[2],
                    Age = int.Parse(columns[3])
                });
            }

            return users;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
            throw;
        }
    }
}