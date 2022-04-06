using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToHead : MonoBehaviour
{
   


    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
      

      
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Glove1") || collision.transform.CompareTag("Glove2"))
        {

            transform.root.GetComponent<Animator>().SetBool("hit1", true);
        }
    }




}
