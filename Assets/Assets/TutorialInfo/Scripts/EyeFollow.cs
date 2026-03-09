using UnityEngine;
using UnityEngine.InputSystem;

public class EyeFollow : MonoBehaviour
{
    public Camera cam;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = cam.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);

            Vector3 direction = targetPoint - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
