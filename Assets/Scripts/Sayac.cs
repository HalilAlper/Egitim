using UnityEngine;

public class Sayac : MonoBehaviour
{
    [SerializeField] private float sayac = 0f;
    [SerializeField] private float hedefSure = 3f;
    private int toplamSayilan = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if ( sayac < hedefSure)
        {
            sayac += Time.deltaTime;
        }
        else
        {
            sayac = hedefSure;
            Debug.Log("Sayaç hedefe ulaştı! Sayaç = " + sayac);
            sayac = 0f;
            toplamSayilan++;
            Debug.Log("Toplam arttırıldı! Toplam = " + toplamSayilan);
        }
    }
}
