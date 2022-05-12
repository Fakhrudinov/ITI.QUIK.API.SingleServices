using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.Extensions.Logging;

namespace QuikDataBaseRepository
{
    public class QuikDBRepository : IQuikDataBaseRepository
    {
        private ILogger<QuikDBRepository> _logger;
        public QuikDBRepository(ILogger<QuikDBRepository> logger)
        {
            _logger = logger;
        }

        public ListStringResponseModel CheckConnections()
        {
            _logger.LogInformation($"QuikDBRepository CheckConnections Called");

            return new ListStringResponseModel { IsSuccess = true, Messages = new List<string>() { "Ok" } };
        }
    }
}