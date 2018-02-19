using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GT4WAvaliacao.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult JsonCall<T>(Func<T> function) where T : class
        {
            JsonResult response = null;
            string message = "";
            HttpStatusCode responseStatus;
            Object obj = null;
            try
            {
                obj = function();
                if (obj != null && function().GetType() != typeof(void))
                {
                    responseStatus = HttpStatusCode.OK;
                    message = "Operação realizada com Sucesso!";
                }
                else
                {
                    responseStatus = HttpStatusCode.NotFound;
                    message = "Não encontrado!";
                }
            }
            catch (DbEntityValidationException dbex)
            {
                responseStatus = HttpStatusCode.NotAcceptable;
                message = "Dados não validos!";
                response = Json(new { data = obj, status = responseStatus, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                responseStatus = HttpStatusCode.InternalServerError;
                message = "Erro de Requisição!";
                response = Json(new { data = obj, status = responseStatus, message = message }, JsonRequestBehavior.AllowGet);
            }

            response = Json(new { data = obj, status = responseStatus, message = message }, JsonRequestBehavior.AllowGet);


            return response;
        }

        public JsonResult JsonCall(Action function)
        {
            JsonResult response = null;
            string message = "";
            HttpStatusCode responseStatus;
            Object obj = null;
            try
            {
                function();
                responseStatus = HttpStatusCode.OK;
                message = "Operação realizada com Sucesso!";


            }
            catch (DbEntityValidationException dbex)
            {
                responseStatus = HttpStatusCode.NotAcceptable;
                message = "Dados não validos!";
                response = Json(new { data = obj, status = responseStatus, message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                responseStatus = HttpStatusCode.InternalServerError;
                message = "Erro de Requisição!";
                response = Json(new { data = obj, status = responseStatus, message = message }, JsonRequestBehavior.AllowGet);
            }

            response = Json(new { data = obj, status = responseStatus, message = message }, JsonRequestBehavior.AllowGet);


            return response;
        }
    }
}