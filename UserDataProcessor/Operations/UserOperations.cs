using UserDataProcessor.Models;

namespace UserDataProcessor.Operations;

public class UserOperations
{
    private readonly List<User> _users;

    public UserOperations(List<User> users)
    {
        _users = users;
    }

    public User? FindUserByEmail(string email)
    {
        foreach (User user in _users)
        {
            if (string.Equals(user.Email, email, StringComparison.OrdinalIgnoreCase))
            {
                return user;
            }
        }

        return null;
    }

    public List<User> FindUsersByAgeOlderThan(int age)
    {
        List<User> users = new();

        foreach (User user in _users)
        {
            if (user.Age > age)
            {
                users.Add(user);
            }
        }

        return users;
    }

    public float CalculateAverageAge()
    {
        if (_users.Count == 0)
        {
            return 0;
        }

        int ageSum = 0;

        foreach (User user in _users)
        {
            ageSum += user.Age;
        }

        return (float)ageSum / _users.Count;
    }
}