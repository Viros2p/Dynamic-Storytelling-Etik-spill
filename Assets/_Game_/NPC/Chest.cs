using UnityEngine;

public class Chest : MonoBehaviour, IInterractable
{
    public   bool Isopened {  get; private set; }

    public string ChestID { get; private set; }
    public Player itemprefab;
    public Sprite OpenedSprites;
  





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
