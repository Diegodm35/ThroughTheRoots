using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MyCharacterMovement : MonoBehaviour {
  [Tooltip("The speed of the character")]
  [SerializeField] private float speed = 2f;

  [Tooltip("The jump force of the character")]
  [SerializeField] private float jumpForce = 2f;

  /// <value> The rigidbody of the object </value>
  private Rigidbody2D rb;

  /// <summary>
    /// Move the character in the x-axis
  /// </summary>
  private void Movement() {
    // Get the input from the player
    float horizontal = Input.GetAxis("Horizontal");

    // Calculate the direction of the movement
    Vector3 direction = new Vector3(horizontal, 0, 0);

    // Move the character
    transform.position += direction * speed * Time.deltaTime;
  }

  /// <summary>
    /// Make the character jump
  /// </summary>
  private void Jump() {
    // Add the jump force to the character
    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
  }

  private void Update() {
    Movement();
    if (Input.GetKeyDown(KeyCode.Space) && canJump) {
      Jump();
      canJump = false;
    }
  }

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnCollisionEnter(Collision other) {
    if (other.gameObject.CompareTag("Ground")) canJump = true;
  }
}