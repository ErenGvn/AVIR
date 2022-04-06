using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class AnimController : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    public TextMesh text;
    public GameObject target;
    [SerializeField] CapsuleCollider glove1;
    [SerializeField] CapsuleCollider glove2;
    [SerializeField] GameObject popup;
  //[SerializeField] float minDistance;
    Animator animator;
    Rigidbody rb;
    //float startBlockTime=0;
    float blockWaitTime = 0;
    [HideInInspector] public float punchWaitTime = 0;
    [HideInInspector] public bool comboControl1 = false;
    Vector3 agentVel;
   // private bool blockController = false;
   // [HideInInspector] public bool isBlock = false;

    private Health healthbarcontroller;
    private Blocking blocking;
    public SphereCollider rightcollider;
    public SphereCollider leftcollider;




    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        blocking = animator.GetBehaviour<Blocking>();
       // agentVel = agent.ve
       // minDistance = agent.stoppingDistance;
        //animator.SetBool("jump", true);
        //
        // animator.SetBool("jump", false);
        //agent.stoppingDistance = 1.5f;
      //  agent.updateRotation = true;

     //   agent.SetDestination(target.transform.position);
        //agent.Move(target.transform.position);
        healthbarcontroller = gameObject.GetComponent<Health>();


    }

    void Update()
    {
        if (healthbarcontroller.currentHealth <= 0)
        {
            animator.SetBool("punch1", false);
            animator.SetBool("punch2", false);
            animator.SetBool("block", false);
            animator.SetBool("punch1", false);
            Debug.Log("öldü");
            animator.SetFloat("health", healthbarcontroller.currentHealth);
        }

     


        Vector3 tarVec = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        Vector3 agentVec = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        float distance = Vector3.Magnitude(agentVec-tarVec);
        //if (startBlockTime > 0)
        //    startBlockTime -= Time.deltaTime;
        if (blockWaitTime > 0)
            blockWaitTime -= Time.deltaTime;
        if (punchWaitTime > 0)
            punchWaitTime -= Time.deltaTime;

        //if (startBlockTime<=0)
        //    animator.SetBool("block", false);

        if (punchWaitTime <= 0)
        {

            //if(comboControl1)
            //    comboControl1 = false;

            if (animator.GetBool("punch1"))
            {
                animator.SetBool("punch1", false);
            }

            if (animator.GetBool("punch2"))
            {
                animator.SetBool("punch2", false);
            }

            if (animator.GetBool("combo"))
            {
                animator.SetBool("combo", false);
            }

            if (animator.GetBool("combo2"))
            {
                animator.SetBool("combo2", false);
            }


        }

        //animator.SetBool("punch1", false);
        //animator.SetBool("punch2", false);
        //animator.SetBool("combo", false);
        animator.SetBool("combo2", false);
        //Debug.Log("blockc:"+ blockController);
        ////if(distance<15)
        ////     Debug.Log("distance:" +distance);

        animator.SetFloat("distance", distance);

        if (animator.GetFloat("distance") > agent.stoppingDistance)
        {
            //  agent.velocity 
            if (!animator.GetBool("punch1") && !animator.GetBool("block") && !animator.GetBool("punch2") && !animator.GetBool("combo") && !animator.GetBool("combo2"))
            {
                animator.SetFloat("walkSpeed", 1);
                //agent.SetDestination(target.transform.position);

            }
        }
        else
        {
        //    Debug.Log("gg");
        
         
            animator.SetFloat("walkSpeed", 0);
            if (blocking.blockController && UnityEngine.Random.value > 0.4f && blockWaitTime <= 0)
            {
              animator.SetBool("block", true);
        
            }
            if (!animator.GetBool("block"))
            {
                if (punchWaitTime <= 0)
                {
                    if (UnityEngine.Random.value < 0.8f)
                    {
                        if (comboControl1)
                        {
                            animator.SetBool("punch2", false);
                            animator.SetBool("combo2", false);
                            animator.SetBool("punch1", false);
                            animator.SetBool("combo", true);
                            comboControl1 = false;
                        }
                        if (UnityEngine.Random.value < 0.5f)
                        {
                            animator.SetBool("punch1", false);
                            animator.SetBool("combo", false);
                            animator.SetBool("combo2", false);
                            animator.SetBool("punch2", true);
                            if (UnityEngine.Random.value < 0.35f && !comboControl1)
                            {
                                comboControl1 = true;
                            }
                        }
                        else
                        {
                            animator.SetBool("punch2", false);
                            animator.SetBool("combo", false);
                            animator.SetBool("combo2", false);
                            animator.SetBool("punch1", true);
                        }
                    }
                    else
                    {
                        animator.SetBool("punch1", false);
                        animator.SetBool("punch2", false);
                        animator.SetBool("combo", false);
                        animator.SetBool("combo2", true);
                    }


                }
            }
        }

        FaceTarget(tarVec);
       
        //if(healthbarcontroller.maxHealth == 0)
        //{
        //    animator.SetFloat("walkSpeed", 1);
        //}


    }


    //private void Timer()
    //{
    //    Debug.Log("event works");
    //    if (!comboControl1)
    //        punchWaitTime = 2;
        
    //}

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
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

    //private void BlockEndEvent()
    //{
    //    //if (isBlock)
    //    //    isBlock = false;
    //}


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Glove1") && !blocking.blockController)
        {

            blockWaitTime = 7;
            blocking.blockController = true;
           
            
            //if (!collision.transform.CompareTag("Enemy"))
            //{

            //  //  Debug.Log(collision.transform.CompareTag("Glove1"));
            //    animator.SetBool("hit1", true);
            //    healthbarcontroller.ModifyHealth(-15);
            //    //animator.SetBool("hit1", false);


            //}
            


            // rb.AddForce(-(3f * transform.forward), ForceMode.Impulse);
            //  animator.SetFloat("walkSpeed", 0);
            // agent.stoppingDistance = 1f;
            //////Debug.Log(agent.stoppingDistance);
            //////Debug.Log(this.transform.position + "," + target.transform.position);



        }
        

        if (collision.transform.CompareTag("Glove2") && !blocking.blockController)
        {



            blocking.blockController = true;
           

            //if (!collision.transform.CompareTag("Enemy"))
            //{
            //    healthbarcontroller.ModifyHealth(-10);

            //    animator.SetBool("hit2", true);
            //    //animator.SetBool("hit2", false);


            //}



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
