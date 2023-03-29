using System.ComponentModel;

namespace NTNP.Infratructure.Helpers.Dtos
{
    public class ListBaseRequestModel
    {
        [DefaultValue(1)]
        public int Page { get; set; }
        public int Limit { get; set; }
        [DefaultValue("")]
        public string SearchKey { get; set; }
        [DefaultValue("name")]
        public string Keys { get; set; }
        public bool Reload { get; set; }
    }
}
