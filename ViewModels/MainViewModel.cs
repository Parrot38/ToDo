using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication2.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private AvatarBehaveourHandler avatarHandler = new AvatarBehaveourHandler();
    public List<Bitmap> aPictures = new();
    public bool emoteStarted = false;

    [ObservableProperty]
    private string addTaskAlert = "";
    [ObservableProperty]
    public Bitmap assistant = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/Commissar.webp")));

    [RelayCommand]
    public void SetEmoteO()
    {
        avatarHandler.Emote();
    }
    [RelayCommand] 
    public void SetCurrentAvatar(int avatarIndex)
    {
        avatarHandler.SetAvatar(avatarIndex);
    }
    public void SetPicture()
    {
        Assistant = aPictures[0];
        AddTaskAlert = "";
        emoteStarted = false;
    }
    public void ClearDialgueField()
    {
        AddTaskAlert = "";
        emoteStarted = false;
    }

    public void InitPictures()
    {
        aPictures.Add(new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/Assistant.png"))));
        aPictures.Add(new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/AssistantO.png"))));
        aPictures.Add(new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication2/Assets/Commissar.webp"))));
    }
    public void InitAvatars()
    {
        avatarHandler.AddAvatar(new Assistant(avatarHandler,this));
        avatarHandler.AddAvatar(new Commisar(avatarHandler,this));
        avatarHandler.SetAvatar(0);
    }
}