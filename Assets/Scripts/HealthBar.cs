using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform canBar;
    [SerializeField] private float maxGenislik = 400;

    public void CanBarAyarla(float yuzde)
    {
        Debug.Log("Istek geldi: " + yuzde.ToString());
        yuzde = 1 - yuzde;
        float genislik = -yuzde * maxGenislik;
        canBar.sizeDelta = new Vector2(genislik, canBar.sizeDelta.y);
    }

}
