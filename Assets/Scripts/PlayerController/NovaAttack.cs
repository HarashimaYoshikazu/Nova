using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NovaAttack : MonoBehaviour
{
    Animator _animator = default;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("AttackTrigger");
        }
    }
}
