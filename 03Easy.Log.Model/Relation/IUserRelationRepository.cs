﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;

namespace Easy.Log.Model.Relation
{
    public interface IUserRelationRepository: IRepository<UserRelation, int>
    {
        UserRelation FindBy(int userId,int inviteUserId);
        IList<UserRelation> FindInviteAll(int inviteUserId, int appId,int userId);

        IList<UserRelation> FindPendingInvite(int inviteUserId);
    }
}
