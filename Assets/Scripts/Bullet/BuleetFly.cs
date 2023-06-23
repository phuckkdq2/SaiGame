using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuleetFly : ParentFly
{
    protected override void ResetValue() // ghi đè thằng ông nội SaiMonobehaviors
    {
        base.ResetValue();
        moveSpeed = 9 ;
    }
}
