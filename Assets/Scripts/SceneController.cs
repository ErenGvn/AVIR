using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject damagePopUp;

    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(damagePopUp, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        //damagePopUp.transform.LookAt(cam.transform.position);
        

    }

   
}
