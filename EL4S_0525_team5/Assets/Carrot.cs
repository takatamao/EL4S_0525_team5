using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collision collision)
    {
        //当たった時の演出
        Instantiate(_objectFragment);
        Destroy(this.gameObject);
    }
}
