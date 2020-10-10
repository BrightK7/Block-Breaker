using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSoud;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] HitSptites;
    //Cached reference
    Level level;
    //state variable
    [SerializeField] int hitTimes; //TODO Serialized for Debug purpose
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
        else if (tag == "Special")
        {
            HandleSpecial();
            HandleHit();
        }
    }

    private void HandleSpecial()
    {
        FindObjectOfType<Paddle>().UpdatePaddleWidth(2f);
    }

    private void ShowNextSprite()
    {
        int spriteIndex = hitTimes - 1;
        if (HitSptites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSptites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name+"spriteIndex is not right");
        }
    }

    private void HandleHit()
    {
        int MaxHits = HitSptites.Length + 1;
        hitTimes++;
        if (hitTimes >= MaxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void DestroyBlock()
    {
        PlayBreaksoundAndAddScore();
        Destroy(gameObject);
        level.DecreaseBrealableBlocks();
        TriggerSparklesVFX();
    }

    private void PlayBreaksoundAndAddScore()
    {
        FindObjectOfType<GameSession>().AddToSore();
        AudioSource.PlayClipAtPoint(breakSoud, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
 