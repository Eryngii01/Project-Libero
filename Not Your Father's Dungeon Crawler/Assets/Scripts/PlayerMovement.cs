using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject playerCamera;
    public float speed;
    private Vector3 cameraOffset = new Vector3(0, 0, -10);
    Rigidbody2D rbody;
    Animator anim;

    void Start() {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Make camera follow player
        playerCamera.transform.position = transform.position + cameraOffset;

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero) {
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        } else {
            anim.SetBool("is_walking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * speed);
    }
}
