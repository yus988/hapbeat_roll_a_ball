using UnityEngine;
using System.Collections;

public class FPScamera : MonoBehaviour
{
    public Transform target;    // ターゲットへの参照
    private Vector3 offset;     // 相対座標

    void Start()
    {
        //自分自身とtargetとの相対距離を求める
       // offset = GetComponent<Transform>().position - target.position;
    }

    void Update()
    {
        // 自分の座標にtargetの座標を代入する		
        GetComponent<Transform>().position = target.position + offset;

        if (Input.GetKey("k"))
        {
            transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
        }
        if (Input.GetKey("i"))
        {
            transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f));
        }

        if (Input.GetKey("j"))
        {
            transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
        }
        if (Input.GetKey("l"))
        {
            transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f));
        }
    }
}