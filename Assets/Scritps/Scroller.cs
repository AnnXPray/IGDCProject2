using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count;
    public float speedRate;
    // Start is called before the first frame update
    void Start()
    {
        count = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedRate * Time.deltaTime * -1f, 0, 0);
    }
}
