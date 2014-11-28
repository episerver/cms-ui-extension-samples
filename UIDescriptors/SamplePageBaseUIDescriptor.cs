using EPiServer.Shell;
using UIExtensionSamples.Models;

namespace UIExtensionSamples
{
    [UIDescriptorRegistration]
    public class SamplePageBaseUIDescriptor : UIDescriptor<SamplePageBase>
    {
        //By creating a UI descriptor we are telling the client that this class or interface needs to
        //be taken into consideration, for instance to be used for the AllowedTypes attribute.
    }
}
