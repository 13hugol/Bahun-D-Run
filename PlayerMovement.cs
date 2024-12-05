using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioClip Coin, Jump, DeathSound, StartGameSound; 
    [SerializeField] private DistanceCounter distanceCounter; 
    private float distanceTraveled=0f;
    private Vector3 lastPosition; // To store the player's last position for distance calculation


    private Animator animator;
    private bool hasPlayedDeathSound = false;
    private Rigidbody m_rigidbody;
    private AudioSource m_audioSource;

    public static int CurrentTile = 0;
    public static bool IsFlying = false;
    [SerializeField] private GameObject Wings;
    [SerializeField] private GameObject StartScreen, UI_SCREEN;
    [SerializeField] private TextMeshProUGUI Inv_coins;

    private int INV_COINS;

    public void StartGame()
    {
        hasPlayedDeathSound = false;
        UI_SCREEN.SetActive(true);
        StartScreen.SetActive(false);
        animator.SetBool("Run", true);
        m_audioSource.PlayOneShot(StartGameSound); // Play starting sound
    }

    void Start()
    {
        INV_COINS = PlayerPrefs.GetInt("InventoryCoins");
        Inv_coins.text = INV_COINS.ToString();
        animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        lastPosition = transform.position;  // Initialize last position to the player's starting position
        m_audioSource = GetComponent<AudioSource>();
    }

    private int Next_X_POS;
    private bool Left, Right;
    private Vector2 TouchBegan, TouchMove;
    private float DRAG_X, DRAG_Y;
    private bool CanDrag;
    private bool isJumpDown = false;
    private int CoinsCollected;

    void Update()
    {
        HandleTouchInput();
        HandleKeyboardInput();
        // Distance calculation
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position; // Update last position


        if (animator.GetBool("FALL_DEAD") || animator.GetBool("DEAD"))
        {
             if (!hasPlayedDeathSound) // Ensure sound plays only once
        {
            hasPlayedDeathSound = true;
            m_audioSource.PlayOneShot(DeathSound); // Play death sound
            StartCoroutine(ShowGameOverMenu());
            PlayerPrefs.SetInt("InventoryCoins", CoinsCollected + INV_COINS);
            PlayerPrefs.SetInt("CoinsCollected", CoinsCollected);
        }
        }
        else
        {
            hasPlayedDeathSound = false; // Reset the flag if the player is not dead
        }

        if (IsFlying && !animator.GetBool("FLYING"))
        {
            animator.SetBool("Slide", false);
            animator.SetBool("Jump", false);
            m_rigidbody.useGravity = false;
            animator.SetBool("FLYING", true);
        }
        if (animator.GetBool("Jump"))
        {
        animator.SetBool("Slide", false); // Prevent slide if jumping
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CanDrag = true;
                TouchBegan = touch.position;
                TouchMove = Vector2.zero;
            }
            else if (touch.phase == TouchPhase.Moved && CanDrag)
            {
                TouchMove = touch.position;
                DRAG_X = Mathf.Abs(TouchBegan.x - TouchMove.x);
                DRAG_Y = Mathf.Abs(TouchBegan.y - TouchMove.y);

                if (DRAG_Y > DRAG_X)
                {
                    // Swipe up
                    if (TouchMove.y > TouchBegan.y)
                    {
                        CanDrag = false;
                        if (!animator.GetBool("FLYING"))
                        {
                            m_audioSource.PlayOneShot(Jump);
                            isJumpDown = false;
                            m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
                            animator.SetBool("Slide", false);
                            animator.SetBool("Left", false);
                            animator.SetBool("Right", false);
                            animator.SetBool("Jump", true);
                        }
                    }
                    // Swipe down
                    else
                    {
                        CanDrag = false;
                        if (!animator.GetBool("FLYING") && !animator.GetBool("Jump"))
                        {
                            animator.SetBool("Jump", false);
                            animator.SetBool("Slide", true);
                        }
                    }
                }
                else if (DRAG_X > DRAG_Y)
                {
                    // Right
                    if (TouchMove.x > TouchBegan.x)
                    {
                        CanDrag = false;
                        HandleMovement("Right");
                    }
                    // Left
                    else
                    {
                        CanDrag = false;
                        HandleMovement("Left");
                    }
                }
            }
        }
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UI_SCREEN.SetActive(true);
            StartScreen.SetActive(false);
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) && !animator.GetBool("FLYING") && !animator.GetBool("Jump"))
        {
            animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) && !animator.GetBool("FLYING"))
        {
            m_audioSource.PlayOneShot(Jump);
            isJumpDown = false;
            m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
            animator.SetBool("Slide", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            HandleMovement("Right");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            HandleMovement("Left");
        }
    }

    private void HandleMovement(string direction)
    {
        if (direction == "Right")
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
                animator.SetBool("Right", true);
            else
                Right = true;

            if (m_rigidbody.position.x >= -3 && m_rigidbody.position.x < -1)
            {
                Next_X_POS = 0;
            }
            else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_X_POS = 2;
            }
        }
        else if (direction == "Left")
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
                animator.SetBool("Left", true);
            else
                Left = true;

            if (m_rigidbody.position.x >= 1 && m_rigidbody.position.x < 3)
            {
                Next_X_POS = 0;
            }
            else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_X_POS = -2;
            }
        }
    }

    void ToggleOff(string Name)
    {
        animator.SetBool(Name, false);
        isJumpDown = false;
    }

    void JumpDown()
    {
        isJumpDown = true;
    }

    private void OnAnimatorMove()
{
    if (animator.GetBool("FALL_DEAD"))
    {
        m_rigidbody.MovePosition(m_rigidbody.position + Vector3.down * animator.deltaPosition.magnitude);
    }
    else if (animator.GetBool("FLYING"))
    {
        m_rigidbody.velocity = Vector3.zero;
        if (!IsFlying)
        {
            if (m_rigidbody.position.y > 2)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, -1.5F, 1) * animator.deltaPosition.magnitude);
            else
            {
                Wings.SetActive(false);
                animator.SetBool("FLYING", false);
            }
        }
        else if (m_rigidbody.position.y < 10)
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 3, 2.5F) * animator.deltaPosition.magnitude);
        else
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 2.5F) * animator.deltaPosition.magnitude);
    }
    else if (animator.GetBool("Jump"))
    {
        if (isJumpDown)
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 2) * animator.deltaPosition.magnitude);
        else
        {
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 1.5f, 2) * animator.deltaPosition.magnitude);
        }
    }
    else if (animator.GetBool("Right"))
    {
        if (m_rigidbody.position.x <= Next_X_POS)
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(2f, 0, 1.5f) * animator.deltaPosition.magnitude);
        else
        {
            m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
            animator.SetBool("Right", false);
        }
    }
    else if (animator.GetBool("Left"))
    {
        if (m_rigidbody.position.x >= Next_X_POS)
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(-2f, 0, 1.5f) * animator.deltaPosition.magnitude);
        else
        {
            m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
            animator.SetBool("Left", false);
        }
    }
    else
        m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 1.5f) * animator.deltaPosition.magnitude);

    if (Left)
    {
        if (m_rigidbody.position.x > Next_X_POS)
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(-1, 0, 0) * animator.deltaPosition.magnitude);
        else
            Left = false;
    }
    else if (Right)
    {
        if (m_rigidbody.position.x < Next_X_POS)
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(1, 0, 0) * animator.deltaPosition.magnitude);
        else
            Right = false;
    }

    // Calculate distance correctly
    distanceTraveled += Vector3.Distance(transform.position, lastPosition); // Fix the distance calculation
    lastPosition = transform.position; // Update last position
}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("OBS"))
        {
            animator.SetBool("DEAD", true);
        }
    }

    [SerializeField] private GameObject Camera_obj;
    [SerializeField] private TextMeshProUGUI CoinsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FALL_DAMAGE"))
        {
           animator.SetBool("FALL_DEAD", true);
        }
        else if (other.CompareTag("DISABLE FLY"))
        {
            IsFlying = false;
            m_rigidbody.useGravity = true;
            Wings.SetActive(false);
            animator.SetBool("FLYING", false);
        }
        else if (other.CompareTag("Coins"))
        {
            m_audioSource.PlayOneShot(Coin);
            CoinsCollected++;
            CoinsText.text = CoinsCollected.ToString();
        }
    }

    IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds
    PlayerPrefs.SetInt("InventoryCoins", CoinsCollected + INV_COINS);
    PlayerPrefs.SetInt("CoinsCollected", CoinsCollected);

    // Save the distance traveled
    PlayerPrefs.SetFloat("DistanceTraveled", distanceTraveled);

    SceneManager.LoadScene("GAME_OVER_SCREEN");
    }
}