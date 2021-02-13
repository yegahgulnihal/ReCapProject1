using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }//başarılı(true) ya da başarısız(false)
        string Message { get; }
    }
}
