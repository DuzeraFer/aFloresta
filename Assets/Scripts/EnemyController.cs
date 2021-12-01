using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DestruirEnemy", 4f, 3f);
    }

    void DestruirEnemy()
    {
        Destroy(gameObject);
    }
}
