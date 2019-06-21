using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float runSpeed = 8f;
  public float walkSpeed = 6f;
  public float gravity = -10f;
  public float jumpHeight = 15f;

  private CharacterController controller;
  private Vector3 motion;
  private Vector3 velocity;

  // Start is called before the first frame update
  void Start()
  {
    controller = GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    float inputH = Input.GetAxis("Horizontal");
    float inputV = Input.GetAxis("Vertical");

    // If Is Grounded AND is NOT jumping
    if (controller.isGrounded)
    {
      velocity -= motion;

      Vector3 normalized = new Vector3(inputH, 0f, inputV);
      normalized.Normalize();
      Move(normalized.x, normalized.z);

      velocity += motion;

      velocity.y = gravity * Time.deltaTime;
    }

    velocity += Vector3.up * gravity * Time.deltaTime;

    // Applies motion to CharacterController
    controller.Move(velocity * Time.deltaTime);
  }

  // Move the Player Characer in the direction we give it (horizontal / vertical)
  public void Move(float horizontal, float vertical)
  {
    Vector3 direction = new Vector3(horizontal, 0f, vertical);

    // Convert local direction to world space
    direction = transform.TransformDirection(direction);

    motion.x = direction.x * walkSpeed;
    motion.z = direction.z * walkSpeed;
  }

  // Makes the player jump when called
  public void Jump(float height)
  {
    motion.y = height;
  }

  public void Bounce(Transform reference)
  {
    motion = Vector3.zero;
    velocity = reference.up * jumpHeight;
  }
}
