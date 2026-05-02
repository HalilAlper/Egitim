using UnityEngine;

public class CarScript : MonoBehaviour
{
    public Vector3 speed = Vector3.forward;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }
}
