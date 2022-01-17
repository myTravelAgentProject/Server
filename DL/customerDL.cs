using AutoMapper;
using DTO;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class customerDL: ICustomerDL
    {
        MyTravelAgent2Context myTravelAgentContext;
        IMapper mapper;
       private readonly ILogger<customerDL> logger;
        public customerDL(MyTravelAgent2Context myTravelAgentContext, IMapper mapper,ILogger<customerDL>logger)
        {
            this.logger = logger;
            this.myTravelAgentContext = myTravelAgentContext;
            this.mapper = mapper;
        }

        //(get) returns a list of all the customers
        public async Task<List<customerDTO>> getAllCustomers()
        {
            try {
                List<Customer> customers = await myTravelAgentContext.Customers.ToListAsync();
                List<customerDTO> customerD = mapper.Map<List<Customer>, List<customerDTO>>(customers);
                return customerD;
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }return null;
           
        }

        //(get {id}) returns a customer according to the id
        public async Task<customerDTO> getCustomer(int id)
        {
            Customer customer = await myTravelAgentContext.Customers.FindAsync(id);
            customerDTO customerD= mapper.Map<Customer,customerDTO>(customer);
            return customerD;
        }

        /*(post) adds the new customer to the table,
         save the changes
        returns the id of the new customer from the db*/
        public async Task<int> addNewCustomer(customerDTO customerToAdd)
        {
            Customer customer = mapper.Map<customerDTO, Customer>(customerToAdd);
            await myTravelAgentContext.Customers.AddAsync(customer);
            myTravelAgentContext.SaveChanges();
            return customer.Id;
        }

        /*(put) finds the customer we want to change (according to the id),
         replace the customer with the new cuatomer (with the changes)
        save the changes*/
        public async Task updateCustomer(customerDTO customerToUpdate, int id)
        {
            Customer customerToUp = mapper.Map<customerDTO, Customer>(customerToUpdate);
            Customer customer = await myTravelAgentContext.Customers.FindAsync(id);
            myTravelAgentContext.Entry(customer).CurrentValues.SetValues(customerToUp);
            await myTravelAgentContext.SaveChangesAsync();
        }

        /*(delete) finds the customer according to the id,
         remove the customrt that found,
        save the changes*/
        public async Task deleteCustomer(int id)
        {
            Customer toDelete = await myTravelAgentContext.Customers.FindAsync(id);
            myTravelAgentContext.Customers.Remove(toDelete);
            await myTravelAgentContext.SaveChangesAsync();
        }
    }
}
