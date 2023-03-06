using System.ComponentModel;

namespace NTNP.AppServices.Common.Dtos.RequestDto
{
    public class ListBaseRequestDto
    {
        /// <summary>
        /// The limit number of item in a list
        /// </summary>
        /// <example>25</example>
        [DefaultValue(25)]
        public int Limit { get; set; }

        /// <summary>
        /// The first value within the page list
        /// </summary>
        /// <example>0</example>
        [DefaultValue(0)]
        public int Page { get; set; }

        /// <summary>
        /// The text typed in the search box for searching purpose
        /// </summary>
        /// <example>Master Account</example>
        [DefaultValue("")]
        public string SearchKey { get; set; }

        /// <summary>
        /// The key used to search
        /// Column name in grid
        /// </summary>
        /// <example>
        /// - name
        /// - username,first_Name,last_Name
        /// </example>
        [DefaultValue("name")]
        public string Keys { get; set; }

        /// <summary>
        /// The flag to reload list
        /// </summary>
        /// <example>true</example>
        public bool Reload { get; set; }
    }
}
