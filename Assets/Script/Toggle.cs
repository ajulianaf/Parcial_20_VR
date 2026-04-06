using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] figuras;
    public Image[] botonesImagen;

    public Color colorOn = new Color(0.2f, 0.8f, 0.2f); // verde
    public Color colorOff = new Color(0.8f, 0.2f, 0.2f); // rojo

    public int[] ordenCorrecto = { 0, 1, 2 };

    int pasoActual = 0;

    void Start()
    {
        Reiniciar();
    }

    public void ActivarToggle(int index)
    {
        // activar figura
        figuras[index].SetActive(true);

        // cambiar color a verde
        botonesImagen[index].color = colorOn;

        // validar orden
        if (index == ordenCorrecto[pasoActual])
        {
            pasoActual++;

            if (pasoActual == ordenCorrecto.Length)
            {
                Debug.Log("GANASTE");
            }
        }
        else
        {
            Reiniciar();
        }
    }

    public void Reiniciar()
    {
        pasoActual = 0;

        for (int i = 0; i < figuras.Length; i++)
        {
            // ocultar figuras
            figuras[i].SetActive(false);

            // poner botones en rojo
            botonesImagen[i].color = colorOff;
        }
    }
}