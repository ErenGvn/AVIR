using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walking : StateMachineBehaviour
{


    private Transform target;
    NavMeshAgent agent;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = animator.GetComponent<AnimController>().target.transform;
        agent = animator.GetComponent<AnimController>().agent;




    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.GetFloat(AnimatorHashId.distancehashid) > agent.stoppingDistance)
        {
            //  agent.velocity 
            if (!animator.GetBool(AnimatorHashId.punch1hasid) && !animator.GetBool(AnimatorHashId.blockhashid) && !animator.GetBool(AnimatorHashId.punch2hasid) && !animator.GetBool(AnimatorHashId.combohasid) && !animator.GetBool(AnimatorHashId.combo2hashid))
            {
               
                agent.SetDestination(target.transform.position);

            }
        }


    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.velocity = Vector3.zero;
      
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
