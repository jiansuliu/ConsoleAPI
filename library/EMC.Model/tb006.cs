using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb006
		public class tb006
	{
   		     
      		
		private int _noidtb006;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB006
        {
            get{ return _noidtb006; }
            set{ _noidtb006 = value; }
        }        
			
		private string _f001tb006;
		/// <summary>
		/// 角色名称
        /// </summary>	
        public string F001TB006
        {
            get{ return _f001tb006; }
            set{ _f001tb006 = value; }
        }        
			
		private string _f002tb006;
		/// <summary>
		/// 角色说明
        /// </summary>	
        public string F002TB006
        {
            get{ return _f002tb006; }
            set{ _f002tb006 = value; }
        }        
			
		private int _f003tb006;
		/// <summary>
		/// 角色类型
        /// </summary>	
        public int F003TB006
        {
            get{ return _f003tb006; }
            set{ _f003tb006 = value; }
        }        
			
		private int _f099tb006;
		/// <summary>
		/// 状态[0=禁止;1=正常]
        /// </summary>	
        public int F099TB006
        {
            get{ return _f099tb006; }
            set{ _f099tb006 = value; }
        }        
			
		private int _f100tb006;
		/// <summary>
		/// 操作员ID(Ref:NOIDTB001)
        /// </summary>	
        public int F100TB006
        {
            get{ return _f100tb006; }
            set{ _f100tb006 = value; }
        }        
			
		private int _f200tb006;
		/// <summary>
		/// 最后操作员(Ref:NOIDTB001)
        /// </summary>	
        public int F200TB006
        {
            get{ return _f200tb006; }
            set{ _f200tb006 = value; }
        }        
			
		private DateTime _f201tb006;
		/// <summary>
		/// 最后操作时间
        /// </summary>	
        public DateTime F201TB006
        {
            get{ return _f201tb006; }
            set{ _f201tb006 = value; }
        }        
			
		private DateTime _timetb006;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB006
        {
            get{ return _timetb006; }
            set{ _timetb006 = value; }
        }        
		   
	}
}