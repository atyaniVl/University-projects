using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 5);
        if (transform.position.y >= 7) 
            Destroy(gameObject);
    }
}
