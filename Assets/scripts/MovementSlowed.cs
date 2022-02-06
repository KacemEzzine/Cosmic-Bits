using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSlowed : StateMachineBehaviour
{
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(PlayerScript.Ref._speed > 2.5f)
        {
            PlayerScript.Ref._speed -= 0.01f;
        }
        Debug.Log("onstateupdate");
        if (PlayerScript.Ref._fireRate > 0.1f)
        {
            PlayerScript.Ref._fireRate -= 0.0015f;
        }
        if (PlayerScript.Ref.DamageMultiplier > 10f)
        {
            PlayerScript.Ref.DamageMultiplier -= 0.15f;
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("onStateExit");
        PlayerScript.Ref._speed = 13f;
        PlayerScript.Ref._fireRate = 0.5f;
        PlayerScript.Ref.DamageMultiplier = 50f;
    }
}
