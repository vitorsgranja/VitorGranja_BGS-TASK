using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float moveSpeed = 5f; // player's movement speed
  public Animator baseAnim;
  public Animator underwearAnim;
  public Animator clothesAnim;
  public Animator hatAnim;

  private Rigidbody2D rb;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate() {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector2 movement = new Vector2(moveHorizontal,moveVertical).normalized * moveSpeed * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + movement);
    HandleMovementAnimations(movement);
  }


  private void ApplyAnimation(string dir) {
    baseAnim.SetTrigger(dir);
    underwearAnim.SetTrigger(dir);
    if(clothesAnim != null) {
      clothesAnim.SetTrigger(dir);
    }
    if(hatAnim != null) {
      hatAnim.SetTrigger(dir);
    }
  }


  private void HandleMovementAnimations(Vector2 dir) { // set the animation triggers
    if(dir.x < 0) { //is moving Left
      ApplyAnimation("Left");
    } else if(dir.x > 0) { //is moving Right
      ApplyAnimation("Right");
    } else if(dir.y > 0) { //is moving Up
      ApplyAnimation("Up");
    } else if(dir.y < 0) {//is moving Down
      ApplyAnimation("Down");
    } else { //is idle
      ApplyAnimation("Idle");
    }
  }
}