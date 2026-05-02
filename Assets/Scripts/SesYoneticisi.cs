using UnityEngine;

public class SesYoneticisi : MonoBehaviour
{
    public AudioClip coinSesi;
    public AudioSource kaynak;

    private void Start()
    {
        kaynak = GetComponent<AudioSource>();
    }

    public void CoinSesiCal()
    {
        kaynak.PlayOneShot(coinSesi);
    }
}
