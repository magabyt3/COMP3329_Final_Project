using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] Sprite[] cyberPolices;
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 4;

    Vector2 _startPosition;
    Rigidbody2D _rigidBody2D;
    SpriteRenderer _spriteRenderer;
    public Sprite _currentSprite;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _spriteRenderer.sprite = cyberPolices[Random.Range(0, cyberPolices.Length)];
        _currentSprite = _spriteRenderer.sprite;
        _startPosition = _rigidBody2D.position;
        _rigidBody2D.isKinematic = true;
    }

    void Update()
    {
        //transform.Rotate(0, 0, 1f);
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.white;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = _rigidBody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidBody2D.isKinematic = false;
        _rigidBody2D.AddForce(direction * _launchForce);
        _spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        // Can't drag ball to the right
        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidBody2D.position = desiredPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _spriteRenderer.sprite = cyberPolices[Random.Range(0, cyberPolices.Length)];
        _currentSprite = _spriteRenderer.sprite;
        _rigidBody2D.position = _startPosition;
        _rigidBody2D.isKinematic = true;
        _rigidBody2D.velocity = Vector2.zero;
    }

}
