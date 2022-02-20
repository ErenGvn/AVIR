using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {

            text.text = (collision.relativeVelocity.magnitude*1000).ToString();
            text.text.Substring(0, 5);
            GameObject starttext = Instantiate(text.transform.gameObject, transform.position, Quaternion.identity);
            Destroy(starttext, 1);

    }
}
