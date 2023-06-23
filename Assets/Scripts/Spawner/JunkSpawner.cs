using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance; // singleton
    public static JunkSpawner Instance { get => instance; }

    public static string meteoriteOne = "Meteorite_1";  // thiên thạch số 1

    protected override void Awake() 
    {
        base.Awake();
        JunkSpawner.instance = this;
    }
}
