using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBall : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireBall", lifetime);
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();


    }


    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireBall();

        DamageEnemy(collision);


    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);

        }
    }
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
