using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner // thừa kế từ Spawner
{
    private static BulletSpawner instance;                      // singleton
    public static BulletSpawner Instance { get => instance; }

    public static string bulletOne = "Bullet_1";  // viên đạn số 1

    protected override void Awake() 
    {
        base.Awake();
        BulletSpawner.instance = this;
    }
}
