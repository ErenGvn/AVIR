using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorHashId 
{
    public static int blockhashid => Animator.StringToHash("block");
    public static int walkspeedhasid => Animator.StringToHash("walkSpeed");
    public static int punch1hasid => Animator.StringToHash("punch1");
    public static int walkinghasid => Animator.StringToHash("walking");
    public static int idlinghasid => Animator.StringToHash("idling");
    public static int punch2hasid => Animator.StringToHash("punch2");
    public static int combohasid => Animator.StringToHash("combo");
    public static int hit1hashid => Animator.StringToHash("hit1");
    public static int hit2hashid => Animator.StringToHash("hit2");
    public static int dyinghashid => Animator.StringToHash("dying");
    public static int combo2hashid => Animator.StringToHash("combo2");
    public static int distancehashid => Animator.StringToHash("distance");
    public static int healthhasid => Animator.StringToHash("health");



}
