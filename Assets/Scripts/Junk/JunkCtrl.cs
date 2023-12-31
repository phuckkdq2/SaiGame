using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;     // tạo biến để gán obj Model
    public Transform Model { get => model;}

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO { get => junkSO;}


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel(); 
        this.LoadJunkDespawn();          // auto gắn Model
        this.LoadJunkSo();
    }

    protected virtual void LoadModel() 
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + "LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn() 
    {
        if(this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        // Debug.Log(transform.name + "LoadJunkDespawn", gameObject);
    }

    protected virtual void LoadJunkSo()
    {
        if(this.junkSO != null) return;
        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
        // Debug.LogWarning(transform.name + ": LoadJunkSO" + resPath, gameObject);
    }
}
