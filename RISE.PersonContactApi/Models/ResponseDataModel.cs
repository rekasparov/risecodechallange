using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.PersonContactApi.Models
{
    public class ResponseDataModel : IDisposable
    {
        public ResponseDataModel()
        {
            HasError = false;
            ErrorMessage = string.Empty;
            Data = null;
        }

        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
