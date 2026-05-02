using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] List<Material> carMats = new List<Material>();
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;

    public float spawnPer = 4f;
    public float carSpeed = 1f;

    private float timePassed = 0f;
    private bool isLeft = false;

    private void Start()
    {
        isLeft = Random.Range(0, 2) > 1;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > spawnPer)
        {
            GameObject.Instantiate(carPrefab);
            if (isLeft)
            {
                carPrefab.transform.position = left.transform.position;
            }
            else
            {
                carPrefab.transform.position = right.transform.position;
            }
        }
    }
}
