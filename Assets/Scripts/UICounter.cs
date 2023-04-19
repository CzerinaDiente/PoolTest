using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{
    public static UICounter inst;
    public int enemiesKilled;
    public TMP_Text counter;
    bool ifReached30 = false;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        counter.text = "Kills: " + enemiesKilled;
    }

    public void NotifEnemyDeath()
    {
        enemiesKilled++;
        counter.text = "Kills: " + enemiesKilled;
        Debug.Log("Enemy Killed: "+enemiesKilled);
        if (enemiesKilled >= 30 && !ifReached30)
        {
            Invoke("HpNotif", 0.2f);
            ChangeEnemyHP();
        }
    }

    private void ChangeEnemyHP()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemies in Enemy)
        {
            EnemyScript unit = enemies.GetComponent<EnemyScript>();
            unit.EnemyHp = 3;
        }
    }

    private void HpNotif()
    {
        Debug.Log("Enemy hp is now 3");
    }
}
