using UnityEngine;

public class GlobalHelper
{
    public static string GenerateUniqueID(GameObject obj) 
    { 
        return $"{obj.Scene.name}_{obj.transform.position.x}_{obj.transform.position.y}"; // Eksempel p� ID, Chest_3_4 
    
    }


}
