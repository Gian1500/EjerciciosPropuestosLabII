using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculeGeneratorController : MonoBehaviour
{
    public GameObject obstaculePrefab;
    public float generatorTimer = 1.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateObstacule()
    {
        Instantiate(obstaculePrefab , transform.position, Quaternion.identity);
    }

    public void StartGenerator()
    {
        InvokeRepeating("CreateObstacule", 0f, generatorTimer);
    }

    public void StopGenerator(bool clean = false)
    {
        CancelInvoke("CreateObstacule");

        if (clean)
        {
            Object[] allObstacules = GameObject.FindGameObjectsWithTag("Obstacule");

            foreach (GameObject obstacule in allObstacules)
            {
                Destroy(obstacule);
            }
        }
    }
}
