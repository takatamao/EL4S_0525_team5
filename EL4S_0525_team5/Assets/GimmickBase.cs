using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    [SerializeField] protected float _speed;

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
