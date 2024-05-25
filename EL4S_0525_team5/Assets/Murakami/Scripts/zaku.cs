using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class zaku : MonoBehaviour
{
    [SerializeField]
    private float _finishTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, _finishTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
