using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public interface IResultAction
    {
        Object Data         { get; }
        bool   IsSuccess    { get; }
        string ErrorMessage { get; }
    }
}