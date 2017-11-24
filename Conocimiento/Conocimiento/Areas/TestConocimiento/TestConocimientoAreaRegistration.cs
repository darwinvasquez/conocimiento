using System.Web.Mvc;

namespace Conocimiento.Areas.TestConocimiento
{
    public class TestConocimientoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestConocimiento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TestConocimiento_default",
                "TestConocimiento/{controller}/{action}/{id}",
                new { controller = "Categorias", action = "Index", id = UrlParameter.Optional },
                namespaces : new [] { "Conocimiento.Areas.TestConocimiento.Controllers" }
            );
        }
    }
}