﻿namespace Experts.First_Project.Configuration
{
    public class NullExternalLoginOptionsCacheManager : IExternalLoginOptionsCacheManager
    {
        public static NullExternalLoginOptionsCacheManager Instance { get; } = new NullExternalLoginOptionsCacheManager();
        public void ClearCache()
        {
        }
    }
}