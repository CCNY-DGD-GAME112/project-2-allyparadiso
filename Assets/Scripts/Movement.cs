using System.Collections;

using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    public Transform target;
    public int currentHealth;
    private Rigidbody rb;
    public int attackDamage = 1;
    public int maxHealth = 5;
    public float nextDamageTime;
    public float damageCooldown = 2f;
    public Vector3 currentDirection;
    public float speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        StartCoroutine(Walk(target));

    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.005f);
    }
    public IEnumerator Walk(Transform target)
    {

        
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            
            transform.position = Vector3.Lerp(transform.position, target.position, 0.005f);
            yield return null;
        }
        
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AddKill();
        }
        Destroy(gameObject);
    }
    
    private void OnCollisionStay(Collision collision)
    {
        
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            FirstPersonController health = otherGameObject.GetComponent<FirstPersonController>();
            health.TakeDamage();
            nextDamageTime = Time.time + damageCooldown;
        }
    }
}
