using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	// speedを制御する
	public float speed = 10;
    public float slow = 0.1f;
    private AudioSource sound1;
    Rigidbody player;


     void Start()
     {
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
        sound1 = GetComponent<AudioSource>();
     }


    private void Update()
    {

        if (transform.position.y <= 0 || Input.GetKey("r")) 
         {
          // 現在のシーン番号を取得
         int sceneIndex = SceneManager.GetActiveScene().buildIndex;

         // 現在のシーンを再読込する
         SceneManager.LoadScene(sceneIndex);
         }


    }


    void FixedUpdate ()
	{
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Rigidbody rigidbody = GetComponent<Rigidbody>();

        // xとyにspeedを掛ける
        if (transform.position.z >= 5)
        {
            rigidbody.AddForce(x * speed * slow, 0, z * speed * slow);
        }
        else
        {
           rigidbody.AddForce(x * speed, 0, z * speed);
        }
	}

    void OnTriggerEnter (Collider hit)
    {
        if (hit.gameObject.CompareTag("Item"))
        {
           sound1.Play();
        }
    }

}