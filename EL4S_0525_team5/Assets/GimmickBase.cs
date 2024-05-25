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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) OnHitKnifeEnter(collision);
    }

    protected virtual void OnHitKnifeEnter(Collision collision) { }
}
