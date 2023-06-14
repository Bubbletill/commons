using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Database;

public class APIResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Data { get; set; }
}
