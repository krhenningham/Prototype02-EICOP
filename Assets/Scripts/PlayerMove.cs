using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public int score = 0;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 moveDirection;
    public Text keyAmount;
    public GameObject door;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("hopefully running");
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 

        keyAmount.text = "Keys : " + score.ToString();

        if (score == 6)
        {
            Destroy(door);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            score++;
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("LoseScreen");
        }

        if (collision.gameObject.tag == "WinSquare")
        {
            SceneManager.LoadScene("WinScreen");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
