using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;             // tạo biến chứa component JunkSpawner
    public JunkSpawner JunkSpawner { get => junkSpawner;}

    [SerializeField] protected JunkSpawnPoint spawnPoints;          // tạo biến chứa obj JunkSpawnPoint
    public JunkSpawnPoint SpawnPoints { get => spawnPoints;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpaner();          // auto load script JunkSpawner
        this.LoadSpawnPoints();         // auto load obj JunkSpawnPoint
    }

    protected virtual void LoadJunkSpaner()  
    {
        if(this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();      // gán thằng script JunkSpawner vào
    }

     protected virtual void LoadSpawnPoints()
   {
          if(this.spawnPoints != null) return;
          this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoint>();     // gán thằng obj JunkSpawnPoint vào
          Debug.Log(transform.name + " : loadSpawnPoints", gameObject);
   }
}
