using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 6;
    public float JumpForce = 7;
    Rigidbody2D Rig;
    private bool CompareFloor;
    Animator Anim;

    void Start()
    {
        Rig = transform.GetComponent<Rigidbody2D>();
        Anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        transform.Translate(x, 0, 0);
        
        if (x > 0)
        {
         
            transform.GetComponent<SpriteRenderer>().flipX = false;
            Anim.SetBool("walk", true);
        }
        if (x < 0)
        {
           
            transform.GetComponent<SpriteRenderer>().flipX = true;
            Anim.SetBool("walk", true);
        }
        if(x==0)
        {
            Debug.Log("static");
            Anim.SetBool("walk", false);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& CompareFloor)
        {
            Rig.AddForce(Vector2.up *JumpForce,ForceMode2D.Impulse);
            Anim.SetBool("jump", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("floor")|| collision.transform.CompareTag("ob")) 
        {
            CompareFloor = true;
            Anim.SetBool("jump", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("floor")|| collision.transform.CompareTag("ob")) 
        {
            CompareFloor = false;
        }
    }
}
