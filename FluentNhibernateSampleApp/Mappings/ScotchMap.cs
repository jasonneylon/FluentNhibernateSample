using FluentNHibernate.Mapping;
using FluentNhibernateSampleApp.Domain;

namespace FluentNhibernateSampleApp.Mappings
{
    public class ScotchMap : SubclassMap<ScotchWhiskey>
    {
        public ScotchMap()
        {
            Map(x => x.Region);
        }
    }
}