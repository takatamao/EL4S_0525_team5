using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collider2D collision)
    {
        //“–‚½‚Á‚½Žž‚Ì‰‰o
        Instantiate(_objectFragment);
        Destroy(this.gameObject);
    }
}
