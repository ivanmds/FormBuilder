using FormBuilder.Core.Domain.Models.Forms.Builder;
using System;

namespace FormBuilder.Core.Domain.Models.Forms
{
    public class FormBuild : FormBase
    {
        public FormBuild(string name, DateTime expiredIn)
        {
            Name = name;
            ExpiredIn = expiredIn;
        }
       
        public void SetName(string name)
        {
            Name = name;
        }
    }
}
