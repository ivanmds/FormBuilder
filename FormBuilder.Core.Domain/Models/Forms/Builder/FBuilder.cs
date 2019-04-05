using FormBuilder.Core.Domain.Models.Forms.Builder;
using System;

namespace FormBuilder.Core.Domain.Models.Forms
{
    public class FBuilder : FormBase
    {
        public FBuilder(string name, DateTime expiredIn)
        {
            Name = name;
            ExpiredIn = expiredIn;
        }
    }
}
