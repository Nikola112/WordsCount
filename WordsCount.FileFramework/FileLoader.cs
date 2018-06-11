using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace WordsCount.FileFramework
{
    public class FileLoader<T>
    {
        #region Fields

        private readonly string _filePath;
        private T _value;
        private bool _valueLoaded = false;

        #endregion

        #region Properties

        public T Value
        {
            get
            {
                if(_valueLoaded)
                {
                    return _value;
                }

                _valueLoaded = true;
                _value = LoadValue();
                return _value;
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

        #region Constructors

        public FileLoader()
        {
            _filePath = ConfigurationManager.AppSettings["FilePath"].ToString();
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
            using (var stream = new FileStream(_filePath, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(T));
                xml.Serialize(stream, _value);
            }
        }

        #endregion
    }
}
