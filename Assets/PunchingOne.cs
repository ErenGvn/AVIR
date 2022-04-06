using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingOne : StateMachineBehaviour
{
   private SphereCollider rightcollider;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rightcollider = animator.GetComponent<AnimController>().rightcollider;
         rightcollider.enabled = true;
      
        if (!animator.GetComponent<AnimController>().comboControl1)
            animator.GetComponent<AnimController>().punchWaitTime = 5;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rightcollider.enabled = false;
        animator.SetBool("punch1", false);
        if(animator.GetBool("combo"))
            animator.SetBool("combo", false);
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
