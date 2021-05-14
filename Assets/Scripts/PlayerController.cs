using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int num_boxes;
    public int completed_boxes = 0;
    public Transform movePoint;
    public bool movingHorizontal = false;
    public bool movingVertical = false;
    public int level_num;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !movingVertical) {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                movingHorizontal = true;
            } else { movingHorizontal = false; }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && !movingHorizontal) {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                movingVertical = true;
            } else { movingVertical = false; }
        }
        
        if (num_boxes == completed_boxes) {
            SceneManager.LoadScene("Level" + (level_num + 1).ToString());
        }
    }
}
