using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParamator : ParamatorBase
{
    [SerializeField,Header("プレイヤーに対する攻撃力")]
    int _attack = 1;
    public int GetAttack => _attack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackCollider"))
        {
            var novaAttack = other.transform.root.GetComponent<NovaAttack>();
            Damage(novaAttack.GetAttack);
        }
    }
}
