using UnityEngine;

// アタッチしたGameObjectにRigidbodyがアタッチされていない場合、アタッチする
[RequireComponent(typeof(Rigidbody))]
public class MoveRigidbody : MonoBehaviour
{
    // 移動速度を設定（Inspectorタブからも値を変更できるようにする）
    [SerializeField]
    private float speed = 2.0f;

    // アタッチしているGameObjectのRigidbodyを格納する変数
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // アタッチしているGameObjectのRigidbodyを取得
        //（FixedUpdate()内で毎回取得すると処理が重くなるので、Start()で取得する
        rigidBody = GetComponent<Rigidbody>();
    }

    //一秒間に一定の回数呼ばれる(物理演算(Rigidbody)を使った移動はFixedUpdateで行った方が良いらしい)
    private void FixedUpdate()
    {
        // 左右のキーの入力を取得
        float x = Input.GetAxis("Horizontal");
        // 上下のキーの入力を取得
        float z = Input.GetAxis("Vertical");

        // 上下左右キーを入力して得た値にspeedをかけた値をAddForceに設定して移動させる
        //（ForceMode.Impulseは瞬間的に力を加えるということ）
        rigidBody.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
    }

}