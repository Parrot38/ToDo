using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AvaloniaApplication2.ViewModels;
public abstract class AbstractAvatar
{
    protected readonly AvatarBehaveourHandler handler;
    public AbstractAvatar(AvatarBehaveourHandler _handler)
    {
        handler = _handler; 
    }
    public abstract void Enter();
    public abstract void Emote1();
}