using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper2 : MonoBehaviour
{
    private AudioSource sound01;
    private float volume;
    public float impact = 0.1f;
   // public float fric = 1.0f;
    Rigidbody rigid;
    public float x;
    public float y;
    public float z;


    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        rigid = GameObject.Find("Player").GetComponent<Rigidbody>();

    }

    void Update()
    {
    volume = (rigid.velocity.magnitude);
        // Debug.Log(volume);
    }


    // オブジェクトと接触した時に呼ばれるコールバック
    void OnCollisionEnter(Collision hit)
    {
        sound01.PlayOneShot(sound01.clip, impact * volume);
        rigid.AddForce(x, y, z, ForceMode.Impulse);
    }

    


}