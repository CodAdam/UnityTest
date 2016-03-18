using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityTest
{
    public class MssqlHelper:ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mssql.";
        }
    }

    public class MysqlHelper : ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mysql.";
        }
    }
    public class MyOtherHelper:IOtherHelper
    {
        ISqlHelper sql;
        public MyOtherHelper(ISqlHelper sql)
        {
            this.sql = sql;
        }
        public string GetSqlConnection()
        {
            return this.sql.SqlConnection();
        }


    }

}