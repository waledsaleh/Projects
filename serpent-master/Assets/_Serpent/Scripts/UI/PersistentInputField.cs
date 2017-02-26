using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Serpent {
    
    [RequireComponent(typeof(InputField))]
    public class PersistentInputField : MonoBehaviour {
        public string serializeKey;

        private InputField inputField;

        void Start() {
            inputField = GetComponent<InputField>();

            Assert.IsTrue(serializeKey.Length > 0);
            inputField.text = PlayerPrefs.GetString(serializeKey);

            inputField.onEndEdit.AddListener(UpdateStoredValue);
        }

        private void UpdateStoredValue(string text) {
            PlayerPrefs.SetString(serializeKey, text);
            PlayerPrefs.Save();
        }
    }

} // namespace Serpent
