using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float rotationSpeed = 180f; // Velocidad de rotación (grados por segundo)
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento exclusivo con WASD
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D o flechas izquierda/derecha
        float moveY = Input.GetAxisRaw("Vertical");   // W/S o flechas arriba/abajo
        movement = new Vector2(moveX, moveY).normalized;

        // Rotación exclusiva con las flechas de dirección
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Rotate(180); // Rotar hacia abajo (180 grados)
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Rotate(0); // Rotar hacia arriba (0 grados)
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(270); // Rotar hacia la izquierda (270 grados)
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(90); // Rotar hacia la derecha (90 grados)
        }
    }

    void FixedUpdate()
    {
        // Mover al jugador usando el Rigidbody2D (exclusivo con WASD)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Función para rotar el personaje
    private void Rotate(float targetAngle)
    {
        // Aplicar la rotación al personaje en el eje Z
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
    }
}
