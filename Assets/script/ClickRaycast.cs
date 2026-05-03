using UnityEngine;

public class ClickRaycast: MonoBehaviour
{
    public float rayDistance = 20f;
    public GameObject infoPanel;

    void Start()
    {
        infoPanel.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Ranipokhari"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    infoPanel.SetActive(true);
                }
            }
        }

        // Close panel
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            infoPanel.SetActive(false);
        }
        
    }
}