using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // health
    public int maxHealth = 5;
    // temps d'invincibilité
    public float timeInvincible = 2.0f;
    // variable qui va servir a déterminé si on est invincible
    bool isInvincible;
    // variable qui va prendre le temps d'invincibilité
    float invincibleTimer;
    public int health { get { return currentHealth; }}
    int currentHealth;

    // speed
    public float speed = 3.0f;

    // deplacement
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // si on est invincible
           if (isInvincible)
        {
            // on enleve le deltatime a l'invincible timer 
            invincibleTimer -= Time.deltaTime;
            // si l'invincibletimer tombe sous 0
            if (invincibleTimer < 0)
            // on est plus invincible
                isInvincible = false;
        }
    }

    // update position
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    // update life
    public void ChangeHealth(int amount)
    {
        // si on prend des degats 
         if (amount < 0)
        {
            // si on est invincible
            if (isInvincible)
            // fin de la fonction
                return;
            // on est invincible
            isInvincible = true;
            // on attribut le temps d'invincibilité a notre variuable invincible timer 
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        
    }

    /*  public int getCurrentHealth(){
            return currentHealth;
        }
    */
}