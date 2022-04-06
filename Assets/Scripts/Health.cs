using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{

    [SerializeField]
    public int maxHealth = 100;

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

}
