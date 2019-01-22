using Newtonsoft.Json;
using System.Collections.Generic;

namespace Quotation.Application.Models {
    public abstract class BaseResponse {

        [JsonIgnore]
        public bool Success { get; protected set; }
        public IList<string> Error { get; protected set; }

    }
}
