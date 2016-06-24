using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Log.Application.Models.Relation
{
    public class UserRelationModel
    {
        public int Id;

        public int UserId;

        /// <summary>
        /// 邀请人ID
        /// </summary>
        public int InviteUserId;

        /// <summary>
        /// 授权的应用的ID
        /// </summary>
        public int AppId;

        /// <summary>
        /// 是否接受授权
        /// </summary>
        public bool IsAccept;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate;
    }
}
