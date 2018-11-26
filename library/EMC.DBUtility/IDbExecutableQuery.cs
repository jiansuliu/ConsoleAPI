﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

namespace EMC.DbUtility
{


  /// <summary>
  /// 定义一个可以执行的查询
  /// </summary>
  public interface IDbExecutableQuery
  {

    /// <summary>
    /// 同步执行查询
    /// </summary>
    /// <returns></returns>
    IDbExecuteContext Execute();

  }



  /// <summary>
  /// 定义一个可以异步执行的查询
  /// </summary>
  public interface IAsyncDbExecutableQuery : IDbExecutableQuery
  {

    /// <summary>
    /// 异步执行查询
    /// </summary>
    /// <returns></returns>
    Task<IAsyncDbExecuteContext> ExecuteAsync( CancellationToken token );
  
  }
}
