using System;
using System.Collections.Generic;
using FormBuilder.Core.Application.ViewModels.Fields.Builder;

namespace FormBuilder.Core.Application.ViewModels.Forms.Builder
{
    public class FormBuildVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiredIn { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BaseFieldBuilderVM> Fields { get; set; }
    }
}
