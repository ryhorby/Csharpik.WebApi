using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.Common
{
    public class ObjectListDto
    {
        public int HttpCode { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<ICsharpikDtoObject> ObjList { get; set; }
    }
}
