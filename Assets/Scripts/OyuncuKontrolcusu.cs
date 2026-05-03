using UnityEngine;

public class OyuncuKontrolcusu : MonoBehaviour
{
    public int coin = 0;

    [SerializeField] private float hiz = 5f;
    [SerializeField] private float ziplamaGucu = 6f;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCam;

    public int can = 3;
    public int maxCan = 5;

    private Rigidbody rb;
    private bool yerdeMi = true;

    private void Awake()
    {
        mainCam = Camera.main;
    }

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
        hareket.Normalize();
        //rb.MovePosition(rb.position + hareket * hiz * Time.deltaTime);

        if (yerdeMi && space)
        {
            animator.SetTrigger("Zipla");
        }

        //camera forward and right vectors:
        var forward = mainCam.transform.forward;
        var right = mainCam.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        Vector3 desiredMoveDirection = forward * v + right * h;
        Debug.Log(desiredMoveDirection);

        //now we can apply the movement:
        rb.MovePosition(rb.position + desiredMoveDirection * hiz * Time.deltaTime);
        if (desiredMoveDirection.magnitude > 0.1f)
        {
            Vector3 fw = mainCam.transform.forward;
            fw = new Vector3(fw.x,0,fw.z);
            fw.Normalize();
            transform.forward = fw;
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