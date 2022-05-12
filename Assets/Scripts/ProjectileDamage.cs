using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            other.GetComponent<PlayerHealth>().ModifyHealth(-12.5f);
            gameObject.SetActive(false);
        }
    }
}
