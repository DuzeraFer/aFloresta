using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float velocidade = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * velocidade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WallL")
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (collision.gameObject.tag == "WallR")
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
