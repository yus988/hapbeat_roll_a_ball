using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;


public class Bumper : MonoBehaviour
{
    private AudioSource sound01;
    private AudioSource sound02;
    private float volume;
    public float impact = 0.1f;
   // public float fric = 1.0f;
    Rigidbody rigid;
    public float impulseMagnitude;

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        rigid = GameObject.Find("Player").GetComponent<Rigidbody>();

        // 衝突時に発生させる力積の大きさ、とりあえず50ニュートン秒とした
        this.impulseMagnitude = 50.0f;

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

        var impulse = (rigid.position - transform.parent.position).normalized * this.impulseMagnitude;

       rigid.AddForce(impulse, ForceMode.Impulse);

    }

    


}