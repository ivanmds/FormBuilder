using AutoMapper;
using FormBuilder.Core.Domain.Models.Forms;
using FormBuilder.Core.Domain.Models.Fields.Builder;
using FormBuilder.Core.Application.ViewModels.Fields.Builder;
using FormBuilder.Core.Application.ViewModels.Forms.Builder;

namespace FormBuilder.Core.Application.AutoMapper.Profiles.Forms
{
    public class ProfileConfig : Profile
    {
        private static ProfileConfig _profileConfig;

        private ProfileConfig()
        {
            CreateMap<FormBuild, FormBuildVM>();
            CreateMap<FormBuildVM, FormBuild>();

            CreateMap<BaseFieldBuilder, BaseFieldBuilderVM>();
            CreateMap<BaseFieldBuilderVM, BaseFieldBuilder>();
        }

        public static ProfileConfig Instance()
        {
            if (_profileConfig == null)
                _profileConfig = new ProfileConfig();

            return _profileConfig;
        }
    }
}
