using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count;
    public float speedRate;
    GameObject a;
    
    
    // Start is called before the first frame update
    void Start()
    {
        count = transform.childCount;
        a = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedRate * Time.deltaTime * -1f, 0, 0);
        if (a.GetComponent<PlayerMoving>().isdie == true)
        {
            speedRate = 0;
        }
    }
}
