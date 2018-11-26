﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMC.DbUtility
{
  
  /// <summary>
  /// 这个接口指示该对象是一个可以执行的查询对象
  /// </summary>
  public interface IDbQuery
  {
  }


  internal interface IDbQueryContainer
  {

    IDbQuery Query { get; }

  }

}
