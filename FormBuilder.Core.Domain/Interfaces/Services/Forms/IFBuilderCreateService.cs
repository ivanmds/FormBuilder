using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Services.Forms
{
    public interface IFBuilderCreateService
    {
        void Add(FBuilder fBuilder);
        void Update(FBuilder fBuilder);
    }
}
