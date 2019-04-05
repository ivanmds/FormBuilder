using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Interfaces.Repositories.Forms;
using FormBuilder.Core.Domain.Interfaces.Services.Forms;

namespace FormBuilder.Core.Domain.Services.Forms
{
    public class FBuilderCreateService : IFBuilderCreateService
    {
        private readonly IFBuilderCreateRepository _repository;

        public FBuilderCreateService(IFBuilderCreateRepository repository)
        {
            _repository = repository;
        }

        public void Add(FormBuild fBuilder)
        {
            _repository.Add(fBuilder);
        }

        public void Update(FormBuild fBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}
