using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearObject : MonoBehaviour
{
    ResultPanel _resultPanel = default;
    [SerializeField]
    string _cleatText;

    private void Awake()
    {
        _resultPanel = FindObjectOfType<ResultPanel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _resultPanel.Init(_cleatText);
        }
    }
}
