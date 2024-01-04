namespace WebAPINetCore8.Service
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}
