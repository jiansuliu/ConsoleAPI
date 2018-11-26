using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb003
		public class tb003
	{
   		     
      		
		private int _noidtb003;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB003
        {
            get{ return _noidtb003; }
            set{ _noidtb003 = value; }
        }        
			
		private string _f001tb003;
		/// <summary>
		/// 导航名称
        /// </summary>	
        public string F001TB003
        {
            get{ return _f001tb003; }
            set{ _f001tb003 = value; }
        }        
			
		private string _f002tb003;
		/// <summary>
		/// 导航说明
        /// </summary>	
        public string F002TB003
        {
            get{ return _f002tb003; }
            set{ _f002tb003 = value; }
        }        
			
		private int _f097tb003;
		/// <summary>
		/// 排序
        /// </summary>	
        public int F097TB003
        {
            get{ return _f097tb003; }
            set{ _f097tb003 = value; }
        }        
			
		private int _f099tb003;
		/// <summary>
		/// 状态[0=禁止;1=正常]
        /// </summary>	
        public int F099TB003
        {
            get{ return _f099tb003; }
            set{ _f099tb003 = value; }
        }        
			
		private int _f100tb003;
		/// <summary>
		/// 操作员ID(Ref:NOIDTB001)
        /// </summary>	
        public int F100TB003
        {
            get{ return _f100tb003; }
            set{ _f100tb003 = value; }
        }        
			
		private int _f200tb003;
		/// <summary>
		/// 最后操作员(Ref:NOIDTB001)
        /// </summary>	
        public int F200TB003
        {
            get{ return _f200tb003; }
            set{ _f200tb003 = value; }
        }        
			
		private DateTime _f201tb003;
		/// <summary>
		/// 最后操作时间
        /// </summary>	
        public DateTime F201TB003
        {
            get{ return _f201tb003; }
            set{ _f201tb003 = value; }
        }        
			
		private DateTime _timetb003;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB003
        {
            get{ return _timetb003; }
            set{ _timetb003 = value; }
        }        
		   
	}
}