using System.Threading.Tasks;

namespace Experts.First_Project.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}