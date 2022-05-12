using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToHead : MonoBehaviour
{

    [SerializeField] private GameObject particle;
    private float waittime;
   


    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
      
        if(waittime <= 0)
        {
            transform.GetComponent<SphereCollider>().enabled = true;
        }

        waittime -= Time.deltaTime;
      
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.transform.CompareTag("Glove1") || collision.transform.CompareTag("Glove2")) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit1hashid) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit2hashid))
        {


            Vector3 contact = transform.GetComponent<SphereCollider>().ClosestPointOnBounds(collision.transform.position);
            GameObject particleObject = Instantiate(particle, contact, Quaternion.identity);

            transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit1hashid, true);
            transform.GetComponent<SphereCollider>().enabled = false;
            waittime = 2f;


            transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit2hashid, false);
            Destroy(particleObject, 2);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if ((collision.transform.CompareTag("Glove1") || collision.transform.CompareTag("Glove2")) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit1hashid) && !transform.root.GetComponent<Animator>().GetBool(AnimatorHashId.hit2hashid))
    //   {
    //        if (collision.relativeVelocity.magnitude*1000 < 1)
    //            return;


    //            Vector3 contact = transform.GetComponent<SphereCollider>().ClosestPointOnBounds(collision.transform.position);
    //            GameObject particleObject = Instantiate(particle, contact, Quaternion.identity);

    //            transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit1hashid, true);
    //            transform.GetComponent<SphereCollider>().enabled = false;
    //            waittime = 2f;


    //            transform.root.GetComponent<Animator>().SetBool(AnimatorHashId.hit2hashid, false);
    //            Destroy(particleObject, 2);


    //    }
    //}


}
