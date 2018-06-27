using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interface;


namespace InstituteManagementAPI.Controllers
{
    [RoutePrefix("api/Bank")]
    public class BankController : ApiController
    {
        IBankRepository _repository;
        public BankController(IBankRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var banks = _repository.GetAll();
            return Ok(banks);
        }
        /// <summary>
        ///  Create new bank
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateBank")]
        public IHttpActionResult CreateBank(Bank bank)
        {
            var NewBank = _repository.CreateBank(bank);
            return Ok(NewBank);
        }
        [HttpPost]
        [Route("CreateBank")]
        public IHttpActionResult CreateBankTrn(BankTrn banktrn)
        {
            var NewBankTrn = _repository.CreateBankTrn(banktrn);
            return Ok(NewBankTrn);
        }
    }
}
