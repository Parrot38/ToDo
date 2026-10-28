using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication2.ViewModels;

public partial class AvatarBehaveourHandler
{
    private AbstractAvatar? currentAvatar{get;set;}

    private List<AbstractAvatar> avatarList = new List<AbstractAvatar>();

    public void SetAvatar(int avatarIndex)
    {
            currentAvatar = avatarList[avatarIndex];
            currentAvatar.Enter();
    }
    public void AddAvatar(AbstractAvatar avatar)
    {
        avatarList.Add(avatar);
    }

    public void Emote()
    {
        currentAvatar?.Emote1();
    }
}