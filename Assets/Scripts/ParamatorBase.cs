using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamatorBase : MonoBehaviour
{
    [SerializeField, Header("初期化HP")]
    protected int _initHP = 2;
    /// <summary>現在のHP</summary>
    protected int _hp = 0;

    [SerializeField, Header("死亡時のプレハブ")]
    protected GameObject _deathPrefab;

    private void Awake()
    {
        ResetHP();
    }

    protected void Damage(int value)
    {
        _hp -= value;
        if (_hp <= 0)
        {
            Death();
        }
    }

    protected void Death()
    {
        if (_deathPrefab)
        {
            Instantiate(_deathPrefab, this.transform.position, Quaternion.identity);
        }
        OnDeath();
        Destroy(this.gameObject);
    }

    protected virtual void OnDeath() { }

    protected void ResetHP()
    {
        _hp = _initHP;
    }
}
