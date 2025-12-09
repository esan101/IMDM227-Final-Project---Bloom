using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    // need instantiator to make copies of the flower 
    // need 
    public GameObject cube;
    void Start()
    {
        
    }

    void Update()
    {
         if (Mouse.current.leftButton.wasPressedThisFrame
             && Physics.Raycast(
                    Camera.main.ScreenPointToRay(
                        Mouse.current.position.ReadValue()),
                        out RaycastHit hit))
        {
            Collider collider = hit.collider;
            GameObject gameObject = collider.gameObject;
            // look at name of gameobject, if gameobject name = background then 

            if (gameObject.name == "Background")
            {
                GameObject cube = Instantiate(hit.collider.gameObject);
            }

            Vector3 pos = hit.point;
            Debug.Log("hit.point: " + hit.point);

            pos.y = 1;

            
            Instantiate(cube);
            cube.transform.position = pos;
            // cube.transform.rotate = ;
            
            
            
            
            
            // Vector3 = hit.point;

            // CreateShape nextSelected = gameObject.GetComponent<MaterialSetter>();
            // want this to create a new cube on the inivsible plane
            // need unity command for it to create a new gameobject/ instantiate
            
        }
    }
}
