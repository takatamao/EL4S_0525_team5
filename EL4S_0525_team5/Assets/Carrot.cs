using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collider2D collision)
    {
        //当たった時の演出
        Debug.Log("ok");
    }
}
