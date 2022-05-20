using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertClient.Tests.Pages
{
    public class IndexTests : TestContext
    {
        [Fact]
        public void Textbox_Renders_Empty()
        {
            var cut = RenderComponent<ConvertClient.Pages.Index>();

            cut.Find("input").MarkupMatches("<input/>");
        }
    }
}
