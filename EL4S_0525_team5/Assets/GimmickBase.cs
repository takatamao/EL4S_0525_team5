using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 5.0f;
    [SerializeField] protected GameObject _objectFragment;

    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-_speed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife")) OnHitKnifeEnter(collision);
    }

    protected virtual void OnHitKnifeEnter(Collider2D collision) { }
}
