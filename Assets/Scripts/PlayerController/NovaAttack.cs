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

    [SerializeField, Header("攻撃時の当たり判定")]
    Collider _attackCollider = default;
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
            if (_attackCollider)
            {
                StartCoroutine(AttackColider());
            }         
            _animator.SetTrigger("AttackTrigger");
        }
    }
    IEnumerator AttackColider()
    {
        _attackCollider.gameObject?.SetActive(true);
        yield return new WaitForSeconds(1f);
        _attackCollider.gameObject?.SetActive(false);
    }
}
