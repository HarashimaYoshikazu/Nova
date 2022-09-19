using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NovaAttack : MonoBehaviour
{
    Animator _animator = default;
    [SerializeField, Header("敵に与えるダメージ")]
    int _attack = 1;
    public int GetAttack => _attack;
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
