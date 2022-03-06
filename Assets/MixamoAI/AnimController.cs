using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimController : MonoBehaviour
{
    NavMeshAgent agent;
    public TextMesh text;
    [SerializeField] GameObject target;
    [SerializeField] CapsuleCollider glove1;
    [SerializeField] CapsuleCollider glove2;
    [SerializeField] GameObject popup;
  //  [SerializeField] float minDistance;
    Animator animator;
    Rigidbody rb;
    float startBlockTime=0;
    float blockWaitTime=0;
    Vector3 agentVel;
    bool blockController = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
       // agentVel = agent.ve
       // minDistance = agent.stoppingDistance;
        //animator.SetBool("jump", true);
        //
        // animator.SetBool("jump", false);
        //agent.stoppingDistance = 1.5f;
      //  agent.updateRotation = true;

     //   agent.SetDestination(target.transform.position);
        //agent.Move(target.transform.position);
    }

    void Update()
    {
        Vector3 tarVec = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        Vector3 agentVec = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        float distance = Vector3.Magnitude(agentVec-tarVec);
        if (startBlockTime > 0)
            startBlockTime -= Time.deltaTime;
        if (blockWaitTime > 0)
            blockWaitTime -= Time.deltaTime;

        if(startBlockTime<=0)
            animator.SetBool("block", false);

        animator.SetBool("punch", false);
        Debug.Log("blockc:"+ blockController);
        ////if(distance<15)
        ////     Debug.Log("distance:" +distance);

      
        if (distance> agent.stoppingDistance)
        {
          //  agent.velocity 
            if (!animator.GetBool("punch") && !animator.GetBool("block"))
            {
                animator.SetFloat("walkSpeed", 1);
                agent.SetDestination(target.transform.position);
                
            }
        }
        else
        {
            Debug.Log("gg");
        
            agent.velocity = Vector3.zero;
            animator.SetFloat("walkSpeed", 0);
            if (blockController && Random.value >0.5f && blockWaitTime<=0)
            {
                animator.SetBool("block",true);
                startBlockTime = 2;
                blockWaitTime = 7;
                blockController = false;
            }
            if(!animator.GetBool("block"))
            {
                animator.SetBool("punch", true);
            }
        }

    }



    //    // Update is called once per frame
    //    void Update()
    //{

    //    if (Time.time < 2)
    //        return;
    //    Debug.Log(target.transform.position);


    //    // transform.LookAt(target);
     
    //    animator.SetBool("punch", false);


    //    if (startBlockTime > 0)
    //    {
    //        //animator.SetFloat("walkSpeed", 0);
    //        animator.SetBool("block", false);
    //        startBlockTime -= Time.deltaTime;
    //    }
    //    if (Time.time>1)
    //    {
    //        animator.SetBool("jump", false);
    //    }

    //    if (Vector3.Distance(this.transform.position, target.transform.position) > agent.stoppingDistance && !animator.GetBool("punch") && !animator.GetBool("block"))
    //    {
            
    //        animator.SetFloat("walkSpeed", 1);
    //       // agent.ResetPath();
    //        agent.SetDestination(target.transform.position);
    //       // agent.Move(target.transform.position);
    //    }
    //    else
    //    {
            
    //       // animator.SetFloat("walkSpeed", 0);
    //        if (startBlockTime <= 0)
    //        {
    //            if (Random.value < 0.5f)
    //            {
    //                animator.SetBool("punch", true);
                    
    //            }
    //            else
    //            {
    //                startBlockTime = 2;
    //                animator.SetBool("block", true);
    //            }
    //            animator.SetFloat("walkSpeed", 1);

    //        }
    //    }

    //    if (Vector3.Distance(this.transform.position, target.transform.position) < agent.stoppingDistance)
    //    {

    //        animator.SetFloat("walkSpeed", 0);
    //        agent.ResetPath();
    //        agent.destination = target.transform.position;
    //        agent.Move(target.transform.position);

    //    }






    //}

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Glove"))
        {

            blockController = true;
            Debug.Log("vuruþ");
            popup.SetActive(true);
           // rb.AddForce(-(3f * transform.forward), ForceMode.Impulse);
          //  animator.SetFloat("walkSpeed", 0);
           // agent.stoppingDistance = 1f;
            //////Debug.Log(agent.stoppingDistance);
            //////Debug.Log(this.transform.position + "," + target.transform.position);
            


        }
        //if (Time.time < 100)
        //    return;
        //    popup.SetActive(false);

        //text.text = ("Hit!!");
        //GameObject starttext = Instantiate(text.transform.gameObject, transform.position, Quaternion.identity);
        //Destroy(starttext, 100);




    }
}
