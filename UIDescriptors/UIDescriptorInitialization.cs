using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using UIExtensionSamples.Models;

namespace UIExtensionSamples
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class UIDescriptorInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var uiDescriptorRegistry = ServiceLocator.Current.GetInstance<UIDescriptorRegistry>();
            var descriptors = uiDescriptorRegistry.UIDescriptors;

            var myInterfaceType = typeof(SampleInterface);

            foreach (UIDescriptor descriptor in descriptors)
            {
                if (myInterfaceType.IsAssignableFrom(descriptor.ForType))
                {
                    descriptor.DndTypes.Add(myInterfaceType.FullName.ToLowerInvariant());
                }
            }
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}