using UnityEngine;

public class CreditsText : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,6);
    }

    void Update()
    {
        transform.Translate(Vector3.up * 0.5f);
    }
}
