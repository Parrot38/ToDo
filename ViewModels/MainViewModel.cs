using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication2.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private List<Bitmap> aPictures = new();
    private bool emoteStarted = false;

    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
    [ObservableProperty]
    public Bitmap assistant = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/Assistant.png")));

    [RelayCommand]
    public void SetEmoteO()
    {
        if (!emoteStarted)
        {
        Assistant = aPictures[1];
        emoteStarted = true;
        DispatcherTimer.RunOnce(() => SetPicture(), TimeSpan.FromSeconds(0.8f));
        }
    }
    private void SetPicture()
    {
        Assistant = aPictures[0];
        emoteStarted = false;
    }

    public void InitPictures()
    {
        aPictures.Add(new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/Assistant.png"))));
        aPictures.Add(new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/AssistantO.png"))));
    }
}