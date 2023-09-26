using GraphQl.Data;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphQl.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        protected override void OnConfigure(
           IDescriptorContext context,
           IObjectFieldDescriptor descriptor,
           MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }




}
