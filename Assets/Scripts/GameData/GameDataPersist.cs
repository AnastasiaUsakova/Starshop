using UnityEngine;
using Utils;

namespace GameData
{
    public class GameDataPersist : Singleton<GameDataPersist>
    {
        private GameData _gameData = new GameData();

        public GameData GameData => _gameData;

        public void Save()
        {
        }

        public void Load()
        {
            var json = JsonUtility.ToJson(_gameData);
            PlayerPrefs.SetString("GameData", json);
        }
    }
}