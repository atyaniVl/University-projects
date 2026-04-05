using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] Image _winImage;
    [SerializeField] Image _loseImage;
    [SerializeField] Image _pauseImage;
    [SerializeField] GameObject _btnsParent;
    [SerializeField] TextMeshProUGUI _scoreTXT;
    [SerializeField] TextMeshProUGUI _healthTXT;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        setActiveRecursivly(_winImage.transform, false);
        setActiveRecursivly(_loseImage.transform, false);
        setActiveRecursivly(_pauseImage.transform, false);
    }
    public void setActiveRecursivly(Transform parent,bool activeState)
    {
        parent.gameObject.SetActive(activeState);
        foreach(Transform child in parent)
            setActiveRecursivly(child, activeState);
    }
    public void setButtonsActive(Transform btnParent,bool activeState) 
    {
        if(btnParent.GetType()==typeof(Button))
            btnParent.gameObject.SetActive(activeState);
        foreach (Transform child in btnParent)
            setButtonsActive(child, activeState);

    }
    public void game_btn_active(bool state)
    {
        setButtonsActive(_btnsParent.transform, state);
    }
    public void win_lose_display(bool state) // false => died, true =>win
    {
        if (state)
        {
            setActiveRecursivly(_winImage.transform, true);
        }
        else
        {
            setActiveRecursivly(_loseImage.transform, true);
        }
        game_btn_active(state);
    }
    public void scoreUpdate(int score) 
    {
        _scoreTXT.text = score.ToString();
    }
    public void healthUpdate(int health)
    {
        _healthTXT.text = health.ToString();
    }
    public void pauseActive(bool state)
    {
        _audioSource.Pause();
        setActiveRecursivly(_pauseImage.transform, state);
        game_btn_active(!state);
    }
}
