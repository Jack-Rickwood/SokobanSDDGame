using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    public GameObject player;
    public bool direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    IEnumerator Wait(float duration) {
        yield return new WaitForSeconds(duration);
    }
    
    void OnCollisionEnter2D(Collision2D coll) {
    	if (direction && coll.gameObject.tag != "Player") {
    	    gameObject.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePositionX;
    	}
    	if (!direction && coll.gameObject.tag != "Player") {
    	    gameObject.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePositionY;
    	}
    }

    void OnTriggerEnter2D(Collider2D coll) {
    	gameObject.GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints2D.FreezePosition;
    }

    void OnCollisionExit2D(Collision2D coll) {
    	if (!direction && coll.gameObject.tag != "Player") {
    	    gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    	}
    	if (direction && coll.gameObject.tag != "Player") {
    	    gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    	}
    }

    // Update is called once per frame
    void Update()
    {
    	if (player.GetComponent<PlayerController>().movingHorizontal && !player.GetComponent<PlayerController>().movingVertical) { direction = true; }
    	if (player.GetComponent<PlayerController>().movingVertical && !player.GetComponent<PlayerController>().movingHorizontal) { direction = false; }
    }
}
