using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public HealthBar healthBar;
    public OyuncuKontrolcusu oyuncu;
    public TextMeshProUGUI paraText;

    private void Update()
    {
        float yuzde = (float)oyuncu.can / (float)oyuncu.maxCan;
        healthBar.CanBarAyarla(yuzde);
        Debug.Log("Ayarlaniyor: " + yuzde.ToString());

        paraText.text = "Para: " + oyuncu.coin.ToString();
    }
}
