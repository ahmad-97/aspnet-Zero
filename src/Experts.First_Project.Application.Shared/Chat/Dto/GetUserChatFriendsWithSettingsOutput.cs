using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using Experts.First_Project.Friendships.Dto;

namespace Experts.First_Project.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }
        
        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}