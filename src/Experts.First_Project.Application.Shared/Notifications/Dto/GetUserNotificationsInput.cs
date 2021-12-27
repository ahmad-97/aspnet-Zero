using System;
using Abp.Notifications;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}