using UnityEngine;
using TMPro;

public class numbers : MonoBehaviour
{
    int _min, _max, _value, _guess;
    public TMP_Text myText;
    void Start()
    {
        _min = 0;
        _max = 1000;
        valueTextUpdate();
    }

    void Update()
    {

    }
    public void greater()
    {
        _min = _value;
        valueTextUpdate();
    }
    public void smaller()
    {
        _max = _value;
        valueTextUpdate();
    }
    public void valueTextUpdate()
    {
        _value =Random.Range(_min, _max);
        myText.text = _value.ToString();
    }
}
