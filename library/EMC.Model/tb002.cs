using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb002
		public class tb002
	{
   		     
      		
		private int _noidtb002;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB002
        {
            get{ return _noidtb002; }
            set{ _noidtb002 = value; }
        }        
			
		private string _f001tb002;
		/// <summary>
		/// 页面名称
        /// </summary>	
        public string F001TB002
        {
            get{ return _f001tb002; }
            set{ _f001tb002 = value; }
        }        
			
		private string _f002tb002;
		/// <summary>
		/// 页面路径
        /// </summary>	
        public string F002TB002
        {
            get{ return _f002tb002; }
            set{ _f002tb002 = value; }
        }        
			
		private string _f003tb002;
		/// <summary>
		/// 页面说明
        /// </summary>	
        public string F003TB002
        {
            get{ return _f003tb002; }
            set{ _f003tb002 = value; }
        }        
			
		private int _f099tb002;
		/// <summary>
		/// 状态[0=禁止;1=正常]
        /// </summary>	
        public int F099TB002
        {
            get{ return _f099tb002; }
            set{ _f099tb002 = value; }
        }        
			
		private int _f100tb002;
		/// <summary>
		/// 操作员ID(Ref:NOIDTB001)
        /// </summary>	
        public int F100TB002
        {
            get{ return _f100tb002; }
            set{ _f100tb002 = value; }
        }        
			
		private int _f200tb002;
		/// <summary>
		/// 最后操作员(Ref:NOIDTB001)
        /// </summary>	
        public int F200TB002
        {
            get{ return _f200tb002; }
            set{ _f200tb002 = value; }
        }        
			
		private DateTime _f201tb002;
		/// <summary>
		/// 最后操作时间
        /// </summary>	
        public DateTime F201TB002
        {
            get{ return _f201tb002; }
            set{ _f201tb002 = value; }
        }        
			
		private DateTime _timetb002;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB002
        {
            get{ return _timetb002; }
            set{ _timetb002 = value; }
        }        
		   
	}
}