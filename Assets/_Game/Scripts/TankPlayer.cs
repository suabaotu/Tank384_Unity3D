using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayer : TankBase
{
    public Transform turret;
    public LayerMask raycastLayer;


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayer))
        {
            Vector3 targetPosition = hit.point;

            Vector3 direction = targetPosition - turret.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                turret.rotation = Quaternion.Lerp(turret.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }
}
