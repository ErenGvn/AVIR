using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRMenuController : MonoBehaviour
{

    public bool m_controller;
    public LineRenderer line;
    Vector3[] linesPos;
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
        linesPos = new Vector3[2];
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;


        linesPos[0] = transform.position;

        linesPos[1] = transform.forward*1000;



        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {

                Debug.Log("pressed");
                hit.transform.GetComponent<Button>().onClick.Invoke();
            }


            if (hit.transform.CompareTag("UI") && hit.transform.GetComponent<Button>()!=null)
            {
                Debug.Log("deðdi");
                linesPos[1] = hit.point;
               


            }
           
        }

        line.SetPositions(linesPos);
    }
}
