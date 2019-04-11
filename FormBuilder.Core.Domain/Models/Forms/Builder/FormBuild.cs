using System;
using FormBuilder.Core.Domain.Models.Forms.Builder;

namespace FormBuilder.Core.Domain.Models.Forms
{
    public class FormBuild : FormBuildBase
    {
        protected FormBuild() { }
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
