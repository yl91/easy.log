using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models
{
    /// <summary>
    /// 分页集合封装
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalRows
        {
            get;
            set;
        }

        /// <summary>
        /// 集合列表
        /// </summary>
        public List<T> Collections
        {
            get;
            set;
        }
    }
}
