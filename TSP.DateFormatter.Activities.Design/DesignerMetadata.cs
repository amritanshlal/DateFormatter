using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using TSP.DateFormatter.Activities.Design.Designers;
using TSP.DateFormatter.Activities.Design.Properties;

namespace TSP.DateFormatter.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(DateFormatter), categoryAttribute);
            builder.AddCustomAttributes(typeof(DateFormatter), new DesignerAttribute(typeof(DateFormatterDesigner)));
            builder.AddCustomAttributes(typeof(DateFormatter), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
