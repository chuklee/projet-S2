using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;


    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero)//Pour optimiser le programme on vérifie que la vélocité n'est pas nul et donc ne pas calculer pour rien
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // Permet de dire que la nouvelle position sera la position actuelle + la vélocité. On mulitplie par Time.fixed pour que l'animation soit plus smooth
        
        }
    }
    
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);
    }
}
