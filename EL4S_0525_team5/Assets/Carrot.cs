using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collision collision)
    {
        //�����������̉��o
        Instantiate(_objectFragment);
        Destroy(this.gameObject);
    }
}
