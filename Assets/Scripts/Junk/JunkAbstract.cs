using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : SaiMonoBehaviour    // không cho thằng nào dùng lớp này , chỉ cho kế thừa
{
    [SerializeField] protected JunkCtrl junkCtrl;       // biến hứng component JunkCtrl

    public JunkCtrl JunkCtrl { get => junkCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();            // load thằng script(component) JunkCtrl
    }

    protected virtual void LoadJunkCtrl()
    {
        if(this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + "LoadJunkCtrl", gameObject);
    }
}
