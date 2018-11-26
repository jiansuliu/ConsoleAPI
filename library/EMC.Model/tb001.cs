using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EMC.Model{
	 	//tb001
		public class tb001
	{
   		     
      		
		private int _noidtb001;
		/// <summary>
		/// 主键ID
        /// </summary>	
        public int NOIDTB001
        {
            get{ return _noidtb001; }
            set{ _noidtb001 = value; }
        }        
			
		private string _f001tb001;
		/// <summary>
		/// 管理员姓名
        /// </summary>	
        public string F001TB001
        {
            get{ return _f001tb001; }
            set{ _f001tb001 = value; }
        }        
			
		private string _f002tb001;
		/// <summary>
		/// 管理员帐号
        /// </summary>	
        public string F002TB001
        {
            get{ return _f002tb001; }
            set{ _f002tb001 = value; }
        }        
			
		private string _f003tb001;
		/// <summary>
		/// 管理员密码
        /// </summary>	
        public string F003TB001
        {
            get{ return _f003tb001; }
            set{ _f003tb001 = value; }
        }        
			
		private DateTime _f004tb001;
		/// <summary>
		/// 有效期开始
        /// </summary>	
        public DateTime F004TB001
        {
            get{ return _f004tb001; }
            set{ _f004tb001 = value; }
        }        
			
		private DateTime _f005tb001;
		/// <summary>
		/// 有效期结束
        /// </summary>	
        public DateTime F005TB001
        {
            get{ return _f005tb001; }
            set{ _f005tb001 = value; }
        }        
			
		private string _f006tb001;
		/// <summary>
		/// 最后登录IP
        /// </summary>	
        public string F006TB001
        {
            get{ return _f006tb001; }
            set{ _f006tb001 = value; }
        }        
			
		private DateTime _f007tb001;
		/// <summary>
		/// 最后登录时间
        /// </summary>	
        public DateTime F007TB001
        {
            get{ return _f007tb001; }
            set{ _f007tb001 = value; }
        }        
			
		private string _f008tb001;
		/// <summary>
		/// 手机号码
        /// </summary>	
        public string F008TB001
        {
            get{ return _f008tb001; }
            set{ _f008tb001 = value; }
        }        
			
		private int _f099tb001;
		/// <summary>
		/// 状态[0=禁止;1=正常]
        /// </summary>	
        public int F099TB001
        {
            get{ return _f099tb001; }
            set{ _f099tb001 = value; }
        }        
			
		private int _f100tb001;
		/// <summary>
		/// 操作员ID(Ref:NOIDTB001)
        /// </summary>	
        public int F100TB001
        {
            get{ return _f100tb001; }
            set{ _f100tb001 = value; }
        }        
			
		private int _f200tb001;
		/// <summary>
		/// 最后操作员(Ref:NOIDTB001)
        /// </summary>	
        public int F200TB001
        {
            get{ return _f200tb001; }
            set{ _f200tb001 = value; }
        }        
			
		private DateTime _f201tb001;
		/// <summary>
		/// 最后操作时间
        /// </summary>	
        public DateTime F201TB001
        {
            get{ return _f201tb001; }
            set{ _f201tb001 = value; }
        }        
			
		private DateTime _timetb001;
		/// <summary>
		/// 时间戳
        /// </summary>	
        public DateTime TIMETB001
        {
            get{ return _timetb001; }
            set{ _timetb001 = value; }
        }        
		   
	}
}