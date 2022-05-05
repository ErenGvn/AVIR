using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;


public class AnimController : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    public float pwtime;
    public GameObject target;
    [SerializeField] CapsuleCollider glove1;
    [SerializeField] CapsuleCollider glove2;

  //[SerializeField] float minDistance;
    protected Animator animator;
    Rigidbody rb;
    //float startBlockTime=0;
    float blockWaitTime = 0;
    [HideInInspector] public float punchWaitTime = 0;
    [HideInInspector] public bool comboControl1 = false;
    Vector3 agentVel;
   // private bool blockController = false;
   // [HideInInspector] public bool isBlock = false;

    protected Health healthbarcontroller;
    private Blocking blocking;
    public SphereCollider rightcollider;
    public SphereCollider leftcollider;



    // Start is called before the first frame update


    protected virtual void AnimInitilazor()
    {
        animator.SetBool(AnimatorHashId.punch1hasid, false);
        animator.SetBool(AnimatorHashId.punch2hasid, false);
        animator.SetBool(AnimatorHashId.blockhashid, false);
        animator.SetBool(AnimatorHashId.combo2hashid, false);
        animator.SetBool(AnimatorHashId.combohasid, false);
        animator.SetBool(AnimatorHashId.hit1hashid, false);
        animator.SetBool(AnimatorHashId.hit2hashid, false);
        animator.SetBool(AnimatorHashId.walkinghasid, false);
        animator.SetBool(AnimatorHashId.dyinghashid, false);
    }

    protected void Initializor()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        blocking = animator.GetBehaviour<Blocking>();
        healthbarcontroller = gameObject.GetComponent<Health>();
    }



    protected virtual void FightMecanic(float distance, bool ulti)
    {
        if (!ulti)
        {
            bool attackcontroller = !(animator.GetFloat(AnimatorHashId.distancehashid) > agent.stoppingDistance) && (!animator.GetBool(AnimatorHashId.blockhashid)) && (punchWaitTime <= 0);

            animator.SetFloat(AnimatorHashId.distancehashid, distance);
            animator.SetFloat(AnimatorHashId.walkspeedhasid, (animator.GetFloat(AnimatorHashId.distancehashid) > agent.stoppingDistance) /* && (!animator.GetBool("punch1") && !animator.GetBool("block") && !animator.GetBool("punch2") && !animator.GetBool("combo") && !animator.GetBool("combo2")) */? 1 : 0);
            animator.SetBool(AnimatorHashId.blockhashid, !(animator.GetFloat(AnimatorHashId.distancehashid) > agent.stoppingDistance) && (blocking.blockController && UnityEngine.Random.value > 0.4f && blockWaitTime <= 0) ? true : false);
            animator.SetBool(AnimatorHashId.punch2hasid, attackcontroller && (UnityEngine.Random.value < 0.8f) && (UnityEngine.Random.value < 0.5f) ? true : false);
            animator.SetBool(AnimatorHashId.combo2hashid, attackcontroller && (UnityEngine.Random.value >= 0.8f) ? true : false);
            animator.SetBool(AnimatorHashId.punch1hasid, attackcontroller && (UnityEngine.Random.value < 0.8f) && (UnityEngine.Random.value >= 0.5f) ? true : false);
            animator.SetBool(AnimatorHashId.combohasid, attackcontroller && (UnityEngine.Random.value < 0.8f) && comboControl1 ? true : false);
            comboControl1 = !(attackcontroller && (UnityEngine.Random.value < 0.8f) && comboControl1);
        }
    }

    protected virtual void SetAnims()
    {
        animator.SetBool(AnimatorHashId.punch1hasid, !((punchWaitTime <= 0) && (animator.GetBool(AnimatorHashId.punch1hasid))));
        animator.SetBool(AnimatorHashId.punch2hasid, !((punchWaitTime <= 0) && (animator.GetBool(AnimatorHashId.punch2hasid))));
        animator.SetBool(AnimatorHashId.combohasid, !((punchWaitTime <= 0) && (animator.GetBool(AnimatorHashId.combohasid))));
        animator.SetBool(AnimatorHashId.combo2hashid, !((punchWaitTime <= 0) && (animator.GetBool(AnimatorHashId.combo2hashid))));
    }

    protected void BlockWait()
    {
        if (blockWaitTime > 0)
            blockWaitTime -= Time.deltaTime;
        if (punchWaitTime > 0)
            punchWaitTime -= Time.deltaTime;
    }

    protected void WalkInit(out Vector3 tarVec, out float distance)
    {
     
        tarVec = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        Vector3 agentVec = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        distance = Vector3.Magnitude(agentVec - tarVec);
    }

    protected void Death()
    {
        if (healthbarcontroller.currentHealth <= 0)
        {
            animator.SetBool(AnimatorHashId.punch1hasid, false);
            animator.SetBool(AnimatorHashId.punch2hasid, false);
            animator.SetBool(AnimatorHashId.blockhashid, false);
            //.SetBool("punch1", false);
            Debug.Log("öldü");
            animator.SetFloat(AnimatorHashId.healthhasid, healthbarcontroller.currentHealth);
        }
    }


    //private void Timer()
    //{
    //    Debug.Log("event works");
    //    if (!comboControl1)
    //        punchWaitTime = 2;

    //}

    protected void FaceTarget(Vector3 destination)
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





    protected void CollisionControl(Collision collision)
    {
        if (collision.transform.CompareTag("Glove1") && !blocking.blockController)
        {
            blockWaitTime = 7;
            blocking.blockController = true;
            #region oldblock

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
            #endregion
        }


        if (collision.transform.CompareTag("Glove2") && !blocking.blockController)
        {
            blockWaitTime = 7;
            blocking.blockController = true;
            #region oldblock
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
            #endregion
        }
    }
}
