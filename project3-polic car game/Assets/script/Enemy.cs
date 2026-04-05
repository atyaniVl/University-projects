using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip _explosion;
    [SerializeField] Sprite _explosionImage;
    SpriteRenderer _spriteRenderer;
    AudioSource _audio;
    Player _player;
    Collider2D _collider2D;
    float _speed = 5;
    void Start()
    {
        _player = GameObject.Find("Car").GetComponent<Player>();
        if (_player == null)
            Debug.LogError("enemy => player is null");
        _audio = GetComponent<AudioSource>();
        if (_audio == null)
            Debug.LogError("enemy => audio source is null");
        _collider2D = GetComponent<Collider2D>();
        if (_collider2D == null)
            Debug.LogError("enemy => collider is null");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
            Debug.LogError("enemy => sprite renderer is null");
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime*_speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (this.tag == "Enemy" || this.tag =="BigEnemy")
            {
                _player.addScore();
                Destroy(other.gameObject);
            }
        }
        else if(other.tag == "Player")
        {
            if(this.tag == "Enemy")
                _player.damage(1);
            else if (this.tag == "BigEnemy")
                _player.damage(2);
        }
        _spriteRenderer.sprite = _explosionImage;
        transform.localScale = transform.localScale * 0.3f;
        _audio.PlayOneShot(_explosion);
        _collider2D.enabled = false;
        Destroy(this.gameObject,2);

    }
}
