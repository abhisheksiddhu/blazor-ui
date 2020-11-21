using Bunit;

using Xunit;

namespace Arinsys.Components.AspNetCore.Tests
{
    public class BaseComponentTests : TestContext
    {
        [Fact]
        public void ComponentCssClasses_ChangesObserved()
        {
            BaseComponent component = RenderComponent<BaseComponent>().Instance;

            component.ComponentCssClasses.Add("testClass");

            Assert.Equal("testClass", component.CssClass);
        }
    }
}
