using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    new private AudioSource audio;
    Rigidbody rigid;
    public float impact = 0.1f;
    private float volume;



    void Start()
    {
      AudioSource audio =  GetComponent<AudioSource>();
      //rigid = GameObject.Find("Player").GetComponent<Rigidbody>();

    }

    void Update()
    {
        // volume = (rigid.velocity.magnitude);
        // Debug.Log(volume);

    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter (Collider hit)
	{
       // audio.PlayOneShot(audio.clip);
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag ("Player")) {


            // このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);
		}
	}
}