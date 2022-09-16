using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTriggerSMB : StateMachineBehaviour
{
    [Header("リセットするトリガーの名前"),SerializeField]
    string _resetTriggerName = "AttackTrigger";
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(_resetTriggerName);
    }
}
