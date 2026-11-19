/*ApplicationDbContext.cs será a ligação entre a aplicação 
e o SQL Server através do Entity Framework Core.*/
//Dbset - Consultar/procurar/Adicionar/Remover 
// ToListAsync() - FindAsync() - AddAsync() - Remove() - SaveChangesAsync()

using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Models;

namespace TaskFlow.Api.Data;

    public class DataBaseCtx : DbContext
    {
            public  DbSet <TaskItem> Tasks { get; set ; } 
            //Tasks = Nome da propriedade da classe base DataBaseCtx -> DbContext
    }

 
