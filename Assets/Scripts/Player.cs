using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int velocidade = 10;
    int velocidadePulo = 9;
    public static int Moedas;
    public static float Timer;
    public static float BestTimer1 = 100000, BestTimer2 = 100000;

    bool isGrounded = false;
    float groundCheckRadius = 0.2f;

    public GameObject canvas;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask GroundType;

    Animator PlayerAnim;
    Rigidbody2D Rig;

    public static int ActualScene;
 
    AudioSource audioSource;
    public AudioClip AudioCoin, AudioEndGame, AudioEndPhase, AudioGameOver, AudioInterface;

    Vector3 PosicaoInicial;

    void Start()
    {
        ActualScene = SceneManager.GetActiveScene().buildIndex;
        PosicaoInicial = transform.position;

        Time.timeScale = 1;

        audioSource = GetComponent<AudioSource>();
        PlayerAnim = GetComponent<Animator>();
        Rig = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Timer += Time.deltaTime;

        float InputMove = Input.GetAxis("Horizontal");

        if (InputMove < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);

        if (InputMove > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        if (InputMove == 0)
        {
            PlayerAnim.SetBool("isRunning", false);
        }
        else if (InputMove != 0 && PlayerAnim.GetBool("Jumped") == false)
        {
            PlayerAnim.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            Jump();

        if (Input.GetButtonDown("Cancel"))
        {
            AbrirMenu();
        }
    }

    public void AbrirMenu()
    {
        audioSource.PlayOneShot(AudioInterface);
        canvas.GetComponent<HUD>().ActivePanelMenu();
    } 

    public void VoltarMenu()
    {
        audioSource.PlayOneShot(AudioInterface);
        SceneManager.LoadScene(0);
        PlayerPrefs.SetFloat("lastTimeLvl1", 0);
        PlayerPrefs.SetFloat("lastTimeLvl2", 0);
    }

    private void FixedUpdate()
    {
        MovePlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundType);

        if (isGrounded == true)
        {
            PlayerAnim.SetBool("Jumped", false);
        }
        else if (isGrounded == false)
        {
            PlayerAnim.SetBool("Jumped", true);
            PlayerAnim.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {      
        Rig.AddForce(Vector2.up * velocidadePulo, ForceMode2D.Impulse);
    }

    private void MovePlayer()
    {
        Rig.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, Rig.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Morrer();
        }       
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(AudioCoin);
            Moedas++;
            Destroy(trigger.gameObject);
        }

        if (trigger.gameObject.tag == "Checkpoint")
        {
            PosicaoInicial = gameObject.transform.position;
        }

        if (trigger.gameObject.tag == "EnemyHead")
        {
            Destroy(trigger.transform.parent.gameObject);
            Rig.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
        }

        if (trigger.gameObject.tag == "NextLevel" && HaveCoins() == false)
        {           
            audioSource.PlayOneShot(AudioEndPhase);
            SceneManager.LoadScene(ActualScene + 1);
            GameObject.FindWithTag("MainCamera").GetComponent<SetVolume>().SetBestTime();
        }

        if (trigger.gameObject.tag == "NextAdditiveLevel")
        {
            audioSource.PlayOneShot(AudioEndPhase);
            SceneManager.LoadScene(ActualScene + 1, LoadSceneMode.Additive);
            ActualScene += 1;
        }

        if (trigger.gameObject.tag == "EndGame" && HaveCoins() == false)
        {
            audioSource.PlayOneShot(AudioEndGame);
            SceneManager.LoadScene(4);
            GameObject.FindWithTag("MainCamera").GetComponent<SetVolume>().SetBestTime();
        }

        if (trigger.gameObject.tag == "Fall")
        {
            Morrer();
        }
    }

    private bool HaveCoins()
    {
        if (GameObject.FindGameObjectWithTag("Coin") == false)
        {
            return false;
        }
        else return true;
    }

    private void Morrer()
    {
        audioSource.PlayOneShot(AudioGameOver);
        transform.position = PosicaoInicial;
    }
}
