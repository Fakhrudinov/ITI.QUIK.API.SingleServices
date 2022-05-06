using DataAbstraction.Interfaces;
using QDealerAPI;
using DataAbstraction.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using DataAbstraction.Models.Connections;

namespace QuikAPIBrlService
{
    public class FortsService : IFortsBrlService
    {
        private const string _fortsFIRM = "SPBFUT";
        private QadminLogon _logon;
        private ILogger<SpotService> _logger;
        IQuikApiConnectionService _connection;

        public FortsService(IOptions<QadminLogon> logon, ILogger<SpotService> logger, IQuikApiConnectionService connection)
        {
            _logon = logon.Value;
            _logger = logger;
            _connection = connection;
        }


        public string GetLogin()
        {
            _logger.LogInformation("FortsService GetLogin Called");
            return _logon.Login;
        }

        public ListStringResponseModel CheckConnection()
        {
            _logger.LogInformation("FortsService CheckConnection Called");
            ListStringResponseModel response = new ListStringResponseModel();

            var openResult = _connection.OpenQuikQadminApiToRead(_fortsFIRM, response);
            if (!openResult.IsSuccess)
            {
                return response;
            }

            return _connection.CloseQuikAPI(0, _fortsFIRM, response);
        }
    }
}
