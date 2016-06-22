using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models.App
{
    public class AppModel
    {
        public int Id;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId;


        /// <summary>
        /// 是否记录
        /// </summary>
        public bool IsRecord;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate;

        /// <summary>
        /// ip
        /// </summary>
        public string Ip;
    }
}
