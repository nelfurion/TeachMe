namespace TeachMe.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    //using TeachMe.Common;
    using TeachMe.Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
    }
}
