using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimController : MonoBehaviour
{
    NavMeshAgent agent;
    public TextMesh text;
    [SerializeField]Transform target;
    [SerializeField] CapsuleCollider glove1;
    [SerializeField] CapsuleCollider glove2;
    [SerializeField] GameObject popup;
    Animator animator;
    Rigidbody rb;
    float startBlockTime;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //animator.SetBool("jump", true);
        //
        // animator.SetBool("jump", false);
        agent.stoppingDistance = 7;
        agent.updateRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 20)
            return;
        agent.SetDestination(target.position);
       // transform.LookAt(target);
        animator.SetBool("punch", false);
        if (startBlockTime > 0)
        {
            animator.SetBool("block", false);
            startBlockTime -= Time.deltaTime;
        }
        if (Time.time>1)
            animator.SetBool("jump", false);

        if (Vector3.Distance(this.transform.position, target.position) > agent.stoppingDistance)
        {
           
            animator.SetFloat("walkSpeed", 1);
        }
        else
        {
            
            animator.SetFloat("walkSpeed", 0);
            if (startBlockTime <= 0)
            {
                if (Random.value < 0.5f)
                {
                    animator.SetBool("punch", true);
                    
                }
                else
                {
                    startBlockTime = 2;
                    animator.SetBool("block", true);
                }
            }
        }

  

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider == glove1 || collision.collider == glove2)
        {

            popup.SetActive(true);
            rb.AddForce(-(1.5f * transform.forward), ForceMode.Impulse);
            agent.stoppingDistance = 1.5f;

        }
        if (Time.time < 100)
            return;
            popup.SetActive(false);

        //text.text = ("Hit!!");
        //GameObject starttext = Instantiate(text.transform.gameObject, transform.position, Quaternion.identity);
        //Destroy(starttext, 100);




    }
}
