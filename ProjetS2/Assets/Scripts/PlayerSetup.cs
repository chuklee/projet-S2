using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour //On change ça car MonoBehaviour ne sert que qu'en le script est pour la solo
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;
    private void Start()
    {
        if (!isLocalPlayer)//Regarde si le player est bien nous
        {
            //On va boucler sur les différents composants renseignés et les désactiver si ce joueur n'est pas le notre
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;// On désactive chaque component
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
