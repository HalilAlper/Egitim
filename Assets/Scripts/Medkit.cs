using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int artacakCan = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OyuncuKontrolcusu player = other.gameObject.GetComponent<OyuncuKontrolcusu>();
            if (player != null)
            {
                player.CanArttir(artacakCan);
            }
        }
    }
}
