using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    int moveSpeed = 2;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        int r = Random.Range(0, 2);

        if(r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }

        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0,0,moveSpeed*Time.deltaTime);
        if(gameManagerScript.IsGameOver()==true )
        {
            return;
        }
        transform.position += transform.rotation*velocity;

        if(transform.position.x > 4) 
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        if(transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
    }
}
