using UnityEngine;

public class Ball : MonoBehaviour
{
    //config para
    [SerializeField] Paddle paddle1;
    [SerializeField] float X_push = 2f;
    [SerializeField] float Y_push = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.3f;
    //state
    Vector2 PaddleToBallVector;
    bool Lunched = false;
    //Cached component
    AudioSource myAudioSource;
    Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        PaddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Lunched)
        {
            LockBallToPaddle();
            LunchOnMouseClick();
        }
        
    }

    private void LunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody2D.velocity = new Vector2(X_push, Y_push);
            Lunched = true;

        }
    }

    private void LockBallToPaddle()
    {
        Vector2 PaddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = PaddleToBallVector + PaddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomVelocity = new Vector2
            (Random.Range(0,randomFactor),
            Random.Range(0,randomFactor));
        if (Lunched)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            rigidBody2D.velocity += randomVelocity;
        }
    }
}
  