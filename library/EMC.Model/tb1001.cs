using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb1001
		public class tb1001
	{
   		     
      		
		private int _noidtb1001;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB1001
        {
            get{ return _noidtb1001; }
            set{ _noidtb1001 = value; }
        }        
			
		private string _f001tb1001;
		/// <summary>
		/// 登录帐号
        /// </summary>	
        public string F001TB1001
        {
            get{ return _f001tb1001; }
            set{ _f001tb1001 = value; }
        }        
			
		private string _f002tb1001;
		/// <summary>
		/// 登录密码
        /// </summary>	
        public string F002TB1001
        {
            get{ return _f002tb1001; }
            set{ _f002tb1001 = value; }
        }        
			
		private int _f003tb1001;
		/// <summary>
		/// 登录状态
        /// </summary>	
        public int F003TB1001
        {
            get{ return _f003tb1001; }
            set{ _f003tb1001 = value; }
        }        
			
		private string _f004tb1001;
		/// <summary>
		/// 登录信息
        /// </summary>	
        public string F004TB1001
        {
            get{ return _f004tb1001; }
            set{ _f004tb1001 = value; }
        }        
			
		private string _f005tb1001;
		/// <summary>
		/// 登录IP
        /// </summary>	
        public string F005TB1001
        {
            get{ return _f005tb1001; }
            set{ _f005tb1001 = value; }
        }        
			
		private DateTime _timetb1001;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB1001
        {
            get{ return _timetb1001; }
            set{ _timetb1001 = value; }
        }        
		   
	}
}