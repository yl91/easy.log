using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Log.Model.Relation
{
    /// <summary>
    /// 用户关系
    /// </summary>
    public class UserRelation : EntityBase<int>
    {
        public UserRelation()
        {
        }

        public UserRelation(int userId,int inviteUserId,int appId)
        {
            this.UserId = userId;
            this.InviteUserId = inviteUserId;
            this.AppId = appId;
            this.CreateDate=DateTime.Now;
            this.IsAccept = false;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get;
            private set;
        }

        /// <summary>
        /// 邀请人ID
        /// </summary>
        public int InviteUserId
        {
            get;
            private set;
        }

        /// <summary>
        /// 授权的应用的ID
        /// </summary>
        public int AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否接受授权
        /// </summary>
        public bool IsAccept
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get; private set;
        }

        public override bool Validate()
        {
            return new UserRelationValidate().IsSatisfy(this);
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new UserRelationBrokenRuleMessage();
        }
    }
}
