using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabEnemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CriarEnemy", 4f, 4f);
    }

    void CriarEnemy()
    {
        Instantiate(prefabEnemy, transform.position, Quaternion.identity);
    }
}
