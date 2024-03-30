using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDAL;
using ProjectDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private TestDBContext _dbContext;
        private IMapper _mapper;

        public CustomersController(TestDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
       
        [HttpGet]
        public List<CustomerDTO> GetCustomers()
        {
            return  _mapper.Map<List<CustomerDTO>>(_dbContext.Customers.ToList<Customer>());
        }

        [HttpGet]
        [Route("{Id:int}")]
        public CustomerDTO GetCustomerById(int id)
        {
            return _mapper.Map<CustomerDTO>(_dbContext.Customers.Find(id));
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerDTO newCustomer)
        {
            try
            {
                Customer customer = _mapper.Map<Customer>(newCustomer);
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return Ok(newCustomer);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("{Id:int}")]
        public ActionResult UpdateCustomer([FromRoute] int id, CustomerDTO customer)
        {
            try
            {
                var myCutomer = _dbContext.Customers.Find(id);
                if (myCutomer == null)
                {
                    return NotFound();
                }

                myCutomer.first_name = customer.first_name;
                myCutomer.last_name = customer.last_name;
                myCutomer.email = customer.email;
                //myCutomer.phone = customer.phone;
                myCutomer.Salary = customer.Salary;

                _dbContext.SaveChanges();
                return Ok(myCutomer);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
            // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                var myCutomer = _dbContext.Customers.Find(id);
                if (myCutomer == null)
                {
                    return NotFound();
                }

                _dbContext.Remove(myCutomer);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
