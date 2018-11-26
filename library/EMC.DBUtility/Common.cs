using EMC.DbUtility;
using EMC.DbUtility.Queries;
using EMC.DbUtility.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMC.DbUtility
{
    /// <summary>
    /// 通用Model操作基类
    /// </summary>
    public class Utility
    {
        private static MySqlDbExecutor db = new MySqlDbExecutor(ConfigurationManager.ConnectionStrings["ConnectionStringSystem"].ConnectionString, new MySqlDbConfiguration());
        private static object sync = new object();
        private static Dictionary<PropertyInfo, object[]> _propertyAttributesCache = new Dictionary<PropertyInfo, object[]>();

        /// <summary>
        /// 插入一个实例
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>自增长ID</returns>
        public static int Insert<T>(T entity)
        {
            var type = typeof(T);
            var properties = type.GetProperties().Where(p => !GetAttributes(p).OfType<NonFieldAttribute>().Any());
            ParameterizedQueryBuilder parms = new ParameterizedQueryBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + type.Name + "(");
            string fields = "";
            foreach (var p in properties)
            {
                var name = GetFieldname(p);
                if (name.IndexOf("NOID") == -1)
                {
                    fields += name + ",";
                    parms.AppendParameter(p.GetValue(entity, null));
                }
            }
            strSql.Append(fields.Substring(0, fields.Length - 1) + ") values({...});select @@IDENTITY");
            return db.T(strSql.ToString(), parms.CreateQuery().ParameterValues).ExecuteScalar<int>();
        }

        /// <summary>
        /// 插入多个实例
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>影响行数</returns>
        public static int Insert<T>(List<T> entitys)
        {
            var type = typeof(T);
            var properties = type.GetProperties().Where(p => !GetAttributes(p).OfType<NonFieldAttribute>().Any());
            int res = 0;
            try
            {
                using (var tran = db.BeginTransaction())
                {
                    foreach (T entity in entitys)
                    {

                        ParameterizedQueryBuilder parms = new ParameterizedQueryBuilder();
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + type.Name + "(");
                        string fields = "";
                        foreach (var p in properties)
                        {
                            var name = GetFieldname(p);
                            if (name.IndexOf("NOID") == -1)
                            {
                                fields += name + ",";
                                parms.AppendParameter(p.GetValue(entity, null));
                            }
                        }
                        strSql.Append(fields.Substring(0, fields.Length - 1) + ") values({...})");
                        res += tran.T(strSql.ToString(), parms.CreateQuery().ParameterValues).ExecuteNonQuery();
                    }
                    tran.Commit();
                }
            }
            catch
            {
                res = 0;
            }
            return res;
        }
        /// <summary>
        /// 得到Model组成SQL对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>Model组成SQL对象</returns>
        public static TModel GetInsertTModel<T>(T entity)
        {
            TModel tmodel = new TModel();
            var type = typeof(T);
            var properties = type.GetProperties().Where(p => !GetAttributes(p).OfType<NonFieldAttribute>().Any());
            ParameterizedQueryBuilder parms = new ParameterizedQueryBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + type.Name + "(");
            string fields = "";
            foreach (var p in properties)
            {
                var name = GetFieldname(p);
                if (name.IndexOf("NOID") == -1)
                {
                    fields += name + ",";
                    parms.AppendParameter(p.GetValue(entity, null));
                }
            }
            strSql.Append(fields.Substring(0, fields.Length - 1) + ") values({...});select @@IDENTITY");
            tmodel.SQL = strSql.ToString();
            tmodel.ParameterValues = parms.CreateQuery().ParameterValues;

            return tmodel;
        }

        /// <summary>
        /// 得到Model组成SQL对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>Model组成SQL对象</returns>
        public static TModel GetUpdateTModel<T>(T entity)
        {
            TModel tmodel = new TModel();
            var type = typeof(T);
            var properties = type.GetProperties().Where(p => !GetAttributes(p).OfType<NonFieldAttribute>().Any());
            ParameterizedQueryBuilder parms = new ParameterizedQueryBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update " + type.Name + " set ");
            string fields = "";
            string primarykey = "";
            string primaryvalue = "";
            int loop = 0;
            foreach (var p in properties)
            {
                var name = GetFieldname(p);
                if (name.IndexOf("OID") == -1)
                {
                    fields += name + "={" + loop + "},";
                    parms.AppendParameter(p.GetValue(entity, null));
                    loop++;
                }
                else
                {
                    primarykey = name;
                    primaryvalue = p.GetValue(entity, null).ToString();
                }
            }
            strSql.Append(fields.Substring(0, fields.Length - 1) + " where " + primarykey + "=" + primaryvalue);
            tmodel.SQL = strSql.ToString();
            tmodel.ParameterValues = parms.CreateQuery().ParameterValues;

            return tmodel;
        }

        /// <summary>
        /// 修改一个实例
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>影响行数</returns>
        public static int Update<T>(T entity)
        {
            var type = typeof(T);
            var properties = type.GetProperties().Where(p => !GetAttributes(p).OfType<NonFieldAttribute>().Any());
            ParameterizedQueryBuilder parms = new ParameterizedQueryBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update " + type.Name + " set ");
            string fields = "";
            string primarykey = "";
            string primaryvalue = "";
            int loop = 0;
            foreach (var p in properties)
            {
                var name = GetFieldname(p);
                if (name.IndexOf("OID") == -1)
                {
                    fields += name + "={" + loop + "},";
                    parms.AppendParameter(p.GetValue(entity, null));
                    loop++;
                }
                else
                {
                    primarykey = name;
                    primaryvalue = p.GetValue(entity, null).ToString();
                }
            }
            strSql.Append(fields.Substring(0, fields.Length - 1) + " where " + primarykey + "=" + primaryvalue);
            return db.T(strSql.ToString(), parms.CreateQuery().ParameterValues).ExecuteNonQuery();
        }

        /// <summary>
        /// 得到表实例
        /// </summary>
        /// <typeparam name="T">表实例类型</typeparam>
        /// <param name="ID">主键ID</param>
        /// <returns>表实例</returns>
        public static T GetModel<T>(int ID) where T : new()
        {
            var type = typeof(T);
            string tableName = type.Name;
            string primarykey = "NOID" + type.Name.Replace("_", "");
            string sqlStr = "select * from " + tableName + " where " + primarykey + "={0}";
            return db.T(sqlStr, ID).ExecuteEntity<T>();
        }


        /// <summary>
        /// 得到表实例
        /// </summary>
        /// <typeparam name="T">表实例类型</typeparam>
        /// <param name="where">筛选条件,如F001TB001 = 1</param>
        /// <returns>表实例</returns>
        public static T GetModel<T>(string where) where T : new()
        {
            var type = typeof(T);
            string tableName = type.Name;
            string sqlStr = "select * from " + tableName + " where " + where;
            return db.T(sqlStr).ExecuteEntity<T>();
        }

        /// <summary>
        /// 获取指定属性上的特性
        /// </summary>
        /// <param name="p">要获取特性的属性</param>
        /// <returns>属性上所设置的特性</returns>
        private static object[] GetAttributes(PropertyInfo p)
        {
            lock (sync)
            {
                object[] attributes;
                if (_propertyAttributesCache.TryGetValue(p, out attributes))
                    return attributes;
                attributes = p.GetCustomAttributes(false);
                _propertyAttributesCache[p] = attributes;
                return attributes;
            }
        }

        /// <summary>
        /// 获取属性所对应的字段名
        /// </summary>
        /// <param name="property">要获取字段名的属性</param>
        /// <returns>属性所对应的字段名</returns>
        private static string GetFieldname(PropertyInfo property)
        {
            var attribute = GetAttributes(property).OfType<FieldNameAttribute>().FirstOrDefault();
            if (attribute != null)
                return attribute.FieldName;
            return property.Name;
        }
    }

    /// <summary>
    /// Model组成SQL对象
    /// </summary>
    public class TModel
    {
        private string sql;
        /// <summary>
        /// SQL语句
        /// </summary>
        public string SQL
        {
            get { return sql; }
            set { sql = value; }
        }

        private object[] parameterValues;
        /// <summary>
        /// 参数数组
        /// </summary>
        public object[] ParameterValues
        {
            get { return parameterValues; }
            set { parameterValues = value; }
        }
    }
}
