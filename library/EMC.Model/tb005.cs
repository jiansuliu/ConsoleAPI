using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb005
		public class tb005
	{
   		     
      		
		private int _noidtb005;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB005
        {
            get{ return _noidtb005; }
            set{ _noidtb005 = value; }
        }        
			
		private int _f001tb005;
		/// <summary>
		/// 导航ID(Ref:NOIDTB004)
        /// </summary>	
        public int F001TB005
        {
            get{ return _f001tb005; }
            set{ _f001tb005 = value; }
        }        
			
		private int _f002tb005;
		/// <summary>
		/// 页面ID(Ref:NOIDTB002)
        /// </summary>	
        public int F002TB005
        {
            get{ return _f002tb005; }
            set{ _f002tb005 = value; }
        }        
			
		private int _f097tb005;
		/// <summary>
		/// 排序
        /// </summary>	
        public int F097TB005
        {
            get{ return _f097tb005; }
            set{ _f097tb005 = value; }
        }        
			
		private int _f099tb005;
		/// <summary>
		/// 状态[0=禁止;1=正常]
        /// </summary>	
        public int F099TB005
        {
            get{ return _f099tb005; }
            set{ _f099tb005 = value; }
        }        
			
		private int _f100tb005;
		/// <summary>
		/// 操作员ID(Ref:NOIDTB001)
        /// </summary>	
        public int F100TB005
        {
            get{ return _f100tb005; }
            set{ _f100tb005 = value; }
        }        
			
		private int _f200tb005;
		/// <summary>
		/// 最后操作员(Ref:NOIDTB001)
        /// </summary>	
        public int F200TB005
        {
            get{ return _f200tb005; }
            set{ _f200tb005 = value; }
        }        
			
		private DateTime _f201tb005;
		/// <summary>
		/// 最后操作时间
        /// </summary>	
        public DateTime F201TB005
        {
            get{ return _f201tb005; }
            set{ _f201tb005 = value; }
        }        
			
		private DateTime _timetb005;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB005
        {
            get{ return _timetb005; }
            set{ _timetb005 = value; }
        }        
		   
	}
}