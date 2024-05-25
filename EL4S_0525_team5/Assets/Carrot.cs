using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collider2D collision)
    {
        //“–‚½‚Á‚½‚Ì‰‰o
        Debug.Log("ok");
    }
}
