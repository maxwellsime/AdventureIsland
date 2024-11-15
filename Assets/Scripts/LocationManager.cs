using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField] 
    private Sprite backgroundSprite;
    
    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite = backgroundSprite;
    }
}
