using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHit : StateMachineBehaviour
{
    private Health healthbarcontroller;
    //private SphereCollider headcollider;
    //private CapsuleCollider bodycollider;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //headcollider = animator.GetComponent<AnimController>().headcollider;
        //headcollider.enabled = false;
        //bodycollider.enabled = false;


        animator.GetComponent<Animator>().SetBool(AnimatorHashId.hit1hashid, false);
        healthbarcontroller = animator.GetComponent<Health>();
        healthbarcontroller.ModifyHealth(-15);
        

    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //headcollider.enabled = true;
        //bodycollider.enabled = true;

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
