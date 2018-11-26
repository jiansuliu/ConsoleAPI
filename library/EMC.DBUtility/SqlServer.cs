﻿using EMC.DbUtility.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMC.DbUtility.Common;
using System.IO;

namespace EMC.DbUtility
{

  /// <summary>
  /// 提供 SQL Server 数据库访问支持
  /// </summary>
  public static class SqlServer
  {


    /// <summary>
    /// 从配置文件中读取连接字符串并创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="name">连接字符串配置名称</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor FromConfiguration( string name, SqlDbConfiguration configuration = null )
    {
      var setting = ConfigurationManager.ConnectionStrings[name];
      if ( setting == null )
        throw new InvalidOperationException();

      return Connect( setting.ConnectionString, configuration );
    }


    /// <summary>
    /// 通过指定的连接字符串并创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor Connect( string connectionString, SqlDbConfiguration configuration = null )
    {
      return new SqlDbExecutor( connectionString, configuration ?? Configuration );
    }



    /// <summary>
    /// 通过指定的连接字符串构建器创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="builder">连接字符串构建器</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor Connect( SqlConnectionStringBuilder builder, SqlDbConfiguration configuration = null )
    {
      return Connect( builder.ConnectionString, configuration );
    }



    /// <summary>
    /// 通过指定的用户名和密码登陆 SQL Server 数据库，以创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="dataSource">数据库服务器实例名称</param>
    /// <param name="initialCatalog">数据库名称</param>
    /// <param name="userID">登录数据库的用户名</param>
    /// <param name="password">登录数据库的密码</param>
    /// <param name="pooling">是否启用连接池（默认启用）</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor Connect( string dataSource, string initialCatalog, string userID, string password, bool pooling = true, SqlDbConfiguration configuration = null )
    {
      var builder = new SqlConnectionStringBuilder()
      {
        DataSource = dataSource,
        InitialCatalog = initialCatalog,
        IntegratedSecurity = false,
        UserID = userID,
        Password = password,
        Pooling = pooling
      };

      return Connect( builder.ConnectionString, configuration );
    }


    /// <summary>
    /// 通过集成身份验证登陆 SQL Server 数据库，以创建 SQL Server 数据库访问器
    /// </summary>
    /// <param name="dataSource">数据库服务器实例名称</param>
    /// <param name="initialCatalog">数据库名称</param>
    /// <param name="pooling">是否启用连接池（默认启用）</param>
    /// <param name="configuration">SQL Server 数据库配置</param>
    /// <returns>SQL Server 数据库访问器</returns>
    public static SqlDbExecutor Connect( string dataSource, string initialCatalog, bool pooling = true, SqlDbConfiguration configuration = null )
    {
      var builder = new SqlConnectionStringBuilder()
      {
        DataSource = dataSource,
        InitialCatalog = initialCatalog,
        IntegratedSecurity = true,
        Pooling = pooling
      };

      return Connect( builder.ConnectionString, configuration );
    }






    private static SqlDbConfiguration _defaultConfiguration = new SqlDbConfiguration();

    /// <summary>
    /// 获取或设置默认配置
    /// </summary>
    public static SqlDbConfiguration Configuration
    {
      get { return _defaultConfiguration; }
    }


    static SqlServer()
    {
      LocalDBInstanceName = "v11.0";
      ExpressInstanceName = "SQLEXPRESS";
    }


    internal static string LocalDBInstanceName { get; set; }

    internal static string ExpressInstanceName { get; set; }
  }
}
