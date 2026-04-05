using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Bird : MonoBehaviour
{
    Rigidbody2D _rb2D;
    SpawnManager _spawnManager;
    AudioSource _audioSource;
    [SerializeField] AudioClip _hitting;
    [SerializeField] AudioClip _dead;
    [SerializeField] AudioClip _win;
    [SerializeField] AudioClip _coin;
    [SerializeField] TextMeshProUGUI _scoreTMP;
    [SerializeField] TextMeshProUGUI _healTMP;
    [SerializeField] int _goal;
    [SerializeField] int _heal;
    int _score;
    bool _isPlayerDead = false;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        if (_rb2D == null)
            Debug.LogError("player => rigid body is null");

        _spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        if (_spawnManager == null)
            Debug.LogError("player => spawner is null");

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogError("player => audio source is null");

        transform.position = Vector3.zero;
        _rb2D.gravityScale = 1.8f;
        _heal = 3;
        _healTMP.text = _heal.ToString();
        _goal = 20;
    }

    void Update()
    {
        playerMovement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacles"))
            if(_heal>1)
            {
                _audioSource.PlayOneShot(_hitting);
                //add blood effects
                _heal--;
                _healTMP.text = _heal.ToString();
            }
            else
            {
                _heal--;
                _audioSource.PlayOneShot(_hitting);
                _healTMP.text = _heal.ToString();
                playerDeath();
            }
        if (collision.CompareTag("score"))
        {
            scoreController();
            Destroy(collision.gameObject);
            if (_score == _goal)
                playerWin();
        }
    }
    public void playerMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButtonDown(0))
            _rb2D.AddForce(Vector2.up * 400);
        if (transform.position.y <= -5 || transform.position.y >= 5) //you can use the mathf.clamp method to make a limites of y value
            playerDeath();

    }
    public void scoreController()
    {
        _audioSource.PlayOneShot(_coin);
        _score++;
        _scoreTMP.text = _score.ToString();
    }
    public void playerDeath()
    {
        if(_isPlayerDead == false)
            _audioSource.PlayOneShot(_dead);
        _isPlayerDead = true;
        _spawnManager.stopSpawner();
        _rb2D.gravityScale = 4;
        StartCoroutine(delay(2.5f,2));
    }
    public void playerWin()
    {
        _audioSource.PlayOneShot(_win);
        _spawnManager.stopSpawner();
        StartCoroutine(delay(1.9f,3));
    }
    IEnumerator delay (float timeDelay,int sceneIndex)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneIndex);
    }
}
