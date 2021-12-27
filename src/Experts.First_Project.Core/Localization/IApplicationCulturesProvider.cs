using System.Globalization;

namespace Experts.First_Project.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}