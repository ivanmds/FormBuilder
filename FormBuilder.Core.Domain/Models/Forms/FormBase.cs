using System;
using FormBuilder.Core.Domain.Models.Fields;
using System.Collections.Generic;

namespace FormBuilder.Core.Domain.Models.Forms.Builder
{
    public abstract class FormBase
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime ExpiredIn { get; protected set; }
        public bool IsActive => ExpiredIn > DateTime.Now;

        private List<BaseField> _fields = new List<BaseField>();
        public IReadOnlyCollection<BaseField> Fields => _fields;

        public bool AddField(BaseField field)
        {
            _fields.Add(field);
            return true;
        }
    }
}