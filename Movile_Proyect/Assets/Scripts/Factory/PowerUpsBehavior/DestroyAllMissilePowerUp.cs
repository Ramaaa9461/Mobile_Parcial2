


using UnityEngine;

public class DestroyAllMissilePowerUp : PowerUp
{
    public override void Effect(GameObject _gameObject)
    {
        MyObject[] myObjects = FindObjectsOfType<MyObject>();

        foreach (MyObject obj in myObjects)
        {
            obj.Recycle();
        }


        Destroy(gameObject);
        GameManager.instance.SpawnRandomPowerUp();
    }
}
