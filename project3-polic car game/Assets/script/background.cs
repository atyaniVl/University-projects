using UnityEngine;

public class background : MonoBehaviour
{
    [SerializeField] Material _backgroudMat;
    [SerializeField] float _speed;
    Vector2 _offset;
    void Start()
    {
        _backgroudMat = GetComponent<Renderer>().material;
        _offset = Vector2.zero;
        _backgroudMat.mainTextureOffset += _offset;
    }

    void Update()
    {
        _offset = new Vector2(0, _speed * Time.deltaTime);
        _backgroudMat.mainTextureOffset += _offset;
    }
}
