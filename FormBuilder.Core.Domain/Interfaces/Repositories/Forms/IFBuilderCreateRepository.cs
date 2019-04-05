using FormBuilder.Core.Domain.Models.Forms;

namespace FormBuilder.Core.Domain.Interfaces.Repositories.Forms
{
    public interface IFBuilderCreateRepository
    {
        void Add(FormBuild fBuilder);
    }
}
