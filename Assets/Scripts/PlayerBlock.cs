using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField]
    private Transform[] controllers = new Transform[2];

    [SerializeField]
    private Transform playerpos;


    private PlayerHealth playerHealth;


    [SerializeField]
    private float maxhanddistanceval;

    private float startplayerblock;

    private bool isinBlock = false;
    private bool blockbool;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        
    }


    private void BlockingStance()
    {
        Vector3 handmidpoint = Vector3.Lerp(controllers[0].position, controllers[1].position, 0.5f);

        float handplayerdistance = Vector3.Distance(playerpos.position, handmidpoint);
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        Debug.LogError(handplayerdistance);
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && handplayerdistance<maxhanddistanceval)
        {
            playerHealth.blockmultiplier = 10/ (Time.time-startplayerblock+Mathf.Epsilon);

            Debug.Log("player blocked");

        }
        else
        {
            playerHealth.blockmultiplier = 1;
            blockbool = false;
            isinBlock = false;

        }



    }




    // Update is called once per frame
    void Update()
    {
        if (isinBlock && !blockbool)
        {
            startplayerblock = Time.time;
            blockbool = true;


        }






        BlockingStance();






    }
}
