using UnityEngine;

public class steal : MonoBehaviour
{
    public Transform player;
    public Transform escapePoint;

    public float chaseSpeed = 3f;
    public float runSpeed = 6f;
    public float stealRange = 2f;
    public float stealCooldown = 3f;

    private pickup playerPickup;

    private GameObject heldItem;
    private bool hasItem;
    private float cooldown;

    void Start()
    {
        playerPickup = player.GetComponent<pickup>();
    }

    void Update()
    {
        if (cooldown > 0f)
            cooldown -= Time.deltaTime;

        if (!hasItem)
        {
            ChasePlayer();
            TrySteal();
        }
        else
        {
            RunAway();
            CarryItem();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }

    void TrySteal()
    {
        if (cooldown > 0f) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= stealRange && playerPickup != null)
        {
            GameObject item = playerPickup.GetHeldObject();

            if (item != null)
            {
                playerPickup.ForceDrop();
                Grab(item);

                cooldown = stealCooldown;
            }
        }
    }

    void Grab(GameObject item)
    {
        heldItem = item;
        hasItem = true;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;
    }

    void RunAway()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            escapePoint.position,
            runSpeed * Time.deltaTime
        );
    }

    void CarryItem()
    {
        if (heldItem == null) return;

        heldItem.transform.position = transform.position + Vector3.up * 1f;
    }

    public void ForceDrop()
    {
        if (heldItem == null) return;

        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        heldItem = null;
        hasItem = false;
    }

    public GameObject GetHeldItem()
    {
        return heldItem;
    }
}