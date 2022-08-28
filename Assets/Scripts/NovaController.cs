﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class NovaController : MonoBehaviour
{
    //必要なコンポーネント
    Rigidbody _rigidBody = null;
    Animator _anim = null;

    //パラメータ
    [Header("プレイヤーの移動スピード"), SerializeField]
    float _speed = 5f;

    float _hor = 0f;
    float _ver = 0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _hor = Input.GetAxisRaw("Horizontal");
        _ver = Input.GetAxisRaw("Vertical");
        _anim.SetBool("IsWalk", Mathf.Abs(_ver) > 0.1f || Mathf.Abs(_hor) > 0.1f);

        Vector3 dir = Vector3.forward * _ver + Vector3.right * _hor;
        if (dir == Vector3.zero)
        {
            _rigidBody.velocity = new Vector3(0, _rigidBody.velocity.y, 0);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する // y 軸方向はゼロにして水平方向のベクトルにする // そのベクトルの方向にオブジェクトを向ける

            dir.y = 0;
            this.transform.forward = dir;
            // 前方に移動する。ジャンプした時の y 軸方向の速度は保持する
            _rigidBody.velocity = dir * _speed;
        }
    }
}
