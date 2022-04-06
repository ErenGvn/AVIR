using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    public int maxHealth = 150;

    public int currentHealth;


    public event Action<float> OnHealthPctChanged = delegate { };

    public void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(currentHealth);

            ModifyHealth(-10);
        }

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("adam vuruþ");
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
