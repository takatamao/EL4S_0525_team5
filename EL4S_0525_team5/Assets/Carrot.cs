using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collision collision)
    {
        //“–‚½‚Á‚½‚Ì‰‰o
        Instantiate(_objectFragment);
        Destroy(this.gameObject);
    }
}
