using NTNP.EFCore.Models.ApplicationParameters;
using NTNP.Infratructure.Interfaces;

namespace NTNP.Infratructure.Repositories.ApplicationParameters
{
    public interface IApplicationParameterRepository : IRepository<ApplicationParameter>
    {
        int GetIntegerValue(string parameterName);
        string GetStringValue(string parameterName);
        bool GetBoolValue(string parameterName);
    }
}
