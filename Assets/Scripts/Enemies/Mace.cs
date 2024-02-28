using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 1.0f;
    public float range = 3;

    float startingY;
    //float randomY;
    //Vector2 randomUpDownVector;

    public int dir = 1;


    private void Awake()
    {
        /*do
        {
            randomY = Random.Range(-1.5f, 1.5f);
        } while (randomY == Random.Range(-1.0f, 1.0f));*/
        /*float randomValue = Random.Range(1.0f, 3.0f);
        randomY = (randomValue == 1) ? 1 : -1;*/
    }

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        /*randomUpDownVector = new Vector2(0.0f, randomY);*/
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            dir *= -1;
    }
}
