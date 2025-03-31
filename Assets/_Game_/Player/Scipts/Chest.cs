using UnityEngine;

public class Chest : MonoBehaviour, IInterractable
{
    public   bool IsOpened {  get; private set; }

    public string ChestID { get; private set; }
    public GameObject ItemPrefab; //Item that Chest drop
    public Sprite OpenedSprites; //Sprite changes from not used state to used, not needed. 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObejct); 
    }

    public bool CanInteract()
    {
        return !IsOpened;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanInteract()) return;
        //Open chest 
    }

    private void OpenChest()
    {
        SetOpened(true);

        //DropItem
        if (ItemPrefab)
        {
            GameObject droppedItem = Instansiate(ItemPrefab.transform + Vector3.down, Quaternion.identity);
        }
    }
    public void SetOpened(bool opened)
    {
        IsOpened = opened;
        if (IsOpened = opened)
        {
            GetComponent<SpriteRenderer>().sprite = OpenedSprites;
        }
    }
}
