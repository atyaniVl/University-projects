using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _creditsText;
    TextMeshProUGUI _TextClone;
    void Start()
    {
        InvokeRepeating("textSpawn", 0, 1);
    }

    public void textSpawn()
    {
        _TextClone = Instantiate(_creditsText,new Vector3(transform.position.x - 200, -5,0), Quaternion.identity);
        _TextClone.transform.SetParent(gameObject.transform);
    }
}
