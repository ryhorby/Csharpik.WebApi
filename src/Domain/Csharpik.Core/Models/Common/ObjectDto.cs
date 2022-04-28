namespace Csharpik.Core.Models.Common
{
    public class ObjectDto
    {
        public int HttpCode { get; set; }

        public string ErrorMessage { get; set; }

        public ICsharpikDtoObject Obj { get; set; }
    }
}
