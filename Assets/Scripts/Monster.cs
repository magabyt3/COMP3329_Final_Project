using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    bool _hasDied;

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

        Bird bird = collision.gameObject.GetComponent<Bird>();
        Monster monster = collision.otherCollider.gameObject.GetComponent<Monster>();

        if (bird != null)
        {
            if (bird.name == "MalwarePolice" && monster.name.Contains("MonsterBlue"))
                return true;

            if (bird.name == "VPNPolice" && monster.name.Contains("MonsterGreen"))
                return true;

            if (bird.name == "TwoFactorAuthPolice" && monster.name.Contains("MonsterOrange"))
                return true;

            if (bird.name == "SoftwareUpdatePolice" && monster.name.Contains("MonsterPink"))
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
