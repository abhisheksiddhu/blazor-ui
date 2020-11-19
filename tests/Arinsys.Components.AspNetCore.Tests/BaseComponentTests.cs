using Bunit;

using Xunit;

namespace Arinsys.Components.AspNetCore.Tests
{
    public class BaseComponentTests : TestContext
    {
        [Fact]
        public void ComponentCssClasses_ChangesObserved()
        {
            BUI_Component component = RenderComponent<BUI_Component>().Instance;

            component.ComponentCssClasses.Add("testClass");

            Assert.Equal("testClass", component.CssClass);
        }
    }
}
