﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace UnityTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer mycontainer = new UnityContainer();
            

            //已有对象实例的配置容器注册
            MysqlHelper d = new MysqlHelper();
            mycontainer.RegisterInstance<ISqlHelper>(d);

            //类型的配置容器注册
            mycontainer.RegisterType<ISqlHelper, MysqlHelper>();

            //配置文件注册
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(mycontainer,"MysqlHelper");
            //mycontainer.LoadConfiguration(section); 

            //调用依赖
            ISqlHelper mysql = mycontainer.Resolve<ISqlHelper>();
            Console.WriteLine(mysql.SqlConnection());



            //构造函数注入
            mycontainer.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper other = mycontainer.Resolve<IOtherHelper>();
            Console.WriteLine(other.GetSqlConnection());


            //test
            MssqlHelper m = new MssqlHelper();
            mycontainer.RegisterInstance<ISqlHelper>(m);
            mycontainer.RegisterType<ISqlHelper, MssqlHelper>();
            UnityConfigurationSection mssession = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(mycontainer, "MssqlHelper");
            ISqlHelper mssql = mycontainer.Resolve<ISqlHelper>();
            Console.WriteLine(mssql.SqlConnection());

            Console.ReadKey();

        }
    }


}