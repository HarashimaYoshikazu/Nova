using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaControllerAddForce : MonoBehaviour
{
    //必要なコンポーネント
    Rigidbody _rb = null;
    Animator _anim = null;

    //パラメータ
    [Header("プレイヤーの移動スピード"), SerializeField]
    float _speed = 5f;

    Vector3 _dir;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
        // カメラのローカル座標系を基準に dir を変換する
        _dir = Camera.main.transform.TransformDirection(_dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        _dir.y = 0;
        // キャラクターを「現在の（XZ 平面上の）進行方向」に向ける
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }
    }

    void FixedUpdate()
    {
        // 「力を加える」処理は力学的処理なので FixedUpdate で行うこと
        _rb.AddForce(_dir.normalized * _speed, ForceMode.Force);
    }
}
