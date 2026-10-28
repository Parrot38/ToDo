namespace AvaloniaApplication2.ViewModels;
using Avalonia.Threading;
using System;

public partial class Commisar : AbstractAvatar
{
    MainViewModel viewModel;
    public Commisar(AvatarBehaveourHandler _handler, MainViewModel _viewModel) : base(_handler)
    {
        viewModel = _viewModel;
    }

    public override void Emote1()
    {
        if (!viewModel.emoteStarted)
        {
        viewModel.AddTaskAlert = "Вперёд собаки, к победе!";
        viewModel.emoteStarted = true;
        DispatcherTimer.RunOnce(() => viewModel.ClearDialgueField(), TimeSpan.FromSeconds(2f));
        }
    }

    public override void Enter()
    {
        viewModel.Assistant = viewModel.aPictures[2];
    }
}