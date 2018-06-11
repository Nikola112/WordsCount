using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCount.ConsoleFramework
{
    class ConsoleLoader<T>
    {
        #region Fields
        
        private T _value;
        private bool _valueLoaded = false;

        #endregion

        #region Properties

        public T Value
        {
            get
            {
                if (_valueLoaded)
                {
                    return _value;
                }

                _valueLoaded = true;
                return LoadValue();
            }

            set
            {
                if (value.Equals(_value))
                    return;

                _value = value;
                SaveValue();
            }
        }

        #endregion

        #region Methods

        public T LoadValue()
        {
            using (var stream = new FileStream(_filePath, FileMode.Open))
            {
                var xml = new XmlSerializer(typeof(T));
                return (T)xml.Deserialize(stream);
            }
        }

        public void SaveValue()
        {
            using (var stream = new FileStream(_filePath, FileMode.Open))
            {
                var xml = new XmlSerializer(typeof(T));
                xml.Serialize(stream, _value);
            }
        }

        #endregion
    }
}
