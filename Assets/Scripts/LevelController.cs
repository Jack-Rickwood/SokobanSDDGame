using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject player;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate() { ReloadGame("Level" + player.GetComponent<PlayerController>().level_num.ToString()); });
    }
    
    public void ReloadGame(string level)
    {
        SceneManager.LoadScene(level);
    }
    
    void OnTriggerEnter2D(Collider2D coll) {
    	if (coll.gameObject.tag == "Crate") {
    	    player.GetComponent<PlayerController>().completed_boxes += 1;
    	}
    }
    
    void OnTriggerExit2D(Collider2D coll) {
    	if (coll.gameObject.tag == "Crate") {
    	    player.GetComponent<PlayerController>().completed_boxes -= 1;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
