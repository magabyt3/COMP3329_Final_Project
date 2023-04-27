using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    SpriteRenderer _spriteRenderer;
    bool _hasDied;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
            return false;
        

        // New script for balls
        BirdController bc = collision.gameObject.GetComponent<BirdController>();
        Monster monster = collision.otherCollider.gameObject.GetComponent<Monster>();

        if (bc != null)
        {
            if (bc._currentSprite.name == "MalwarePolice" && monster.name.Contains("MonsterBlue"))
                return true;

            if (bc._currentSprite.name == "VPNPolice" && monster.name.Contains("MonsterGreen"))
                return true;

            if (bc._currentSprite.name == "TwoFactAuthPolice" && monster.name.Contains("MonsterOrange"))
                return true;

            if (bc._currentSprite.name == "SoftwareUpdatePolice" && monster.name.Contains("MonsterPink"))
                return true;

            return false;
        }

        // Box falling in from above
        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }

    IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
