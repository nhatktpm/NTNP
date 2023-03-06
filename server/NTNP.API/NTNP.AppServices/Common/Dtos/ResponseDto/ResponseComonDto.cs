using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNP.AppServices.Common.Dtos.ResponseDto
{
    public class ResponseComonDto
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public object Data { get; set; }
        public string Message { get; set; }

    }
}
