using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionControl : AnimController
{
    void Start()
    {
        Initializor();
        // agentVel = agent.ve
        // minDistance = agent.stoppingDistance;
        //animator.SetBool("jump", true);
        //
        // animator.SetBool("jump", false);
        //agent.stoppingDistance = 1.5f;
        //  agent.updateRotation = true;

        //   agent.SetDestination(target.transform.position);
        //agent.Move(target.transform.position);






        AnimInitilazor();

    }

    void Update()
    {
        //if(animator.GetBool(AnimatorHashId.hit1hashid))
        //Debug.Log(animator.GetBool(AnimatorHashId.hit1hashid) + "hit1 aldý");

        Death();

        //animator.SetBool("punch1", !(healthbarcontroller.currentHealth <= 0) );
        //animator.SetBool("punch2", !(healthbarcontroller.currentHealth <= 0) );
        //animator.SetBool("block", !(healthbarcontroller.currentHealth <= 0) );
        //animator.SetBool("punch1", !(healthbarcontroller.currentHealth <= 0) );
        //(healthbarcontroller.currentHealth <= 0) ? Debug.Log("öldü") : Debug.Log("yaþýyo");
        //animator.SetFloat("health", healthbarcontroller.currentHealth);




        Vector3 tarVec;
        float distance;
        WalkInit(out tarVec, out distance);
        //if (startBlockTime > 0)
        //    startBlockTime -= Time.deltaTime;
        BlockWait();

        //if (startBlockTime<=0)
        //    animator.SetBool("block", false);

        //if (punchWaitTime <= 0)
        //{

        //    //if(comboControl1)
        //    //    comboControl1 = false;

        //    if (animator.GetBool("punch1"))
        //    {
        //        animator.SetBool("punch1", false);
        //    }

        //    if (animator.GetBool("punch2"))
        //    {
        //        animator.SetBool("punch2", false);
        //    }

        //    if (animator.GetBool("combo"))
        //    {
        //        animator.SetBool("combo", false);
        //    }

        //    if (animator.GetBool("combo2"))
        //    {
        //        animator.SetBool("combo2", false);
        //    }


        //}


        SetAnims();

        //animator.SetBool("punch1", false);
        //animator.SetBool("punch2", false);
        //animator.SetBool("combo", false);
        //animator.SetBool("combo2", false);
        //Debug.Log("blockc:"+ blockController);
        ////if(distance<15)
        ////     Debug.Log("distance:" +distance);
        ///

        FightMecanic(distance,false);

        FaceTarget(tarVec);

        //if (animator.GetFloat("distance") > agent.stoppingDistance)
        //{
        //    //  agent.velocity 
        //    if (!animator.GetBool("punch1") && !animator.GetBool("block") && !animator.GetBool("punch2") && !animator.GetBool("combo") && !animator.GetBool("combo2"))
        //    {
        //        animator.SetFloat("walkSpeed", 1);
        //        //agent.SetDestination(target.transform.position);

        //    }
        //}
        //else
        //{
        ////    Debug.Log("gg");


        //    animator.SetFloat("walkSpeed", 0);
        //    if (blocking.blockController && UnityEngine.Random.value > 0.4f && blockWaitTime <= 0)
        //    {
        //      animator.SetBool("block", true);

        //    }
        //    if (!animator.GetBool("block"))
        //    {
        //        if (punchWaitTime <= 0)
        //        {
        //            if (UnityEngine.Random.value < 0.8f)
        //            {
        //                if (comboControl1)
        //                {
        //                    animator.SetBool("punch2", false);
        //                    animator.SetBool("combo2", false);
        //                    animator.SetBool("punch1", false);
        //                    animator.SetBool("combo", true);
        //                    comboControl1 = false;
        //                }
        //                if (UnityEngine.Random.value < 0.5f)
        //                {
        //                    animator.SetBool("punch1", false);
        //                    animator.SetBool("combo", false);
        //                    animator.SetBool("combo2", false);
        //                    animator.SetBool("punch2", true);
        //                    if (UnityEngine.Random.value < 0.35f && !comboControl1)
        //                    {
        //                        comboControl1 = true;
        //                    }
        //                }
        //                else
        //                {
        //                    animator.SetBool("punch2", false);
        //                    animator.SetBool("combo", false);
        //                    animator.SetBool("combo2", false);
        //                    animator.SetBool("punch1", true);
        //                }
        //            }
        //            else
        //            {
        //                animator.SetBool("punch1", false);
        //                animator.SetBool("punch2", false);
        //                animator.SetBool("combo", false);
        //                animator.SetBool("combo2", true);
        //            }


        //        }
        //    }
        //}


        //if(healthbarcontroller.maxHealth == 0)
        //{
        //    animator.SetFloat("walkSpeed", 1);
        //}


    }

    void OnCollisionEnter(Collision collision)
    {
        CollisionControl(collision);
        //if (Time.time < 100)
        //    return;
        //    popup.SetActive(false);

        //text.text = ("Hit!!");
        //GameObject starttext = Instantiate(text.transform.gameObject, transform.position, Quaternion.identity);
        //Destroy(starttext, 100);





    }

}
