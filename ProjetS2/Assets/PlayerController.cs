using UnityEngine;

//A FAIRE : -Regarder ce que c'est un Vecteur3
//          - Regarder ce que ça veut dire normaliser des données
//          -Regarder à quoi sert "new" 

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] //Permet d'afficher la variable dans unity car la variable speed est en private
    private float speed = 3f; //Variable de la vitesse. On utilise le type float pour plus de précision

    [SerializeField]
    private float mouseSensitivityX = 3f;

    [SerializeField]
    private float mouseSensitivityY = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>(); // Dans motor on sauvegarde le script PlayerMotor
    }

    private void Update()
    {
        //Calculer la vélocité (vitesse) du mouvement de notre joueur
        float xMov = Input.GetAxisRaw("Horizontal");//Raw car on ne veux pas filtre. Récupère les mouvements du joueur horizontale (compris entre -1;1)
        float zMov = Input.GetAxisRaw("Vertical");//Récupère les mouvements du joueur en verticale (compris entre -1;1)

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        //On calcule la rotation du joeur en un Vector3
        float yRot = Input.GetAxisRaw("Mouse X");// Récupére le X de la souris

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        motor.Rotate(rotation);

        //On calcule la rotation de la caméra (afin que le joueur ne soit pas incliné lors de ses déplacements de souris) en un Vector3
        float xRot = Input.GetAxisRaw("Mouse Y");// Récupére le X de la souris

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivityY;

        motor.RotateCamera(cameraRotation);//Mettre moins si on veux inverser la caméra

    }

}
