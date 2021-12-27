using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptsViewModel
    {
        public List<ComboboxItemDto> LoginAttemptResults { get; set; }
    }
}