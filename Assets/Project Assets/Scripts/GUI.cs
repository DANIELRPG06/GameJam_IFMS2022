using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pontosText;
    [SerializeField]
    private TextMeshProUGUI chaveQtdText;
    [SerializeField]
    private TextMeshProUGUI staminaText;
    [SerializeField]
    private Player player;
    private TopDownCharacterMotor playerMotor;

    void Start()
    {
        playerMotor = player.GetComponent<TopDownCharacterMotor>();
    }


    void Update()
    {
        float stamina =( playerMotor.stamina / playerMotor.maxStamina)*100;

        pontosText.text = "Pontos: " + player.pontos.ToString();
        chaveQtdText.text = "Chaves: " + player.chaveQtd.ToString();
        staminaText.text = "Stamina: " + stamina.ToString("F0") + "%";
    }
}
