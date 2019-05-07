using System;
using System.Collections.Generic;
using FormBuilder.Core.Domain.Models.Fields.Builder;
using FormBuilder.Shared.Kernel.Model;

namespace FormBuilder.Core.Domain.Models.Forms.Builder
{
    public abstract class FormBuildBase : BaseEntity
    {
        public string Name { get; protected set; }
        public DateTime ExpiredIn { get; protected set; }
        public bool IsActive => ExpiredIn > DateTime.Now;

        private List<BaseFieldBuilder> _fields = new List<BaseFieldBuilder>();
        public IReadOnlyCollection<BaseFieldBuilder> Fields => _fields;

        public bool AddField(BaseFieldBuilder field)
        {
            _fields.Add(field);
            return true;
        }
    }
}