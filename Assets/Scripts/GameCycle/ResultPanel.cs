using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField,Header("リザルト時にアクティブになるパネル")]
    GameObject _panel;

    [SerializeField, Header("リザルト状態を表すテキスト")]
    Text _text;

    [SerializeField, Header("シーンを読み込むボタン")]
    Button _restartButton;

    [SerializeField, Header("読み込むシーン名")]
    string _sceneName;

    private void Awake()
    {
        _restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_sceneName);
        });
    }

    public void Init(string text)
    {
        _panel.SetActive(true);
        _text.text = text;
    }
}
