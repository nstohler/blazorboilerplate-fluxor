using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public class ResultActionBase
    {
        [JsonIgnore] public Action<GetToDoItemsResultAction> ResultAction { get; set; }
    }
}
