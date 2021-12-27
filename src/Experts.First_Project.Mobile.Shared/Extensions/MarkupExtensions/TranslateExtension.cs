using System;
using Experts.First_Project.Core;
using Experts.First_Project.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Experts.First_Project.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return Text;
            }

            return L.Localize(Text);
        }
    }
}