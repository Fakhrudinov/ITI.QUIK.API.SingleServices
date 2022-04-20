namespace DataAbstraction.Interfaces
{
    public interface ISpotBrlService
    {
        string CheckConnection();
        string GetLogin();
        string AddClientPortfolioToCD_portfolio(string quikportfolio);
    }
}
