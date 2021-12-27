using Abp.Application.Services.Dto;

namespace Experts.First_Project.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}