using UnityEngine;

public class pickup : MonoBehaviour
{
    public Transform holdPoint;
    public float range = 3f;
    public float moveSpeed = 10f;
    public float cooldownTime = 1.5f;

    private GameObject heldObject;
    private float cooldown;

    void Update()
    {
        if (cooldown > 0f)
            cooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupOrSteal();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }

        if (heldObject != null)
        {
            heldObject.transform.position = Vector3.Lerp(
                heldObject.transform.position,
                holdPoint.position,
                Time.deltaTime * moveSpeed
            );
        }
    }

    void TryPickupOrSteal()
    {
        if (cooldown > 0f) return;
        if (heldObject != null) return;

        Collider[] hits = Physics.OverlapSphere(transform.position, range);

        foreach (Collider hit in hits)
        {
            if (!hit.CompareTag("Pickup")) continue;

            GameObject item = hit.gameObject;

            // If NPC is holding it, force drop
            steal npc = FindObjectOfType<steal>();
            if (npc != null && npc.GetHeldItem() == item)
            {
                npc.ForceDrop();
            }

            Grab(item);
            return;
        }
    }

    void Grab(GameObject item)
    {
        heldObject = item;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;

        cooldown = cooldownTime;
    }

    public GameObject GetHeldObject()
    {
        return heldObject;
    }

    public void ForceDrop()
    {
        Drop();
    }

    void Drop()
    {
        if (heldObject == null) return;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        heldObject = null;
    }
}