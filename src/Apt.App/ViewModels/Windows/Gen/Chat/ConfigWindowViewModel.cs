﻿using Apt.Core.Utility;
using Apt.Service.Utility;
using Apt.Service.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui;

namespace Apt.App.ViewModels.Windows.Gen.Chat
{
    public partial class ConfigWindowViewModel : BaseViewModel
    {
        private bool _isInitialized = false;

        public Action CloseAction { get; set; } = null!;

        [ObservableProperty]
        private string _promptSystem = null!;

        [ObservableProperty]
        private int _promptMaxLength;

        [ObservableProperty]
        private int _contextMaxLength;

        [RelayCommand]
        private async Task SetSave()
        {
            Current.Config.GenChat.PromptSystem = PromptSystem;
            Current.Config.GenChat.PromptMaxLength = PromptMaxLength;
            Current.Config.GenChat.ContextMaxLength = ContextMaxLength;
            ServiceProvider.GetRequiredService<Pages.Gen.Chat.IndexPageViewModel>().PromptMaxLength = Current.Config.GenChat.PromptMaxLength;
            await Message.ShowMessageInfo(Language.Instance["Gen.Chat.ConfigSaveSuccess"]);
            CloseAction?.Invoke();
        }

        [RelayCommand]
        private void SetClose()
        {
            CloseAction?.Invoke();
        }

        public ConfigWindowViewModel(
            IServiceProvider serviceProvider,
            ISnackbarService snackbarService) :
            base(serviceProvider, snackbarService)
        {
            if (!_isInitialized) InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }
    }
}
