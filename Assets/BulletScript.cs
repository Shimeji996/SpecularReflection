using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    int moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, moveSpeed);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy") 
        {
            GameObject gameManager;
            GameManagerScript gameManagerScript;
            gameManager = GameObject.Find("GameManager");
            gameManagerScript = gameManager.GetComponent<GameManagerScript>();

            gameManagerScript.Hit(transform.position);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
