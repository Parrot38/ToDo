using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication2.ViewModels;

public partial class Assistant : AbstractAvatar
{
    MainViewModel viewModel;
    public Assistant(AvatarBehaveourHandler _handler, MainViewModel _viewModel) : base(_handler)
    {
        viewModel = _viewModel;
    }

    public override void Emote1()
    {
        if (!viewModel.emoteStarted)
        {
        viewModel.AddTaskAlert = "Сегодня будет продуктивный день!";
        viewModel.Assistant = viewModel.aPictures[1];
        viewModel.emoteStarted = true;
        DispatcherTimer.RunOnce(() => viewModel.SetPicture(), TimeSpan.FromSeconds(2f));
        }
    }

    public override void Enter()
    {
        viewModel.Assistant = viewModel.aPictures[0];
    }
}