using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start() {
        //For override
    }

    protected virtual void Awake() {
        this.LoadComponents(); // gọi thằng này đầu tiên
    }
    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }

    protected virtual void OnEnable() {
        
    }

}
