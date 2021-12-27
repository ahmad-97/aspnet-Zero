﻿using System;
using Experts.First_Project.Core;
using Experts.First_Project.Core.Dependency;
using Experts.First_Project.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Experts.First_Project.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}