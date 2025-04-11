using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void IniciaJogo()
    {
        GameController.Init();
        Invoke(nameof(CarregarCena), 1f); // Delay de 0.2 segundos
    }

    private void CarregarCena()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public GameObject endGameMenu;
}
