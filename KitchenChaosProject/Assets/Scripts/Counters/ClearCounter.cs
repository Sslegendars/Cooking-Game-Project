using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;   
   
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object here
            if (player.HasKitchenObject())
            {   
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {
            // There is a KitchenObject here
            if (player.HasKitchenObject())
            {
                // Player is carrying something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player Holding a plate
                    if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        KitchenObject.DestroyKitchenObject(GetKitchenObject());
                    }
                    
                }
                else
                {
                    // Player is not carrying Plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter is holding Plate
                       if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                       {    
                            KitchenObject.DestroyKitchenObject(player.GetKitchenObject());
                            
                       }
                    }
                }
            }
            else
            {
                // Player is not Carriyng anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
