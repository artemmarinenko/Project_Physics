using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastControll : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, _rayLength, _layerMask)) { 

                if (hit.collider.TryGetComponent(out CrasherController hero))
                    GameEvents.RaiseOnSphereHeroCkick();

                else if (hit.collider.TryGetComponent(out Catapult catapult))
                    GameEvents.RaiseOnCatapultClick();
            }
        }
        
    }
}
