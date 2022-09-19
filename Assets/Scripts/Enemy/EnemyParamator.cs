using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParamator : MonoBehaviour
{
    [SerializeField,Header("初期化HP")]
    int _initHP = 2;
    /// <summary>現在のHP</summary>
    int _hp = 0;

    [SerializeField, Header("死亡時のプレハブ")]
    GameObject _deathPrefab;

    private void Awake()
    {
        ResetHP();
    }

    void Damage(int value)
    {
        _hp -= value;
        if (_hp<=0)
        {
            Death();
        }
    }

    void Death()
    {
        if (_deathPrefab)
        {
            Instantiate(_deathPrefab,this.transform.position,Quaternion.identity);
        }
        Destroy(this.gameObject);
    }

    private void ResetHP()
    {
        _hp = _initHP;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("あたったよ");
        if (other.transform.root.gameObject.TryGetComponent(out NovaAttack novaAttack))
        {   
            Damage(novaAttack.GetAttack);
        }
    }
}
