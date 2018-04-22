using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;


public class DangerWall : MonoBehaviour
{

    private AudioSource sound01;
    private AudioSource sound02;
    private float volume;
    public float impact = 0.1f;
    public float fric = 1.0f;
    Rigidbody rigid;
    

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
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
        sound01.PlayOneShot(sound01.clip, impact*volume);

       /* // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag("Player"))
        {
        GetComponent<AudioSource>().Play();
        sound01.PlayOneShot(sound01.clip);

            // 現在のシーン番号を取得
             int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // 現在のシーンを再読込する
             SceneManager.LoadScene(sceneIndex);
         }  */

    }

    void OnCollisionStay(Collision attach)
    {
        if (attach.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayMethod(10f));
        }
    }


    private IEnumerator DelayMethod(float waitTime)
    {
        // yield return new WaitForSeconds(waitTime);

        yield return null;
        sound02.PlayOneShot(sound02.clip, fric * volume);
    }

    void OnCollisionExit(Collision hit)
    {
        //Stop the audio
        //sound01.Stop();
        sound02.Stop();

    }


}