namespace Experts.First_Project.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}