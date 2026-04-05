using UnityEngine;

public class Rock : MonoBehaviour
{
    float _speed = 5;
    void Start()
    {
        Destroy(gameObject,6);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
