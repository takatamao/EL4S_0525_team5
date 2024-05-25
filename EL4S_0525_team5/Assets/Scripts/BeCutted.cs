using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BeCutted : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    UnityEngine.Color color;
    float counter = 0.0f;
   [SerializeField] float duration = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = GetComponent<SpriteRenderer>().color;
        Invoke("DestorySelf", duration);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        //Fade from 1 to 0
        float alpha = Mathf.Lerp(1, 0, counter/ duration);
        spriteRenderer.color = new UnityEngine.Color(color.r, color.g, color.b,alpha ); 
    }

    private void DestorySelf()
    {

        Destroy(gameObject);
    }
}
