using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      
    public float rotationSpeed = 180f; 
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento exclusivo con WASD
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");   
        movement = new Vector2(moveX, moveY).normalized;


        if (Input.GetKey(KeyCode.UpArrow))
        {
            Rotate(180); 
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Rotate(0); 
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(270);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(90);
        }
    }

    void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void Rotate(float targetAngle)
    {
       
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
    }
}
