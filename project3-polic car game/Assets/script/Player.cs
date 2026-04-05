using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource _audio;
    AudioSource _cameraAudio;
    UImanager _UI;
    SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite _carDes;
    [SerializeField] AudioClip _winSound;
    [SerializeField] AudioClip _loseSound;
    [SerializeField] AudioClip _explosionSound;
    [SerializeField] AudioClip _shootingSound;
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _bulletEmpty;
    [SerializeField] float _shootAter;
    [SerializeField] int _health;
    [SerializeField] int _goal;
    float _nextShoot;
    int _score;
    bool _pauseActive;
    void Start()
    {
        Time.timeScale = 1.0f;

        _UI = GameObject.Find("UI manager").GetComponent<UImanager>();
        if(_UI == null)
            Debug.LogError("player => UI manager in null");
        _audio = GetComponent<AudioSource>();
        if (_audio == null)
            Debug.LogError("player => audio source is null");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
            Debug.LogError("player => sprite renderer is null");
        _cameraAudio=GameObject.Find("Main Camera").GetComponent<AudioSource>();

        transform.position = new Vector3(0, -3, 0);
    }

    void Update()
    {
        movement();
        windowsShoot();
        pauseMenu();
    }

    void movement()
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                turnRight();
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                turnLeft();
            /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                drive();
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                revers();*/
        }
    public void turnRight()
    {
        if(transform.position.x < 1.4f)
            transform.position = new Vector3(transform.position.x + 1.4f,transform.position.y,0);
    }
    public void turnLeft()
    {
        if(transform.position.x > -1.4f)
            transform.position = new Vector3(transform.position.x - 1.4f, transform.position.y, 0); 
    }
    /*void drive()
    {
        if (transform.position.y <= 3.9f)
            transform.Translate(Vector3.up * Time.deltaTime * 10);
    }
    void revers()
    {
        if (transform.position.y >= -3.9f)
            transform.Translate(Vector3.down * Time.deltaTime * 10);
    }*/
    public void windowsShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            shoot();
    }
    public void shoot()
    {
        if (Time.time >= _nextShoot)
        {
            _audio.PlayOneShot(_shootingSound);
            Instantiate(_bullet, _bulletEmpty.transform.position, Quaternion.identity);
            _nextShoot = Time.time + _shootAter;
        }
    }
    public void damage(int damageDec)
    {
        _health-=damageDec;
        print(_health);
        _UI.healthUpdate(_health);
        if(_health<=0)
        {
            _spriteRenderer.sprite = _carDes;
            _audio.PlayOneShot(_loseSound);
            _UI.win_lose_display(false);
            print("player died");
            Time.timeScale = 0;
        }
    }
    public void addScore()
    {
        _score++;
        _UI.scoreUpdate(_score);
        if(_score>=_goal)
        {
            Time.timeScale = 0;
            _UI.win_lose_display(true);
            _audio.PlayOneShot(_winSound);
        }
    }
    public void pauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pauseActive==false)
        {
            _pauseActive = true;
            _UI.pauseActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _pauseActive == true)
        {
            _pauseActive = false;
            _UI.pauseActive(false); 
            Time.timeScale = 1.0f;
        }
    }
    public void mobilePauseMenuOn()
    {
        _pauseActive = true;
        _UI.pauseActive(true);
        _cameraAudio.Pause();
        Time.timeScale = 0;
    }
    public void mobilePauseMenuOff() 
    {
        _pauseActive = false;
        _UI.pauseActive(false);
        _cameraAudio.Play();
        Time.timeScale = 1.0f;
    }
}
