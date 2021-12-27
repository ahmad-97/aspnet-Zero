using Xamarin.Forms.Internals;

namespace Experts.First_Project.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}