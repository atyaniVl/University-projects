using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] Material _backgroudMat;
    [SerializeField] float _speed;
    Vector2 _offset;
    void Start()
    {
        _backgroudMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        _offset = new Vector2(_speed * Time.deltaTime, 0);
        _backgroudMat.mainTextureOffset += _offset;
    }
}
