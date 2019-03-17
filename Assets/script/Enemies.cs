using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    bool CambioPos;
    float speed = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ob"))
        {
            CambioPos = ! CambioPos;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CambioPos == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (CambioPos == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
	}
}
