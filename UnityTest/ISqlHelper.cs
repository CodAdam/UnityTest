using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace  UnityTest

{
    public interface ISqlHelper
    {

         string SqlConnection();

    }

    public interface IOtherHelper
    {
        string GetSqlConnection();
    }
}