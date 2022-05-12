using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : StateMachineBehaviour
{

    [HideInInspector] public bool isBlock = false;
    float startBlockTime = 0;
    //[HideInInspector] public float blockWaitTime = 0;
    [HideInInspector]  public bool blockController = false;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isBlock = true;
        startBlockTime = 2;
 
        blockController = false;
     

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (startBlockTime > 0)
            startBlockTime -= Time.deltaTime;
        //if (blockWaitTime > 0)
        //    blockWaitTime -= Time.deltaTime;
        if (startBlockTime <= 0)
            animator.SetBool(AnimatorHashId.blockhashid, false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isBlock)
            isBlock = false;
        blockController = false;
        //Debug.Log("isblock" + isBlock);
        //Debug.Log("blockWaitTime" + blockWaitTime);
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
