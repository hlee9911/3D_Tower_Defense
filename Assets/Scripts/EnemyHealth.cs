using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHP = 5;
    [SerializeField, Tooltip("Adds amount to maxHP when enemy dies.")] private int difficultyRamp = 1;
    [SerializeField] private int currentHP = 0;

    private Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            maxHP += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
