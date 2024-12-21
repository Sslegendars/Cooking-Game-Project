using System;
using UnityEditor.Build;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRomoved;
    [SerializeField]
    private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 5f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
           if(GameManager.Instance.IsGamePlaying() && platesSpawnedAmount < platesSpawnedAmountMax)
           {
                platesSpawnedAmount++;
                OnPlateSpawned?.Invoke(this,EventArgs.Empty);
           }
        }
    }
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is Empty handed
            if(platesSpawnedAmount > 0)
            {
                // There's atleast one plate here
                platesSpawnedAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                OnPlateRomoved?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}
