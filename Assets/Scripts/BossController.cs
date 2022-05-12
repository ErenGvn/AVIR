using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossController : AnimController
{
    private bool ulticontroller = false;
    private bool isInUlti = false;
    private float ultBarValue = 0;
    private float ultiDuration = 0;
    private bool startbool = true;

    private bool retreated = false;

    private Vector3 projectile_target;

    [HideInInspector]
    public bool boss2trigger = false;

    [SerializeField] private GameObject particle1;
    [SerializeField] private GameObject particle2;

    [SerializeField]
    private  float ultBarMaxValue=25;

    [SerializeField] private int bossId;
    [SerializeField] private int modeId;

    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject eyeancor;



    [SerializeField] private GameObject[] floors;




    protected override void AnimInitilazor()
    {
        base.AnimInitilazor();


        ulticontroller = (ultBarValue > ultBarMaxValue);

        animator.SetBool(AnimatorHashId.ultihashid, ulticontroller);

    }

    protected override void FightMecanic(float distance,bool ultiparam)
    {

        float tauntratio = (healthbarcontroller.maxHealth - healthbarcontroller.currentHealth) / 600;
        animator.SetBool(AnimatorHashId.taunthashid, (healthbarcontroller.currentHealth<70) && (UnityEngine.Random.value<0.005f) ? true : false);
        base.FightMecanic(distance, ulticontroller);
        ulticontroller = (ultBarValue > ultBarMaxValue);

        animator.SetBool(AnimatorHashId.ultihashid, ulticontroller);

        if (ulticontroller)
        {

            ulti();
            
           
        }
           
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
        panel.SetActive(false);
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

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(8);


        panel.SetActive(true);


        yield return new WaitForSeconds(5);


        if(modeId == 0) // SURVIVAL
        {
            if (bossId == 1)
                SceneManager.LoadScene("SurvivalOffice");
            else if (bossId == 2)
                SceneManager.LoadScene("SurvivalDesert");
            else
                SceneManager.LoadScene("MenuScene");

        }else
            SceneManager.LoadScene("MenuScene");



    }

    private IEnumerator WaitForMovement()
    {

        Debug.Log("waiting");
        yield return new WaitForSeconds(8);

        startbool = false;



    }

    private IEnumerator WaitForReturn()
    {

        Debug.Log("retreating");
        yield return new WaitForSeconds(2);

        retreated = true;



    }



    void Update()
    {
        //if(animator.GetBool(AnimatorHashId.hit1hashid))
        //Debug.Log(animator.GetBool(AnimatorHashId.hit1hashid) + "hit1 aldý");


        Death();

      
            if (healthbarcontroller.currentHealth <= 0)
            {

                StartCoroutine(WaitForSceneLoad());
                
            }

        //Debug.Log(punchWaitTime);



        //if (healthbarcontroller.currentHealth <= 25 && retreated == false)
        //{
        //    Retreat();
        //    StartCoroutine(WaitForReturn());
            
        //}
            


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

        if (startbool == false)
            FightMecanic(distance, ulticontroller);
        else
            StartCoroutine(WaitForMovement());
        




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


    //private void FixedUpdate()
    //{

    //    if (bossId == 2 && boss2trigger)
    //    {
    //        for (int i = 0; i < 4; i++)
    //        {
    //            Vector3 projectile_dir = (target.transform.position - floors[i].transform.position).normalized;

    //            LeanTween.cancelAll();


    //            floors[i].GetComponent<Rigidbody>().AddForce(projectile_dir * 2000);


    //        }
    //    }




    //}


    private void ulti()
    {
        switch (bossId)
        {
            case 1:
                boss_1_Ulti();
                break;

            case 2:
                //boss_2_Ulti();

                break;

            case 3:
                break;

        }
    }

    //private void Retreat()
    //{

    //    agent.Stop();

        
    //    float zpos = transform.position.z + transform.forward.z * -0.2f;
    //    LeanTween.moveZ(gameObject, zpos, 0.5f);
        
        

    //    agent.Resume();

    //}

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

    private void boss_2_Ulti()
    {

        float start_angle = 40;
        float radius = 3;


        
       
            for (int i = 0; i < 4; i++)
            {
                float x = Mathf.Sin((270 + (180 - transform.rotation.eulerAngles.y) + start_angle * (i + 1)) * Mathf.Deg2Rad) * radius;
                float z = Mathf.Cos((270 + (180 - transform.rotation.eulerAngles.y) + start_angle * (i + 1)) * Mathf.Deg2Rad) * radius;
                floors[i].transform.position = new Vector3(x, floors[i].transform.position.y, z) + transform.position;
                floors[i].SetActive(true);
            }

   
    }

    private void Ult2_End_Trigger()
    {
        agent.Resume();
        boss2trigger = false;

        for (int i = 0; i < 4; i++)
        {
            floors[i].transform.position = Vector3.zero;
        }
    }

    private void Boss2_Move()
    {
        

        for (int i = 0; i < 4; i++)
        {
           
            LeanTween.move(floors[i], projectile_target, 0.6f);
        }

        ultBarValue = 0;

    }

    private void LevitateCharacter()
    {

        agent.Stop();
        boss2trigger = true;

        float zpos = transform.position.z + transform.forward.z * -2f;
        LeanTween.moveZ(gameObject, zpos, 1f);

    }


    private void Levitate()
    {
        boss_2_Ulti();

        projectile_target = new Vector3 (target.transform.position.x, target.transform.position.y + 1f, target.transform.position.z);

        for (int i = 0; i < 4; i++)
        {
            LeanTween.moveY(floors[i], 2, 0.4f);
        }

    }



    private void Boss3_Ulti()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        agent.enabled = false;
        
    }


    private void Boss3_Ulti_End()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        agent.enabled = true;
        //checksphare ?? radius ?? etraftaki collider alma 
        //targetle düþman arasýndaki distance alma 

        ultEnd();

    }

    private void TakeDamage()
    {
        Debug.Log("ulti hasar verildi");

        particle1.GetComponent<ParticleSystem>().Play();
        particle2.GetComponent<ParticleSystem>().Play();
        eyeancor.GetComponent<PlayerHealth>().ModifyHealth(-40);
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
