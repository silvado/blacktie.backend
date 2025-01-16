namespace Domain.Interfaces.Helpers
{
    public interface IHashHelper
    {
        string HashMD5(string input);
        string HashSHA256(string input);
    }
}
