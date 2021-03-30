using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models.Repository;
using System;
using System.Threading.Tasks;

namespace ToDoApi.Models.DataManager
{
        public class ToDoManager : IDataRepository<ToDo>
        {
            readonly ToDoContext _todoContext;
            public ToDoManager(ToDoContext context)
            {
                _todoContext = context;
            }
            public IEnumerable<ToDo> GetAll()
            {
                return _todoContext.ToDos.ToList();
            }
            public ToDo Get(long id)
            {
                return _todoContext.ToDos
                      .FirstOrDefault(e => e.Id == id);
            }
            public void Add(ToDo entity)
            {
                _todoContext.ToDos.Add(entity);
                _todoContext.SaveChanges();
            }
            public void Update(ToDo employee, ToDo entity)
            {
                employee.Description = entity.Description;
                employee.IsDone = entity.IsDone;
            }
            public void Delete(ToDo todo)
            {
                _todoContext.ToDos.Remove(todo);
                _todoContext.SaveChanges();
            }
        }
 }
