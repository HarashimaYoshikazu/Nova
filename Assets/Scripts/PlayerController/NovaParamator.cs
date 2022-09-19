using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaParamator : ParamatorBase
{
    [SerializeField, Header("死亡時のテキスト")]
    string _text = "まけちゃった…";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyParamator enemy))
        {
            Debug.Log($"{enemy.name}にあたった");
            Damage(enemy.GetAttack);
        }
    }

    protected override void OnDeath()
    {
        var panel = FindObjectOfType<ResultPanel>();
        panel.Init(_text);
    }
}
