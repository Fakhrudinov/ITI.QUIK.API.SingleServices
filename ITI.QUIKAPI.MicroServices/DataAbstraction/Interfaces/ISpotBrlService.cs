namespace DataAbstraction.Interfaces
{
    public interface ISpotBrlService
    {
        Task<string> CheckConnection();
        string GetLogin();
    }
}
