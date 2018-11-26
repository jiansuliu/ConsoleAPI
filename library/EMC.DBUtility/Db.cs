﻿using EMC.DbUtility.Common;
using EMC.DbUtility.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMC.DbUtility
{

  /// <summary>
  /// 提供一系列静态方法辅助访问数据库
  /// </summary>
  public static class Db
  {



    /// <summary>
    /// 解析模板表达式，创建参数化查询对象
    /// </summary>
    /// <param name="templateText">模板文本</param>
    /// <param name="args">模板参数</param>
    /// <returns>参数化查询</returns>
    public static ParameterizedQuery Template( string templateText, params object[] args )
    {
      if ( args == null )
        args = new object[] { null };

      if ( !AllowNonObjectArrayAsArgs )
      {
        if ( args.GetType() != typeof( object[] ) )
          args = new object[] { args };
      }

      return TemplateParser.ParseTemplate( templateText, args );
    }



    /// <summary>
    /// 解析模板表达式，创建参数化查询对象
    /// </summary>
    /// <param name="templateText">模板文本</param>
    /// <param name="args">模板参数</param>
    /// <returns>参数化查询</returns>
    public static ParameterizedQuery T( string templateText, params object[] args )
    {
      if ( args == null )
        args = new object[] { null };

      if ( !AllowNonObjectArrayAsArgs )
      {
        if ( args.GetType() != typeof( object[] ) )
          args = new object[] { args };
      }
      else
      {
        if ( args.Length == 1 )
        {
          var array = args[0] as Array;

          if ( array != null )
          {

            args = new object[array.Length];
            array.CopyTo( args, 0 );
          }
        }
      }

      return Template( templateText, args );
    }



    /// <summary>
    /// 允许非 object[] 类型的数组对象作为多参数列表使用，即允许任意类型数组展开成参数列表。
    /// </summary>
    public static bool AllowNonObjectArrayAsArgs { get; set; }


    /// <summary>
    /// 通过连接字符串设置，创建指定类型查询的执行器。
    /// </summary>
    /// <typeparam name="T">要执行的查询类型</typeparam>
    /// <param name="connectionStringName">连接字符串名</param>
    /// <returns>执行器</returns>
    public static IDbExecutor<T> CreateExecutor<T>( string connectionStringName ) where T : IDbQuery
    {
      var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringName];
      var provider = GetDbProvider( connectionStringSetting.ProviderName );

      if ( provider == null )
        return null;

      return provider.GetDbExecutor<T>( connectionStringSetting.ConnectionString );
    }

    private static IDbProvider GetDbProvider( string name )
    {
      return null;
    }



    /// <summary>
    /// 将多个参数化查询串联起来并用指定的字符串分隔
    /// </summary>
    /// <param name="sperator">分隔符</param>
    /// <param name="queries">参数化查询</param>
    /// <returns>串联后的结果</returns>
    public static ParameterizedQuery Join( this string sperator, params ParameterizedQuery[] queries )
    {

      if ( queries == null )
        throw new ArgumentNullException( "queries" );


      queries = queries.Where( i => i != null ).ToArray();//去除所有为 null 的参数化查询对象
      if ( !queries.Any() )
        return null;

      var builder = new ParameterizedQueryBuilder();
      queries[0].AppendTo( builder );

      foreach ( var q in queries.Skip( 1 ) )
      {
        if ( !builder.IsEndWithWhiteSpace() && !char.IsWhiteSpace( sperator[0] ) && Db.AddWhiteSpaceOnConcat )
          builder.Append( ' ' );

        builder.AppendText( sperator );

        if ( !builder.IsEndWithWhiteSpace() && !q.IsStartWithWhiteSpace() && Db.AddWhiteSpaceOnConcat )
          builder.Append( ' ' );

        builder.AppendPartial( q );
      }


      return builder.CreateQuery();
    }



    static Db()
    {
      AddWhiteSpaceOnConcat = true;
    }


    /// <summary>
    /// 获取或设置当串联两个参数化查询时，是否应当自动插入空白字符。
    /// </summary>
    internal static bool AddWhiteSpaceOnConcat
    {
      get;
      set;
    }

  }
}
