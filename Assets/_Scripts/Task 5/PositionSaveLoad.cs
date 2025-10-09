using DarkGravityGames.Task5;
using UnityEngine;
using UnityEngine.UIElements;

namespace DarkGravityGames.Task5
{
    public class PositionSaveLoad : MonoBehaviour
    {
        public void Save()
        {
            PositionData positionData = new() { Position = transform.position };
            JsonDataService.SaveData(positionData, "Test");
        }

        public void Load()
        {
            PositionData positionData = JsonDataService.LoadData<PositionData>("Test");
            transform.position = positionData.Position;
        }
    }
}