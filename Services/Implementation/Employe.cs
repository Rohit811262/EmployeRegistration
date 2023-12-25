using AutoMapper;
using Entities.BizEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.DBEntities;
using Services.Interface;

namespace Services.Implementation
{
    public class Employe : IEmploye
    {
        private readonly ILogger<Employe> logger; // Specify the logger type
        private readonly IMapper mapper;
        private readonly EmployeRegistrationTestDbContext _db; // Declare the database 
        private readonly IConfiguration _configuration; // You need to declare this as well

        public Employe(
            ILogger<Employe> logger,
            IMapper mapper,
            EmployeRegistrationTestDbContext db, // Inject the database context
            IConfiguration configuration) // Inject the configuration
        {
            this.logger = logger;
            this.mapper = mapper;
            _db = db;
            _configuration = configuration;
        }

        public async Task<List<BizEmployeInfo>> GetAll()
        {
            logger.LogDebug("Employe Service GetAll Method Started");
            using (var context = GetDBContext())
            {
                // Assuming you have an entity DbSet named BizEmployeInfo in your context
                var Employes = await context.EmployeInfos.ToListAsync();
                return mapper.Map<List<BizEmployeInfo>>(Employes);
            }
        }

        public async Task<BizEmployeInfo> GetById(int id)
        {
            using (var context = GetDBContext())
            {
                var Employe = await context.EmployeInfos.FindAsync(id);
                return mapper.Map<BizEmployeInfo>(Employe);
            }
        }

        private EmployeRegistrationTestDbContext GetDBContext()
        {
            // You should create and configure the database context here
            // _commonRepository.SetDbContext(_db); // This line seems unnecessary here
            return _db;
        }

        public async Task<bool> Create(BizEmployeInfo entity)
        {
            logger.LogDebug("Employe Service Create Method Started");
            using (var context = GetDBContext())
            {
                var EmployeEntity = mapper.Map<EmployeInfo>(entity);

                // Add the entity to the context and save changes
                context.EmployeInfos.Add(EmployeEntity);
                await context.SaveChangesAsync();

                return true;

            }
        }

        //public async Task<bool> Update(BizStudentInfo entity)
        //{
        //    logger.LogDebug("Department Service Update Method Started");
        //    using (var context = GetDBContext())
        //    {
        //        var studentEntity = mapper.Map<StudentInfo>(entity);

        //        // Add the entity to the context and save changes
        //        context.StudentInfos.Add(studentEntity);
        //        await context.SaveChangesAsync();

        //        return true;

        //    }
        //}

        //public async Task<bool> Update(BizEmployeInfo entity)
        //{
        //    logger.LogDebug("Department Service Update Method Started");
        //    using (var context = GetDBContext())
        //    {
        //        // Retrieve the existing entity by StudentId
        //        var existingEmployeEntity = await context.EmployeInfos.FindAsync(entity.EmpId);

        //        if (existingEmployeEntity != null)
        //        {
        //            // Update the properties of the existing entity with the values from the 'entity' parameter
        //            // Assuming 'mapper.Map' correctly maps the properties from 'entity' to 'existingStudentEntity'
        //            mapper.Map(entity, existingEmployeEntity);

        //            // Save the changes to the database
        //            await context.SaveChangesAsync();

        //            return true;
        //        }
        //        else
        //        {
        //            // Handle the case where the entity with the specified StudentId is not found
        //            return false;
        //        }

        //  }
        public async Task<bool> Update(BizEmployeInfo entity)
        {
            logger.LogDebug("Department Service Update Method Started");
            using (var context = GetDBContext())
            {
                // Retrieve the existing entity by StudentId
                var existingEmployeEntity = await context.EmployeInfos.FindAsync(entity.EmpId);

                if (existingEmployeEntity != null)
                {
                    // Update the properties of the existing entity with the values from the 'entity' parameter
                    // Assuming 'mapper.Map' correctly maps the properties from 'entity' to 'existingStudentEntity'
                    mapper.Map(entity, existingEmployeEntity);

                    // Save the changes to the database
                    await context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    // Handle the case where the entity with the specified StudentId is not found
                    return false;
                }
            }
        }

        // Delete method should be outside the Update method
        public async Task<bool> Delete(int id)
        {
            logger.LogDebug("Employe Service Delete Method Started");

            using (var context = GetDBContext())
            {
                var existingEmployeEntity = await context.EmployeInfos.FindAsync(id);

                if (existingEmployeEntity != null)
                {
                    context.EmployeInfos.Remove(existingEmployeEntity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

}


    

