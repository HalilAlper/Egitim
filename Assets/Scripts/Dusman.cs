using UnityEngine;

public class Dusman : MonoBehaviour
{
    public float patrolHiz = 1.5f;
    public float takipHiz = 3f;
    public float algiMesafesi = 6f;
    public Transform noktaA;
    public Transform noktaB;
    private Transform hedef;
    private Transform oyuncu;
    void Start()
    {
        hedef = noktaA;
        oyuncu = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, oyuncu.position);
        if (mesafe < algiMesafesi)
        { // Oyuncuyu gördü — takip
            transform.position = Vector3.MoveTowards( transform.position, oyuncu.position, takipHiz * Time.deltaTime);
        }
        else
        { // Patrol — A ve B arasında gidip gel
            transform.position = Vector3.MoveTowards( transform.position, hedef.position, patrolHiz * Time.deltaTime);
            if (Vector3.Distance(transform.position, hedef.position) < 0.1f)
            {
                hedef = (hedef == noktaA) ? noktaB : noktaA;
            }
                
        }
    }
} 