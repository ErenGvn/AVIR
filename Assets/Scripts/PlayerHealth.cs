using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    public int maxHealth = 150;
    public Image blood;

    [HideInInspector]
    public float blockmultiplier = 1;

    private float fadeouttime;
    private float fadeoutfreq = 0.1f;

    public float currentHealth;


    public event Action<float> OnHealthPctChanged = delegate { };

    public void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        currentHealth += amount / blockmultiplier;
        fadeouttime = 1;
        StartCoroutine(GetHitTexture());
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);






    }


    IEnumerator GetHitTexture()
    {
        while (fadeouttime >= 0)
        {
           
            blood.color = new Color(blood.color.r, blood.color.g, blood.color.b, fadeouttime);
            fadeouttime -= fadeoutfreq;
            yield return new WaitForSeconds(fadeoutfreq);


        }

    }


    public void Update()
    {


        if (fadeouttime <= 0)
            StopCoroutine(GetHitTexture());




    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {
            //Debug.Log("adam vuruþ");
            ModifyHealth(-10);


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
