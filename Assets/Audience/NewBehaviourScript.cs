using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animation yourAnimation;

    void Awake()
    {
        yourAnimation = this.GetComponent<Animation>();
        
    }

    // This is an example only

    private void Update()
    {
        yourAnimation.Play("applause");
    }



}
