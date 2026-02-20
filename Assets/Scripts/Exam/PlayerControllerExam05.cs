using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;
    private int currentBullet;
    private bool isReloading = false;
    private float reloadTimer = 0f;
    // ...

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        currentBullet = maxBulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.WasPressedThisFrame() && !isReloading)
        {
            if (currentBullet > 0)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                currentBullet--;

                if (currentBullet <= 0 && !isReloading)
                {
                    isReloading = true;
                    reloadTimer = bulletRegenerateCooldown;
                }
                if (isReloading)
                {
                    reloadTimer -= Time.deltaTime;

                    if (reloadTimer <= 0f)
                    {
                        currentBullet = maxBulletCount;
                        isReloading = false;
                    }
                }
            }
        }
    }
}
