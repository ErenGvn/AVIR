using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    public TextMesh text;
    [SerializeField] Rigidbody glove1;
    [SerializeField] Rigidbody glove2;
    //dummy commit
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
        if (collision.collider == glove1 || collision.collider == glove2)
        {

            text.text = ("Hit!!");
            GameObject starttext = Instantiate(text.transform.gameObject, transform.position, Quaternion.identity);
            Destroy(starttext, 100);

        }


    }
}
