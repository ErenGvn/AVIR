using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingTwo : StateMachineBehaviour
{
    private SphereCollider leftcollider;
    private SphereCollider head;
    private CapsuleCollider body;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        leftcollider = animator.GetComponent<AnimController>().leftcollider;
        leftcollider.enabled = true;

        head = animator.GetComponent<AnimController>().head;
        head.isTrigger = false;

        body = animator.GetComponent<AnimController>().body;
        body.isTrigger = false;



        if (!animator.GetComponent<AnimController>().comboControl1)
           animator.GetComponent<AnimController>().punchWaitTime = animator.GetComponent<AnimController>().pwtime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        leftcollider.enabled = false;
        head.isTrigger = true;
        body.isTrigger = true;
        animator.SetBool("punch2", false);
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
