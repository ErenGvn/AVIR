using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celeb : MonoBehaviour
{
    Animation yourAnimation1;

    void Awake()
    {
        yourAnimation1 = this.GetComponent<Animation>();

    }

    // This is an example only

    private void Update()
    {
        yourAnimation1.Play("celebration");
    }



}
