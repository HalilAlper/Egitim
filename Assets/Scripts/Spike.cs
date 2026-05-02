using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int azalacakCan = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OyuncuKontrolcusu player = other.gameObject.GetComponent<OyuncuKontrolcusu>();
            if (player != null)
            {
                player.CanAzalt(azalacakCan);
            }
        }
    }
}
