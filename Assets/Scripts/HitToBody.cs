using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToBody : MonoBehaviour
{
    private float waittime;
    [SerializeField] private GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (waittime <= 0)
        {
            transform.GetComponent<CapsuleCollider>().enabled = true;
        }

        waittime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if ((collision.transform.CompareTag("Glove1") || collision.transform.CompareTag("Glove2")) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit1hashid) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit2hashid))
        {

            Vector3 contact = transform.GetComponent<CapsuleCollider>().ClosestPointOnBounds(collision.transform.position);
            GameObject particleObject = Instantiate(particle, contact, Quaternion.identity);

            transform.parent.GetComponent<Animator>().SetBool(AnimatorHashId.hit2hashid, true);
            //transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit1hashid, false);


            transform.GetComponent<CapsuleCollider>().enabled = false;
            waittime = 2f;
            Destroy(particleObject, 2);
        }
    }



    //private void OnCollisionEnter(Collision collision)
    //{
    //    if ((collision.transform.CompareTag("Glove1") || collision.transform.CompareTag("Glove2")) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit1hashid) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit2hashid))
    //    {






    //        Vector3 contact = transform.GetComponent<CapsuleCollider>().ClosestPointOnBounds(collision.transform.position);
    //        GameObject particleObject = Instantiate(particle, contact, Quaternion.identity);

    //        transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit1hashid, true);
    //        transform.GetComponent<CapsuleCollider>().enabled = false;
    //        waittime = 2f;


    //        transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit2hashid, false);
    //        Destroy(particleObject, 2);


    //    }
    //}



}
