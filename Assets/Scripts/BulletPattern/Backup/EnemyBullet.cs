using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed = 5f;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed *Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
