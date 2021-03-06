﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public Character[] playerCharacters;
   public Character[] enemyCharacters;
   Character currentTarget;
   public SummaryMenu summary;
    public bool isWinner=false;
    public bool waitForPlayer=true;
    public Animator attackBtn;
    public Button animbtn;
   
    [ContextMenu ("PlayerMove")]

   public void PlayerMove()
    {
        if (waitForPlayer)
           waitForPlayer = false;
    }
    [ContextMenu("Switch character")]
    public void SwitchCharacter()
    {
        for (int i = 0; i < enemyCharacters.Length; i++)
        {
            // Найти текущего персонажа (i = индекс текущего)
            if (enemyCharacters[i] == currentTarget)
            {
                int start = i;
                ++i;
                // Идем в сторону конца массива и ищем живого персонажа
                for (; i < enemyCharacters.Length; i++)
                {
                    if (enemyCharacters[i].isDead())
                        continue;

                    // Нашли живого, меняем currentTarget
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
                    currentTarget = enemyCharacters[i];
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

                    return;
                }
                // Идем от начала массива до текущего и смотрим, если там кто живой
                for (i = 0; i < start; i++)
                {
                    if (enemyCharacters[i].isDead())
                        continue;

                    // Нашли живого, меняем currentTarget
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
                    currentTarget = enemyCharacters[i];
                    currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

                    return;
                }
                // Живых больше не осталось, не меняем currentTarget
                return;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        attackBtn = animbtn.GetComponent<Animator>();
        StartCoroutine(GameLoop());
    }
   
    public void PlayerWon()
    {
        
        isWinner = true;
        summary.SetResult(isWinner);
        Debug.Log("Playere won");
    }

    public void PlayerLost()
    {
        isWinner = false;
        summary.SetResult(isWinner);
        Debug.Log("Playere lost");
    }

    Character FirstAliveChat(Character[] chars)
    {
        foreach (var character in chars)
        {
            if (!character.isDead())
            {
                return character;
            }
        }
        return null;
    }

    public bool CheckEndGame()
    {
        if (attackBtn.GetBool("isWaiting"))
        {
            attackBtn.SetBool("isWaiting",false);
        }
        if (FirstAliveChat(playerCharacters)==null)
        {
            PlayerLost();
            return true;
        }
        if (FirstAliveChat(enemyCharacters) == null)
        {
            PlayerWon();
            return true;
        }

        
        
        return false;
    }
    IEnumerator GameLoop()
    {
        while (!CheckEndGame())
        {
            foreach (var player in playerCharacters)
            {
                if (player.isDead())
                    continue;

                    Character target = FirstAliveChat(enemyCharacters);
                    if (target==null)
                      break;

                currentTarget = target;
                currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);


                waitForPlayer = true;
                attackBtn.SetBool("isWaiting",true);
                while (waitForPlayer)
  
                    yield return null;
                   
                attackBtn.SetBool("isWaiting",false);
                currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);

                player.targetCharacter = currentTarget;
                player.AttackEnemy();
                while (!player.isIdle())
                   yield return null;
               
            }

            foreach (var enemy in enemyCharacters)
            {
                if (enemy.isDead())
                    continue;

                Character target = FirstAliveChat(playerCharacters);
                if (target == null)
                    break;

                enemy.targetCharacter = target;

                enemy.AttackEnemy();
                while (!enemy.isIdle())
                    yield return null;

            }

            yield return null;
        }
     
    }
  
}
