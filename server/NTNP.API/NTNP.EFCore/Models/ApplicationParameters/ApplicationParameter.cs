using System.ComponentModel.DataAnnotations;

namespace NTNP.EFCore.Models.ApplicationParameters
{
    public class ApplicationParameter
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <example>1</example>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Parameter Name
        /// </summary>
        /// <example>MaxInvalidPasswordAttempts</example>
        public string ParameterName { get; set; } = null!;
        /// <summary>
        /// Value of parameter
        /// </summary>
        /// <example>4</example>
        public string ParameterValue { get; set; } = null!;
    }
}
