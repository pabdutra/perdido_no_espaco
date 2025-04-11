using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public float tempoRestante = 30f;
    public TextMeshProUGUI cronometroText;         // Texto do tempo restante
    public TextMeshProUGUI tempoTotalText;         // Texto do tempo total de jogo

    private float tempoDecorrido = 0f;
    private bool estaRodando = true;

    void Update()
    {
        if (!estaRodando || GameController.gameOverReal) return;

        // Atualiza tempo restante
        tempoRestante -= Time.deltaTime;
        tempoRestante = Mathf.Max(tempoRestante, 0f); // Garante que não fique negativo
        cronometroText.text = "Tempo restante: " + Mathf.CeilToInt(tempoRestante) + " s";

        // Atualiza tempo de jogo
        tempoDecorrido += Time.deltaTime;
        tempoTotalText.text = "Tempo de jogo: " + Mathf.FloorToInt(tempoDecorrido) + " s";

        if (tempoRestante <= 0)
        {
            estaRodando = false;
            GameController.GameOverPorTempo();
        }
    }

    public void AdicionarTempo(float segundos)
    {
        tempoRestante += segundos;
    }
}
