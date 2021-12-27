﻿using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Abp.Localization;
using MvvmHelpers;
using Experts.First_Project.ApiClient;
using Experts.First_Project.Authorization.Users.Dto;
using Experts.First_Project.Authorization.Users.Profile;
using Experts.First_Project.Core.Threading;
using Experts.First_Project.Services.Account;
using Experts.First_Project.ViewModels.Base;
using Experts.First_Project.Views;
using Xamarin.Forms;

namespace Experts.First_Project.ViewModels
{
    public class MySettingsViewModel : XamarinViewModel
    {
        public ICommand LogoutCommand => AsyncCommand.Create(_accountService.LogoutAsync);
        public ICommand ChangePasswordCommand => AsyncCommand.Create(ChangePasswordAsync);

        private readonly IAccountService _accountService;
        private readonly IApplicationContext _applicationContext;
        private readonly IProfileAppService _profileAppService;

        private ObservableRangeCollection<LanguageInfo> _languages;
        private LanguageInfo _selectedLanguage;
        private bool _isInitialized;

        public MySettingsViewModel(
            IApplicationContext applicationContext,
            IProfileAppService profileAppService,
            IAccountService accountService)
        {
            _applicationContext = applicationContext;
            _profileAppService = profileAppService;
            _accountService = accountService;
            _languages = new ObservableRangeCollection<LanguageInfo>(_applicationContext.Configuration.Localization.Languages);
            _selectedLanguage = _languages.FirstOrDefault(l => l.Name == _applicationContext.CurrentLanguage.Name);
            _isInitialized = false;
        }

        public override Task InitializeAsync(object navigationData)
        {
            _isInitialized = true;

            return Task.CompletedTask;
        }

        public ObservableRangeCollection<LanguageInfo> Languages
        {
            get => _languages;
            set
            {
                _languages = value;
                RaisePropertyChanged(() => Languages);
            }
        }

        public LanguageInfo SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                RaisePropertyChanged(() => SelectedLanguage);

                if (_isInitialized)
                {
                    AsyncRunner.Run(ChangeLanguage());
                }
            }
        }

        private async Task ChangeLanguage()
        {
            _applicationContext.CurrentLanguage = _selectedLanguage;

            await WebRequestExecuter.Execute(
                async () =>
                    await _profileAppService.ChangeLanguage(new ChangeUserLanguageDto
                    {
                        LanguageName = _selectedLanguage.Name
                    }),
                async () =>
                    await UserConfigurationManager.GetAsync(async () =>
                    {
                        MessagingCenter.Send(this, MessagingCenterKeys.LanguagesChanged);
                        await NavigationService.SetDetailPageAsync(typeof(MySettingsView));
                    }));
        }

        private async Task ChangePasswordAsync()
        {
            await NavigationService.SetMainPage<ChangePasswordView>();
        }
    }
}
