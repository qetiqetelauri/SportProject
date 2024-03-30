using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDAL;
using ProjectDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private TestDBContext _dbContext;
        private IMapper _mapper;

        public StudentsController(TestDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
       
        [HttpGet]
        public List<StudentDTO> GetStudent()
        {
            return  _mapper.Map<List<StudentDTO>>(_dbContext.Students.ToList<Student>());
        }

        [HttpGet]
        [Route("{Id:int}")]
        public StudentDTO GetStudentById(int id)
        {
            return _mapper.Map<StudentDTO>(_dbContext.Students.Find(id));
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDTO newStudent)
        {
            try
            {
                Student student = _mapper.Map<Student>(newStudent);
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                return Ok(newStudent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        [Route("{Id:int}")]
        public ActionResult UpdateStudent([FromRoute] int id, StudentDTO student)
        {
            try
            {
                var myStudent = _dbContext.Students.Find(id);
                if (myStudent == null)
                {
                    return NotFound();
                }

                myStudent.Name = student.Name;
                myStudent.Age = student.Age;

                _dbContext.SaveChanges();
                return Ok(myStudent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
            
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                var myStudent = _dbContext.Students.Find(id);
                if (myStudent == null)
                {
                    return NotFound();
                }

                _dbContext.Remove(myStudent);
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
