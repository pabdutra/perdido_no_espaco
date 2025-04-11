using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI pontuacaoText;

    void Start()
    {
        // Garante que o painel comece desativado ao iniciar o jogo
        endGamePanel.SetActive(false);
    }

    void FixedUpdate()
    {
        // Ativa o painel SOMENTE quando o jogo acabar
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
