using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private string num = "GameManager";  

    void Start()
    {
        var gameObj = GameObject.Find(num);

        if (gameObj == null)
        {
            Instantiate(Resources.Load($"Manager/{num}"),gameObject.transform.parent);
        }
    }
}
