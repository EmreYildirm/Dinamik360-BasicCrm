using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BasicCrm.BLL.IServices;
using AutoMapper;
using BasicCrm.Entities;
using BasicCrm.WEB.Dto;
using Microsoft.EntityFrameworkCore;
using BasicCrm.WEB.Models;

namespace BasicCrm.WEB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            var customers = customerService.GetAllCustomers();
            var customersResources = mapper.Map<List<Customer>, List<CustomerViewModel>>(customers);
            //var temp = new JsonResult(customersResources);
            //return Ok(temp);
            return View(customersResources);
        }

        // GET: Home/Details/5
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerResource = mapper.Map<Customer, CustomerViewModel>(customer);
            return View(customerResource);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SaveCustomerViewModel saveCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customerToCreate = mapper.Map<SaveCustomerViewModel, Customer>(saveCustomerViewModel);
                customerService.InsertCustomer(customerToCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(saveCustomerViewModel);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerService.GetCustomerById(id);
            var customerViewModel = mapper.Map<Customer, CustomerViewModel>(customer);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customerViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customerToBeUpdate = mapper.Map<CustomerViewModel, Customer>(customerViewModel);
                    customerService.UpdateCustomer(customerToBeUpdate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customerViewModel.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerViewModel = mapper.Map<Customer, CustomerViewModel>(customer);

            return View(customerViewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = customerService.GetCustomerById(id);
            customerService.DeleteCustomer(customer);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            if (customerService.GetCustomerById(id) == null)
                return false;
            else
                return true;
        }
    }
}
