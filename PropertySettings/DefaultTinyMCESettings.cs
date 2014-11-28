using EPiServer.Core.PropertySettings;
using EPiServer.Editor.TinyMCE;
using EPiServer.ServiceLocation;
using System.Collections.Generic;

namespace UIExtensionSamples.PropertySettings
{
    [ServiceConfiguration(ServiceType = typeof(EPiServer.Core.PropertySettings.PropertySettings))]
    public class DefaultTinyMCESettings : PropertySettings<TinyMCESettings>
    {
        public DefaultTinyMCESettings()
        {
            //This class is defined as the default class to create settings for Tiny MCE.
            IsDefault = true;
            DisplayName = "Default settings from code";
            Description = "This is the default settings for the site as defined in code.";
        }

        public override TinyMCESettings GetPropertySettings()
        {
            var settings = new TinyMCESettings();

            var mainToolbar = new ToolbarRow(new List<string>() { "bold" });

            settings.ToolbarRows.Add(mainToolbar);

            settings.Height = 20;
            settings.Width = 200;

            return settings;
        }

        public override System.Guid ID
        {
            get { return new System.Guid("a6fe936f-190d-45e2-b83c-ccc0501a7312"); }
        }
    }
}