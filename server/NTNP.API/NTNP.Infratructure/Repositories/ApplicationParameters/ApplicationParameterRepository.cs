using Microsoft.Extensions.Logging;
using NTNP.EFCore.Models.ApplicationParameters;
using System.Data.Entity;

namespace NTNP.Infratructure.Repositories.ApplicationParameters
{
    public class ApplicationParameterRepository : Repository<ApplicationParameter>, IApplicationParameterRepository
    {
        private readonly ILogger<ApplicationParameterRepository> _logger;
        public ApplicationParameterRepository(DbFactory dbFactory, ILogger<ApplicationParameterRepository> logger) : base(dbFactory)
        {
            _logger = logger;
        }

        public bool GetBoolValue(string parameterName)
        {
            try
            {
                var parameter = DbSet.FirstOrDefault(x => string.Equals(x.ParameterName, parameterName));

                bool returnValue = Convert.ToBoolean(parameter?.ParameterValue);

                return returnValue;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ApplicationParameterRepository: '" + parameterName +
                    "' does not exist or cannot be converted to a Boolean");

                throw new Exception("ApplicationParameterRepository: '" + parameterName +
                                    "' does not exist or cannot be converted to a Boolean");
            }
        }

        public int GetIntegerValue(string parameterName)
        {
            try
            {
                var parameter = DbSet.FirstOrDefault(x => string.Equals(x.ParameterName, parameterName));

                int returnValue = Convert.ToInt32(parameter?.ParameterValue);

                return returnValue;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ApplicationParameterRepository: '" + parameterName +
                    "' does not exist or cannot be converted to a Boolean");

                throw new Exception("ApplicationParameterRepository: '" + parameterName +
                                    "' does not exist or cannot be converted to an Integer");
            }
        }

        public string GetStringValue(string parameterName)
        {
            var parameter = DbSet.FirstOrDefault(x => string.Equals(x.ParameterName, parameterName));

            if (parameter == null)
            {
                return string.Empty;
            }

            return parameter.ParameterValue;
        }
    }
}
