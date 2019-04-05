using System;
using FormBuilder.Core.Domain.Models.Fields;
using System.Collections.Generic;

namespace FormBuilder.Core.Domain.Models.Forms.Builder
{
    public abstract class FormBase
    {
        public string Name { get; protected set; }
        public DateTime ExpiredIn { get; protected set; }
        public bool IsActive => ExpiredIn > DateTime.Now;

        private Dictionary<int, BaseField> _fields = new Dictionary<int, BaseField>();
        public IReadOnlyDictionary<int, BaseField> Fields => _fields;

        public bool AddField(int index, BaseField field)
        {
            if (index <= 0) throw new ArgumentException("Index invalid.");
            if (field == null) throw new ArgumentException("field not null.");
            if (_fields.ContainsKey(index)) return false;

            _fields.Add(index, field);
            return true;
        }
    }
}