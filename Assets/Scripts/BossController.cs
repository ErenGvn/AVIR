using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : AnimController
{
    private bool ulticontroller = false;
    private bool isInUlti = false;
    private float ultBarValue = 0;
    private float ultiDuration = 0;

    [SerializeField] private GameObject particle1;
    [SerializeField] private GameObject particle2;

    [SerializeField]
    private const float ultBarMaxValue=15;

    [SerializeField] private int bossId;

    protected override void AnimInitilazor()
    {
        base.AnimInitilazor();


        ulticontroller = (ultBarValue > ultBarMaxValue);

        animator.SetBool(AnimatorHashId.ultihashid, ulticontroller);

    }

    protected override void FightMecanic(float distance,bool ultiparam)
    {
        //check taunt animation, anim controllerin punchlarýndan örnek alarak
        float tauntratio = (healthbarcontroller.maxHealth - healthbarcontroller.currentHealth) / 300;
        animator.SetBool(AnimatorHashId.taunthashid, (healthbarcontroller.currentHealth<70) && (UnityEngine.Random.value<tauntratio) ? true : false);
        base.FightMecanic(distance, ulticontroller);
        ulticontroller = (ultBarValue > ultBarMaxValue);

        animator.SetBool(AnimatorHashId.ultihashid, ulticontroller);
        ulti();
    }

    protected override void SetAnims()
    {
        base.SetAnims();

        //(animator.SetBool(AnimatorHashId.taunthashid, !((punchWaitTime <= 0) && (animator.GetBool(AnimatorHashId.taunthashid))));
    }





    // set animi override edip taunt ekleyeceksin hashidye taunt ekle ultiye benzer
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
        if (bossId == 1) {
            
            ultiDuration -= Time.deltaTime;

            if (ultiDuration <= 0)
            {
                Boss1_Ulti_End();
            }
        }

        Vector3 tarVec;
        float distance;
        WalkInit(out tarVec, out distance);
        //if (startBlockTime > 0)
        //    startBlockTime -= Time.deltaTime;
        BlockWait();
        ultBarValue += Time.deltaTime * 1;
        //Debug.Log(AnimatorHashId.ultihashid);
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

        FightMecanic(distance,ulticontroller);

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


    private void ulti()
    {
        switch (bossId)
        {
            case 1:
                boss_1_Ulti();
                break;

            case 2:
                break;

            case 3:
                break;

        }
    }

    public void ultControl()
    {
        isInUlti = true;

    }


    public void ultEnd()
    {
        Debug.Log("ult ended");
        isInUlti = false;
        ulticontroller = false;
        ultBarValue = 0;
        

    }

    private void Taunt()
    {
        // if(healthbarcontroller.currentHealth < 100)
    
        healthbarcontroller.ModifyHealth((100.0f / 85.0f * Time.deltaTime));

        //healthbarcontroller.currentHealth += Time.deltaTime * (100.0f / 85.0f);
        //healthbarcontroller.currentHealth =  Mathf.Clamp(healthbarcontroller.currentHealth, 0, 100);
    }

    private void Boss1_Ulti_End()
    {
        animator.speed = 1f;
        particle1.SetActive(false);
        particle2.SetActive(false);
        pwtime = 5;
    }


    private void boss_1_Ulti()
    {
        if (!isInUlti)
            return;

        ultiDuration = 5f;
        particle1.SetActive(true);
        particle2.SetActive(true);

        pwtime = 0;
        animator.speed = 1.5f;
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
