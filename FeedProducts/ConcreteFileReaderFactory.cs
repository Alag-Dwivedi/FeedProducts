using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedProducts
{
    public class ConcreteFileReaderFactory : FileReaderFactory
    {
        
        public override IFileReader GetFileReader(string path)
        {
            if (path != null && path.Contains(".yaml"))
            {
                return new YamlFileReader();
            }
            else if (path != null && path.Contains(".json"))
            {
               return  new JsonFileReader();
            }

            throw new NotImplementedException();
        }
    }
}
