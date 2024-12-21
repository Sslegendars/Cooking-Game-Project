using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObjectSO", menuName = "Scriptable Objects/KitchenObjectSO")]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    [SerializeField]
    private string objectName;
}
