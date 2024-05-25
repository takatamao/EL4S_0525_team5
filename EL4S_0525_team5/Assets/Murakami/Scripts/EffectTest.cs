using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : MonoBehaviour
{
    //[SerializeField]
    //private Animator _anim;

    [SerializeField]
    private float _animTime;

    // Start is called before the first frame update
    void Start()
    {
        //_anim = GetComponent<Animator>();
        //_anim.SetBool("isSlash", true);
        Destroy(this.gameObject, _animTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
