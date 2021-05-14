using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int num_boxes;
    private int completed_boxes = 0;
    public Transform movePoint;
    public Transform cratePushPoint;
    public bool movingHorizontal = false;
    public bool movingVertical = false;
    Animator anim;
    
    public Vector3 destination_1; public Vector3 destination_2; public Vector3 destination_3; public Vector3 destination_4; public Vector3 destination_5; public Vector3 destination_6; public Vector3 destination_7; public Vector3 destination_8; public Vector3 destination_9; public Vector3 destination_10;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        cratePushPoint.parent = null;
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
    }
}
