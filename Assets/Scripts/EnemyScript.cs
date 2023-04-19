using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform Player;
    public int EnemyHp = 2;
    private int CurrentHp;

    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        CurrentHp = EnemyHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            navAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);
        }
    }

    public void TakeDamage(int Damage)
    {
        EnemyHp -= Damage;
        CurrentHp = EnemyHp;
        
        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
            UICounter.inst.NotifEnemyDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Debug.Log("Damage Taken");
        }
    }
}
