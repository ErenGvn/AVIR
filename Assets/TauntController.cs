using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntController : StateMachineBehaviour
{
    [SerializeField] private float taunthealthval;

    private SphereCollider head;
    private CapsuleCollider body;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        head = animator.GetComponent<AnimController>().head;
        head.isTrigger = false;

        body = animator.GetComponent<AnimController>().body;
        body.isTrigger = false;

        animator.GetComponent<Health>().ModifyHealth(taunthealthval);


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        head.isTrigger = true;
        body.isTrigger = true;
        animator.SetBool(AnimatorHashId.taunthashid, false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
