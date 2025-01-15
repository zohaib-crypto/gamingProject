using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;

public class ThirdPersonControllerShooter : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private bool isAiming = false; // Track if aiming is active

    // Store normal sensitivity for resetting after aiming
    private float normalSensitivity;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        normalSensitivity = thirdPersonController.Sensitivity; // Save the original sensitivity value
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        // Perform a raycast to check if there's a collider to aim at
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 200f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point; // Set the aiming point where the ray hits
            mouseWorldPosition = raycastHit.point; // Set the mouse world position for aiming
        }
        else
        {
            // If the raycast doesn't hit anything, place the aiming point 30 units in front of the camera
            debugTransform.position = ray.GetPoint(30);
            mouseWorldPosition = ray.GetPoint(30);
        }

        // Toggle aiming on button press
        if (starterAssetsInputs.aim)
        {
            isAiming = !isAiming; // Toggle aiming state
            aimVirtualCamera.gameObject.SetActive(isAiming); // Activate or deactivate the aim camera

            if (isAiming)
            {
                // Reduce sensitivity to half when aiming
                thirdPersonController.SetSensitivity(normalSensitivity * 0.5f);
            }
            else
            {
                // Reset sensitivity back to normal when not aiming
                thirdPersonController.SetSensitivity(normalSensitivity);
            }

            starterAssetsInputs.aim = false; // Reset the aim input to prevent continuous toggling
        }

        if (isAiming)
        {
            // Adjust the player's rotation to face the aiming direction
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y; // Maintain player's rotation on the horizontal plane
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            // Smoothly rotate towards the aim direction
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }

        if (starterAssetsInputs.shoot)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false; // Reset the shoot input to prevent continuous shooting 
        }
    }
}
