using EMC.DbUtility;
using EMC.DbUtility.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMC.BLL
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class System
    {
        MySqlDbExecutor db = new MySqlDbExecutor(ConfigurationManager.ConnectionStrings["ConnectionStringSystem"].ConnectionString, new MySqlDbConfiguration());

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <returns>0=成功;1=帐号密码错误;2=帐号已经过期;3=帐号已经锁定</returns>
        public int AdminLogin(string F002TB001, string F003TB001, string F006TB001, ref EMC.Model.tb001 model, ref string Message)
        {
            int res = 1;
            #region 管理员登录
            string sqlStr = "select * from TB001 where F002TB001={0} and F003TB001={1}";
            model = db.T(sqlStr, F002TB001, F003TB001).ExecuteDynamicObject();
            if (model != null)
            {
                if (model.F004TB001 > DateTime.Now || model.F005TB001 < DateTime.Now)
                {
                    res = 2;
                    Message = "帐号已经过期";
                }
                else if (model.F099TB001 != 1)
                {
                    res = 3;
                    Message = "帐号已经锁定";
                }
                else
                {
                    res = 0;
                    Message = "登录成功";
                }
            }
            else
            {
                res = 1;
                Message = "用户名或者密码错误";
            }
            #endregion
            #region 插入登录日志
            try
            {
                using (var tran = db.BeginTransaction())
                {
                    //更新最后登录时间日志
                    if (res == 0)
                    {
                        tran.T("update TB001 set F006TB001={1},F007TB001=now() where NOIDTB001={0}", model.NOIDTB001, F006TB001).ExecuteNonQuery();
                    }

                    //插入登录日志
                    Model.tb1001 model_TB1001 = new Model.tb1001();
                    model_TB1001.F001TB1001 = F002TB001;
                    model_TB1001.F002TB1001 = F003TB001;
                    model_TB1001.F003TB1001 = res;
                    model_TB1001.F004TB1001 = Message;
                    model_TB1001.F005TB1001 = F006TB001;
                    model_TB1001.TIMETB1001 = DateTime.Now;

                    TModel tmodel = EMC.DbUtility.Utility.GetInsertTModel<EMC.Model.tb1001>(model_TB1001);
                    tran.T(tmodel.SQL, tmodel.ParameterValues).ExecuteNonQuery();

                    tran.Commit();
                }
            }
            catch
            {
                //插入日志失败 暂不做处理
            }
            #endregion
            return res;
        }

        /// <summary>
        /// 得到主导航
        /// </summary>
        public List<EMC.Model.tb003> GetMainMenu(int mid)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from TB003");
            sqlStr.Append(" where F099TB003=1");
            sqlStr.Append(" order by F097TB003");

            return db.T(sqlStr.ToString(), mid).ExecuteEntities<EMC.Model.tb003>().ToList();
        }

        /// <summary>
        /// 得到二级导航
        /// </summary>
        public List<EMC.Model.tb004> GetMenu(int mid, int meuid)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select * from TB004");
            sqlStr.Append(" where F003TB004={1} and F099TB004=1");
            sqlStr.Append(" order by F097TB004");

            return db.T(sqlStr.ToString(), mid, meuid).ExecuteEntities<EMC.Model.tb004>().ToList();
        }

        /// <summary>
        /// 得到页面列表
        /// </summary>
        public List<EMC.Model.tb002> GetPage(int mid, int meuid)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select TB002.* from TB002");
            sqlStr.Append(" inner join TB005 on F002TB005=NOIDTB002");
            sqlStr.Append(" where F001TB005={1} and F099TB005=1 and F099TB002=1");
            sqlStr.Append(" order by F097TB005");

            return db.T(sqlStr.ToString(), mid, meuid).ExecuteEntities<EMC.Model.tb002>().ToList();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        public List<EMC.Model.tb006> GetReloList(string key, int page, int limit, ref int count)
        {
            count = 0;
            int recordBeg = (page - 1) * limit;
            int recordEnd = page * limit - 1;
            string where = "";
            if (!string.IsNullOrEmpty(key))
            {
                where += " and (instr(F001TB006,{0})>0  or instr(F002TB006,{0})>0)";
            }
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append("select count(1) from TB006 where F099TB006=1 " + where);
            count = db.T(sqlCount.ToString(), key).ExecuteScalar<int>();

            StringBuilder sqlList = new StringBuilder();
            sqlList.Append("select TB006.* ");
            sqlList.Append(" from TB006");
            sqlList.Append(" where F099TB006=1" + where);
            sqlList.Append(" order by NOIDTB006");
            sqlList.Append(" limit {1},{2}");
            return db.T(sqlList.ToString(), key, recordBeg, recordEnd).ExecuteEntities<EMC.Model.tb006>().ToList();
        }
    }
}