using System.Collections.Generic;
using UnityEngine;

namespace DarkGravityGames.Task5
{
    public class PositionsSaveLoad : MonoBehaviour
    {
        [SerializeField] private string _fileName;
        [SerializeField] private List<Transform> _positionsList;

        public void Save()
        {
            PositionDataList positionDataList = new PositionDataList();

            foreach (Transform transform in _positionsList)
            {
                PositionData positionData = new PositionData { Position = transform.position };
                positionDataList.Items.Add(positionData);
            }

            JsonDataService.SaveData(positionDataList, _fileName);
        }

        public void Load()
        {
            PositionDataList positionDataList = JsonDataService.LoadData<PositionDataList>(_fileName);

            for (int i = 0; i < _positionsList.Count && i < positionDataList.Items.Count; i++)
            {
                _positionsList[i].position = positionDataList.Items[i].Position;
            }
        }
    }
}