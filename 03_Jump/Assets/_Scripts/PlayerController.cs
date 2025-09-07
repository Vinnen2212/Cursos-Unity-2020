using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    

    //Variables
    private Rigidbody playerRB;
    public float jumpForce;

    public bool isOnTheGround = true;
    private bool _gameOver = false; 
    public bool GameOver { get => _gameOver; }
    private Animator _animator;
    const string SPEEDMULTIPLIER = "Speed Multiplier";
    private const string JUMPTRIGGER = "Jump_trig";
    private const string DEATHTYPE_INT = "DeathType_int";
    private const string DEATH_B = "Death_b";
    public ParticleSystem explosion;
    public ParticleSystem dust;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0,1)]
    public float soundVolume = 1;
    private float speedMultiplier = 1;

    // Start is called before the first frame update

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
 

    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime / 10;
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultiplier);
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !GameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            _animator.SetTrigger(JUMPTRIGGER);
            dust.Stop();
            _audioSource.PlayOneShot(jumpSound, soundVolume);

           
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!_gameOver)
            {
                isOnTheGround = true;
                dust.Play();
            }
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            _audioSource.PlayOneShot(crashSound, soundVolume);
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATHTYPE_INT, Random.Range(1, 3));
            _gameOver = true;
            dust.Stop();
            explosion.Play();
            Debug.Log("GAME OVER!!!!");
            Invoke("RestartGame", 2f);
        }
        
    }

    void RestartGame()
    {
        
        SceneManager.LoadScene("Prototype 3");
    }
}
