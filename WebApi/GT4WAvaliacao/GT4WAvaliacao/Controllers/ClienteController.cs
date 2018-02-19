using GT4WAvaliacao.DAL.Interfaces;
using GT4WAvaliacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GT4WAvaliacao.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        
        public JsonResult GetList()
        {
            var repository = _unitOfWork.BeginTransaction<Cliente>();
            return JsonCall(() => _unitOfWork.ExecuteTransacted(() => repository.GetAll()));
        }
        
        public JsonResult CheckCpf(string cpf)
        {
            var repository = _unitOfWork.BeginTransaction<Cliente>();
            return JsonCall(() => _unitOfWork.ExecuteTransacted(() => repository.Find(c => c.Cpf == cpf)));
        }

        // GET: Cliente/Details/5
        
        public JsonResult Details(int id)
        {
            var repository = _unitOfWork.BeginTransaction<Cliente>();
            return JsonCall(() => _unitOfWork.ExecuteTransacted(() => repository.GetById(id)));
        }

        // POST: Cliente/Create
        [HttpPost]
        
        public JsonResult Create(Cliente cliente)
        {
            var respository = _unitOfWork.BeginTransaction<Cliente>();
            return JsonCall(() => _unitOfWork.ExecuteTransacted(() => respository.Add(cliente)));
        }

        // PUTH: Cliente/Edit/5
        [HttpPost]
        
        public JsonResult Edit(Cliente cliente)
        {
            var respository = _unitOfWork.BeginTransaction<Cliente>();
            return JsonCall(() => _unitOfWork.ExecuteTransacted(() => respository.Update(cliente)));
        }
        // DELETE: Cliente/Delete/5
        [HttpPost]
        
        public JsonResult Delete(int id)
        {
            var respository = _unitOfWork.BeginTransaction<Cliente>();
            return JsonCall(() => _unitOfWork.ExecuteTransacted(() => respository.Remove(id)));
        }
    }
}
