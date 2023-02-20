using UnityEngine;


public class Invader : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public Sprite[] animationSprites;

    public float animationTime = 1f;

    private int _animationFrame;

    public System.Action killed;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

       
        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fire"))
        {
            Score.scoreValue += 100;
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(3);
        }
    }
   

}
