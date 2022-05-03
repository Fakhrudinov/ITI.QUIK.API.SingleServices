namespace CommonServices
{
    public static class PortfoliosConvertingService
    {
        public static string GetCdPortfolio(string portfolio)
        {
            var portfolioParts = portfolio.Split("-");

            string result = portfolioParts[0]
                        + "/D"
                        + portfolioParts[2];           

            return result;
        }

        public static string GetSpotPortfolio(string portfolio)
        {
            var portfolioParts = portfolio.Split("-");

            string result = portfolioParts[0]
                        + "/"
                        + portfolioParts[2];

            return result;
        }

        public static string GetFortsQuikCode(string code)
        {
            return "SPBFUT" + code.Substring(2);
        }
    }
}