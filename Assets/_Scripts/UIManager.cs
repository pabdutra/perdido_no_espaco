using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI pontuacaoText;

    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            endGamePanel.SetActive(true);
        }

        if (pontuacaoText != null)
        {
            pontuacaoText.text = "Pontos: " + GameController.TotalColetados;
        }
    }
}
