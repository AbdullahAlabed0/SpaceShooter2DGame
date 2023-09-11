using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MainPlayerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject bulletPrefap;
    public GameObject bulletSpawnerPoint;

    public Transform leftBoarder, rightBoarder;



    SpriteRenderer spriteRenderer;

    public Color flashColor = Color.red;
    public float flashDuration = 0.5f;
    public int flashCount = 5;

    void Start()
    {
        // Assuming you've assigned the SpriteRenderer in the Inspector
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        // on click on right arrow// the player moves to the right
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // enable movement until the spaceship reach the right boarder
            if (transform.position.x <= rightBoarder.position.x)
            {
                moveSpaceship();
            }
            else
            {
                // reenable movement to the left only 
                if (Input.GetAxis("Horizontal") <= -0.1f)
                {
                    moveSpaceship();
                }
            }
        }
        // click on left arrow
        else if (Input.GetAxis("Horizontal") <= -0.1f)
        {

            // enable movement until the spaceship reach the left boarder
            if (transform.position.x >= leftBoarder.position.x)
            {
                moveSpaceship();
            }
            else
            {
                // reenable movement to the right only 
                if (Input.GetAxis("Horizontal") >= 0.1f)
                {
                    moveSpaceship();
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefap, bulletSpawnerPoint.transform.position, Quaternion.identity);
        }

      
    }


    void moveSpaceship()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
    }
    
      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Bullet")
        {
            Destroy(collision.gameObject);//bullet
            Debug.Log("FlashSprite");
            UI_Manager.instance.DecreasePlayerLives();
            FlashSprite();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);//bullet
            Debug.Log("FlashSprite");
            UI_Manager.instance.DecreasePlayerLives();
            FlashSprite();
        }

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);//bullet
            UI_Manager.instance.keysCounter++;
        }
    }
    
    void FlashSprite(int count =2)
    {
        if (count <= 0)
            return;

        // Toggle the color
        spriteRenderer.DOColor(flashColor, flashDuration).OnComplete(() =>
        {
            spriteRenderer.DOColor(Color.white, flashDuration).OnComplete(() =>
            {
                // Recursively call FlashSprite with one less count
                FlashSprite(count - 1);
            });
        });
    }

    void OnFlashComplete()
    {
        // Do something when flashing is complete (if needed)
    }
}
