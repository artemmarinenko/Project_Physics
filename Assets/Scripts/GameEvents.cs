using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public static event Action OnSphereHeroClick;
    public static event Action OnCatpultClick;
    public static event Action OnMissleLanded;
    public static event Action OnExplosion;

    public static void RaiseOnSphereHeroCkick()
    {
        OnSphereHeroClick?.Invoke();
    }

    public static void RaiseOnCatapultClick()
    {
        OnCatpultClick?.Invoke();
    }
    public static void RaiseOnMissleLanded()
    {
        OnMissleLanded?.Invoke();
    }

    public static void RaiseOnExplosion()
    {
        OnExplosion?.Invoke();
    }




}
