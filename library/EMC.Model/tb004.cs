using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb004
		public class tb004
	{
   		     
      		
		private int _noidtb004;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB004
        {
            get{ return _noidtb004; }
            set{ _noidtb004 = value; }
        }        
			
		private string _f001tb004;
		/// <summary>
		/// 导航名称
        /// </summary>	
        public string F001TB004
        {
            get{ return _f001tb004; }
            set{ _f001tb004 = value; }
        }        
			
		private string _f002tb004;
		/// <summary>
		/// 导航说明
        /// </summary>	
        public string F002TB004
        {
            get{ return _f002tb004; }
            set{ _f002tb004 = value; }
        }        
			
		private int _f003tb004;
		/// <summary>
		/// 主导航ID(Ref:NOIDTB003)
        /// </summary>	
        public int F003TB004
        {
            get{ return _f003tb004; }
            set{ _f003tb004 = value; }
        }        
			
		private int _f097tb004;
		/// <summary>
		/// 排序
        /// </summary>	
        public int F097TB004
        {
            get{ return _f097tb004; }
            set{ _f097tb004 = value; }
        }        
			
		private int _f099tb004;
		/// <summary>
		/// 状态[0=禁止;1=正常]
        /// </summary>	
        public int F099TB004
        {
            get{ return _f099tb004; }
            set{ _f099tb004 = value; }
        }        
			
		private int _f100tb004;
		/// <summary>
		/// 操作员ID(Ref:NOIDTB001)
        /// </summary>	
        public int F100TB004
        {
            get{ return _f100tb004; }
            set{ _f100tb004 = value; }
        }        
			
		private int _f200tb004;
		/// <summary>
		/// 最后操作员(Ref:NOIDTB001)
        /// </summary>	
        public int F200TB004
        {
            get{ return _f200tb004; }
            set{ _f200tb004 = value; }
        }        
			
		private DateTime _f201tb004;
		/// <summary>
		/// 最后操作时间
        /// </summary>	
        public DateTime F201TB004
        {
            get{ return _f201tb004; }
            set{ _f201tb004 = value; }
        }        
			
		private DateTime _timetb004;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB004
        {
            get{ return _timetb004; }
            set{ _timetb004 = value; }
        }        
		   
	}
}