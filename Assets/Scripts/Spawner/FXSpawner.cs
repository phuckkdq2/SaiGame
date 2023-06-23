using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner // thừa kế từ Spawner
{
    private static FXSpawner instance;                      // singleton
    public static FXSpawner Instance { get => instance; }

    public static string smokeOne = "Smoke_1";  // 
    public static string impactOne = "Impact_1";  // 

    protected override void Awake() 
    {
        base.Awake();
        FXSpawner.instance = this;
    }
}
