using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void CargarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }

}
