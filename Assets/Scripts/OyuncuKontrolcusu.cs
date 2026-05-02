using UnityEngine;

public class OyuncuKontrolcusu : MonoBehaviour
{
    public int coin = 0;

    [SerializeField] private float hiz = 5f;
    [SerializeField] private float ziplamaGucu = 6f;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Animator animator;
    public int can = 3;
    public int maxCan = 5;

    private Rigidbody rb;
    private bool yerdeMi = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        bool space = Input.GetKey(KeyCode.Space);

        Vector3 hareket = new Vector3(h, 0f, v);
        rb.MovePosition(rb.position + hareket * hiz * Time.deltaTime);

        if (yerdeMi && space)
        {
            animator.SetTrigger("Zipla");
        }
    }

    public void Zipla()
    {
        rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
        yerdeMi = false;
        animator.ResetTrigger("Zipla");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            yerdeMi = true;
            animator.SetTrigger("Dus");
        }
    }

    public void CanAzalt(int canMiktari)
    {
        can -= canMiktari;
        can = Mathf.Clamp(can, 0, maxCan);
        if (can == 0)
        {
            Debug.LogError("Kaybettin!");
        }
    }

    public void CanArttir(int canMiktari)
    {
        can += canMiktari;
        can = Mathf.Clamp(can, 0, 5);
    }
}