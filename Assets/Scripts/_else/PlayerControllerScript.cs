using UnityEngine;

public class NoveMove : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 120f;

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(0, 0, v);

        // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);

        // キャラクターの移動
        transform.localPosition += velocity * speed * Time.fixedDeltaTime;

        // キャラクターの回転
        transform.Rotate(0, h * rotateSpeed * Time.fixedDeltaTime, 0);

    }

}