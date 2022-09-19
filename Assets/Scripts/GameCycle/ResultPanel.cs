using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    GameObject _panel;

    [SerializeField]
    Text _text;

    [SerializeField]
    Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    public void Init(string text)
    {
        _panel.SetActive(true);
        _text.text = text;
    }
}
