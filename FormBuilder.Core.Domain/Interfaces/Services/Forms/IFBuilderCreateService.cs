using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Services.Forms
{
    public interface IFBuilderCreateService
    {
        void Add(FormBuild fBuilder);
        void Update(FormBuild fBuilder);
    }
}
